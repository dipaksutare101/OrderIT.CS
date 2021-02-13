using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.Common;
using System.Reflection;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace SampleSupport
{
    class TreeViewGenerator
    {
        private class Member
        {
            public string Name;
            public object Value;
        }

        private int _expandDepth;
        private int _maxLoadDepth;
        private int _level = 0;
        private Stack _ancestors = new Stack();

        public TreeViewGenerator(int expandDepth, int maxLoadDepth)
        {
            _expandDepth = expandDepth;
            _maxLoadDepth = maxLoadDepth;
        }

        private string GetNiceTypeName(Type t)
        {
            if (t.Name.Contains("AnonymousType"))
                return "(AnonymousType)";

            if (t.Name.Contains("SelectIterator"))
                return "(SelectIterator)";

            if (t.IsGenericType)
            {
                string name = t.Name;
                int backquote = name.IndexOf('`');
                if (backquote >= 0)
                    name = name.Substring(0, backquote);

                StringBuilder sb = new StringBuilder();
                sb.Append(name);
                sb.Append("<");
                Type[] args = t.GetGenericArguments();
                for (int i = 0; i < args.Length; ++i)
                {
                    if (i > 0)
                        sb.Append(", ");
                    sb.Append(GetNiceTypeName(args[i]));
                }
                sb.Append(">");
                return sb.ToString();
            }

            return t.Name;
        }
        public TreeNode GetTreeNode(object o)
        {
            if (o == null)
                return GetNullNode();

            if (o is Exception)
                return GetExceptionNode((Exception)o);

            if (o is DateTime)
                return GetDateTimeNode((DateTime)o);

            if (o is String)
                return GetStringNode((string)o);

            if (o is Type)
                return GetTypeNode((Type)o);

            if (o is byte[])
            {
                return GetByteArrayNode((byte[])o);
            }

            if (o is ValueType)
                return GetValueTypeNode(o);

            if (_ancestors.Contains(o) || _level >= _maxLoadDepth)
            {
                return new TreeNode("{ ... }");
            }

            TreeNode parentNode = new TreeNode(GetNiceTypeName(o.GetType()));
            if (o is ObjectCollectionCache)
            {
                parentNode.Text = GetNiceTypeName(((ObjectCollectionCache)o).OriginalType);
            }

            _ancestors.Push(o);
            int oldLevel = _level;
            _level++;

            if (o is IEnumerable)
            {
                parentNode.SelectedImageIndex = parentNode.ImageIndex = 4;
                var members = (from object element in (o as IEnumerable)
                              select new Member { Name = null, Value = element }).ToList();

                AttachChildren(parentNode, members);;
                parentNode.Text += " (" + members.Count + " item" + (members.Count != 1 ? "s" : "") + ")";
            }
            else if (o is DbDataRecord)
            {
                parentNode.SelectedImageIndex = parentNode.ImageIndex = 2;
                DbDataRecord rec = o as DbDataRecord;

                var members = from element in Enumerable.Range(0, rec.FieldCount)
                              select new Member { Name = rec.GetName(element), Value = rec.IsDBNull(element) ? null : rec.GetValue(element) };

                AttachChildren(parentNode, members);;
            }
            else
            {
                parentNode.SelectedImageIndex = parentNode.ImageIndex = 1;

                var members = from element in o.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance)
                              let p = element as PropertyInfo
                              let f = element as FieldInfo
                              where p != null || f != null && !element.Name.StartsWith("_")
                              select new Member { Name = element.Name, Value = p != null ? p.GetValue(o, null) : f.GetValue(o) };

                AttachChildren(parentNode, members); ;

                IEntityWithKey ewk = o as IEntityWithKey;
                if (ewk != null)
                {
                    StringBuilder sb = new StringBuilder(parentNode.Text.Length + 20);
                    sb.Append(parentNode.Text);
                    sb.Append("(");

                    for (int i = 0; i < ewk.EntityKey.EntityKeyValues.Length; ++i)
                    {
                        if (i > 0)
                            sb.Append(", ");
                        sb.Append(ewk.EntityKey.EntityKeyValues[i].Key);
                        sb.Append("=");
                        sb.Append(ewk.EntityKey.EntityKeyValues[i].Value);
                    }
                    sb.Append(")");
                    parentNode.Text = sb.ToString();
                }
            }
            if (_level <= _expandDepth)
                parentNode.Expand();
            _ancestors.Pop();
            _level = oldLevel;

            return parentNode;
        }

        private void AttachChildren(TreeNode parentNode, IEnumerable<Member> members)
        {
            int counter = 0;

            foreach (Member m in members)
            {
                TreeNode valueNode = GetTreeNode(m.Value);
                if (m.Name != null)
                    valueNode.Text = m.Name + " = " + valueNode.Text;
                else
                    valueNode.Text = "#" + counter++ + ": " + valueNode.Text;
                parentNode.Nodes.Add(valueNode);
            }
        }

        private TreeNode GetDateTimeNode(DateTime dateTime)
        {
            return new TreeNode(dateTime.ToShortDateString());
        }

        private TreeNode GetNullNode()
        {
            return new TreeNode("null");
        }

        private TreeNode GetStringNode(string s)
        {
            return new TreeNode("\"" + s + "\"");
        }

        private TreeNode GetValueTypeNode(object o)
        {
            return new TreeNode(Convert.ToString(o));
        }

        private TreeNode GetExceptionNode(Exception ex)
        {
            TreeNode node = new TreeNode(ex.GetType().Name + ": " + ex.Message);
            node.Nodes.Add(new TreeNode("Source: " + ex.Source));
            return node;
        }

        private TreeNode GetTypeNode(Type t)
        {
            TreeNode node = new TreeNode(GetNiceTypeName(t));
            return node;
        }

        private TreeNode GetByteArrayNode(byte[] arr)
        {
            int length = Math.Min(arr.Length,32);
            string t = "Byte[" + arr.Length + "] = " + BitConverter.ToString(arr, 0, length) + ((length != arr.Length) ? "..." : "");
            TreeNode node = new TreeNode(t);
            return node;
        }


    }
}
