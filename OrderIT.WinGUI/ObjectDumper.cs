//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.IO;
using System.Reflection;
using System.Data.Objects;
using System.Windows.Forms;

namespace SampleSupport {
	public class ObjectCollectionCache : IEnumerable {
		public readonly Type OriginalType;
		public readonly IList Values;

		public ObjectCollectionCache(object o) {
			OriginalType = o.GetType();
			Values = new List<object>();
			foreach (object o2 in (IEnumerable)o) {
				Values.Add(o2);
			}
		}

		public IEnumerator GetEnumerator() {
			return Values.GetEnumerator();
		}
	}

	public static class ObjectDumper {
		public static void Write(object o, TreeView tree, TextBox sql) {
			Write(o, 0, tree, sql);
		}

		public static void Write(object o, int expandDepth, TreeView tree, TextBox sql) {
			Write(o, expandDepth, 10, tree, sql);
		}

		public static void Write(object o, int expandDepth, int maxLoadDepth, TreeView tree, TextBox sql) {
			if (o != null) {
				MethodInfo mi = o.GetType().GetMethod("ToTraceString");
				if (mi != null)
					sql.Text = mi.Invoke(o, null).ToString();
			}

			if (o != null && o is IEnumerable) {
				// ObjectResult<T> collections cannot be iterated twice, so we cache them
				// in an ObjectCollectionCache object

				o = new ObjectCollectionCache(o);
			}

			try {
				if (tree != null) {
					tree.Nodes.Clear();
					TreeViewGenerator gen = new TreeViewGenerator(Math.Max(expandDepth, 1), maxLoadDepth);
					TreeNode node = gen.GetTreeNode(o);
					tree.Nodes.Add(node);

				}

				ObjectDumperImpl dumper = new ObjectDumperImpl(maxLoadDepth);
				dumper.Write(o);
				dumper.WriteLine();
			}
			catch (Exception ex) {
				MessageBox.Show("EXCEPTION: " + ex.ToString());
			}
		}

		private class ObjectDumperImpl {

			TextWriter writer;
			int depth;
			Stack ancestors;
			private int Level {
				get {
					return ancestors.Count;
				}
			}

			public ObjectDumperImpl(int depth) {
				this.writer = Console.Out;
				this.depth = depth;
				this.ancestors = new Stack();
			}

			public void Write(string s) {
				writer.Write(s);
			}

			private void WriteIndent() {
				for (int i = 0; i < Level; i++)
					writer.Write("    ");
			}

			public void WriteLine() {
				writer.WriteLine();
			}

			private void WriteCommaIfNotEmpty(ref bool empty) {
				if (empty) {
					empty = false;
				}
				else {
					Write(", ");
				}
			}

			private void Write(Type t) {
				string name = t.Name;
				if (t.IsGenericType) {
					if (name.Contains("AnonymousType")) {
						Write("(AnonymousType)");
					}
					else if (name.Contains("SelectIterator")) {
						Write("(SelectIterator)");
					}
					else {
						Write(name.Remove(name.LastIndexOf("`")));
					}
					Write("<");
					bool empty = true;
					foreach (Type ga in t.GetGenericArguments()) {
						WriteCommaIfNotEmpty(ref empty);
						Write(ga);
					}
					Write(">");
				}
				else {
					Write(t.Name);
				}
			}

			private class Member {
				public string Name;
				public object Value;
			}

			private void Write(Member m) {
				if (m.Name != null) {
					Write(m.Name);
					Write(" = ");
				}
				Write(m.Value);
			}

			private void Write(IEnumerable<Member> members) {

				Write("{");
				bool empty = true;
				foreach (var m in members) {
					WriteCommaIfNotEmpty(ref empty);
					WriteLine();
					WriteIndent();
					Write(m);
				}

				ancestors.Pop();

				if (!empty) {
					WriteLine();
					WriteIndent();
				}
				Write("}");
			}

			public void Write(object o) {
				if (o == null) {
					Write("null");
				}
				else if (o is DateTime) {
					Write("{");
					Write(((DateTime)o).ToShortDateString());
					Write("}");
				}
				else if (o is ValueType) {
					Write(o.ToString());
				}
				else if (o is Type) {
					Write(((Type)o).Name);
				}
				else if (o is Exception) {
					Write("EXCEPTION: " + o.ToString());
				}
				else if (o is byte[]) {
					byte[] arr = (byte[])o;
					int length = Math.Min(arr.Length, 32);
					string t = "Byte[" + arr.Length + "] = " + BitConverter.ToString(arr, 0, length) + ((length != arr.Length) ? "..." : "");
					Write(t);
				}
				else if (o is string) {
					Write("\"");
					Write(o as string);
					Write("\"");
				}
				else {
					if (o is ObjectCollectionCache) {
						Write(((ObjectCollectionCache)o).OriginalType);
					}
					else {
						Write(o.GetType());
					}
					Write(" ");

					if (ancestors.Contains(o) || (Level > depth + 1)) {
						Write("{...}");
					}
					else {
						ancestors.Push(o);
						if (o is IEnumerable) {
							var members = from object element in (o as IEnumerable)
														select new Member { Name = null, Value = element };

							Write(members);
						}
						else if (o is DbDataRecord) {
							DbDataRecord rec = o as DbDataRecord;

							var members = from element in Enumerable.Range(0, rec.FieldCount)
														select new Member { Name = rec.GetName(element), Value = rec.IsDBNull(element) ? null : rec.GetValue(element) };

							Write(members);
						}
						else {
							var members = from element in o.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance)
														let p = element as PropertyInfo
														let f = element as FieldInfo
														where p != null || f != null && !element.Name.StartsWith("_")
														select new Member { Name = element.Name, Value = p != null ? p.GetValue(o, null) : f.GetValue(o) };

							Write(members);
						}
					}
				}
			}
		}
	}
}