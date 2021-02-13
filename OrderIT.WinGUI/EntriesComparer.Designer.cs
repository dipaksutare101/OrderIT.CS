namespace OrderIT.WinGUI {
	partial class EntriesComparer {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tree = new System.Windows.Forms.TreeView();
			this.Merge = new System.Windows.Forms.Button();
			this.Discard = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tree.CheckBoxes = true;
			this.tree.Location = new System.Drawing.Point(12, 12);
			this.tree.Name = "tree";
			this.tree.Size = new System.Drawing.Size(328, 329);
			this.tree.TabIndex = 0;
			// 
			// Merge
			// 
			this.Merge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Merge.Location = new System.Drawing.Point(265, 347);
			this.Merge.Name = "Merge";
			this.Merge.Size = new System.Drawing.Size(75, 23);
			this.Merge.TabIndex = 1;
			this.Merge.Text = "Merge";
			this.Merge.UseVisualStyleBackColor = true;
			this.Merge.Click += new System.EventHandler(this.Merge_Click);
			// 
			// Discard
			// 
			this.Discard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Discard.Location = new System.Drawing.Point(184, 347);
			this.Discard.Name = "Discard";
			this.Discard.Size = new System.Drawing.Size(75, 23);
			this.Discard.TabIndex = 2;
			this.Discard.Text = "Discard";
			this.Discard.UseVisualStyleBackColor = true;
			this.Discard.Click += new System.EventHandler(this.Discard_Click);
			// 
			// EntriesComparer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(350, 382);
			this.Controls.Add(this.Discard);
			this.Controls.Add(this.Merge);
			this.Controls.Add(this.tree);
			this.Name = "EntriesComparer";
			this.Text = "EntriesComparer";
			this.Load += new System.EventHandler(this.EntriesComparer_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.Button Merge;
		private System.Windows.Forms.Button Discard;

	}
}