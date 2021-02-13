namespace OrderIT.WinGUI
{
	partial class CH12
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Entities");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ComplexTypes");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Functions");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Containers");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Conceptual side", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tables/Views");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Functions");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Containers");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Storage side", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tree = new System.Windows.Forms.TreeView();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(93, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(174, 12);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tree.Location = new System.Drawing.Point(11, 41);
			this.tree.Name = "tree";
			treeNode1.Name = "CSDLEntities";
			treeNode1.Text = "Entities";
			treeNode2.Name = "CsdlComplexTypes";
			treeNode2.Text = "ComplexTypes";
			treeNode3.Name = "CSDLFunctions";
			treeNode3.Text = "Functions";
			treeNode4.Name = "CSDLContainers";
			treeNode4.Text = "Containers";
			treeNode5.Name = "Node0";
			treeNode5.Text = "Conceptual side";
			treeNode6.Name = "SSDLTables";
			treeNode6.Text = "Tables/Views";
			treeNode7.Name = "SSDLFunctions";
			treeNode7.Text = "Functions";
			treeNode8.Name = "SSDLContainers";
			treeNode8.Text = "Containers";
			treeNode9.Name = "";
			treeNode9.Text = "Storage side";
			this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode9});
			this.tree.Size = new System.Drawing.Size(399, 362);
			this.tree.TabIndex = 4;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(255, 12);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(336, 12);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 22);
			this.button5.TabIndex = 6;
			this.button5.Text = "button5";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// CH10
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 415);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.tree);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "CH10";
			this.Text = "CH12";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}