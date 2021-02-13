using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using System.Data.Common;

namespace OrderIT.WinGUI {
	public partial class EntriesComparer : Form {
		public EntriesComparer(ObjectStateEntry entry) {
			_entry = entry;
			InitializeComponent();
		}

		public bool ApplyChanges { get; set; }
		ObjectStateEntry _entry;

		private void EntriesComparer_Load(object sender, EventArgs e) {
			var modifiedProperties = _entry.GetModifiedProperties();
			for (int i = 0; i < _entry.OriginalValues.FieldCount; i++) {
				var isModified = modifiedProperties.Any(n => n ==
					_entry.OriginalValues.GetName(i));
				TreeNode node = new TreeNode(CreateNodeText(
					_entry.OriginalValues.GetName(i), isModified));
				node.Checked = isModified;
				node.Tag = _entry.OriginalValues.GetName(i);
				tree.Nodes.Add(node);
				if (_entry.OriginalValues[i] is DbDataRecord)
					DrawComplexType(node, _entry.OriginalValues[i] as DbDataRecord,
						_entry.CurrentValues[i] as DbDataRecord);
				else
					DrawProperty(node, _entry.OriginalValues[i],
						_entry.CurrentValues[i]);
			}
		}

		private void DrawProperty(TreeNode node, object originalValue, object currentValue){
			
			string localOriginalValue, localCurrentValue;
			if (originalValue is byte[]) {
				localOriginalValue = GetBytArrayText((byte[])originalValue);
				localCurrentValue = GetBytArrayText((byte[])currentValue);
			}
			else {
				localOriginalValue = originalValue.ToString();
				localCurrentValue = currentValue.ToString();
			}
			node.Nodes.Add(new TreeNode("Original Value: " + localOriginalValue));
			node.Nodes.Add(new TreeNode("Current Value: " + localCurrentValue));
			
		}

		private void DrawComplexType(TreeNode node, DbDataRecord originalValues, DbDataRecord currentValues){
			for (int i=0; i<originalValues.FieldCount; i++) {
				TreeNode childNode = new TreeNode(CreateNodeText(originalValues.GetName(i), false));
				node.Nodes.Add(childNode);
				if (_entry.OriginalValues[i] is DbDataRecord){
					DrawComplexType(childNode, originalValues[i] as DbDataRecord, currentValues[i] as DbDataRecord);
				}
				else{
					DrawProperty(childNode, originalValues[i], currentValues[i]);
				}
			}
		}

		private string CreateNodeText(string propertyName, bool isModified) {
			return propertyName + " " + (isModified ? "Modified" : String.Empty);
		}

		private string GetBytArrayText(byte[] value) {
			string result = String.Empty;
			foreach (byte b in (byte[])value) {
				result += b.ToString() + "|";
			}
			return result.Substring(0, result.Length - 1);
		}

		private void Discard_Click(object sender, EventArgs e) {
			ApplyChanges = false;
			Close();
		}

		private void Merge_Click(object sender, EventArgs e) {
			ApplyChanges = true;
			object version = _entry.OriginalValues["Version"]; 
			_entry.ChangeState(EntityState.Unchanged);
			_entry.GetUpdatableOriginalValues().SetValue(_entry.OriginalValues.GetOrdinal("Version"), version);
			foreach (TreeNode node in tree.Nodes) {
				if (node.Checked)
					_entry.SetModifiedProperty(node.Tag.ToString());
			}
			Close();
		}
	}
}
