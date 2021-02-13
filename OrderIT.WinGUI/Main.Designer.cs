namespace OrderIT.WinGUI {
	partial class Main {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.suppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ordersAndIndependentAssociationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.updateCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripDropDownButton1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton8,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton2});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(338, 237);
			this.toolStrip1.TabIndex = 10;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton1.Text = "Chapter 4 - Query with LINQ to Entities";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.suppToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.ordersAndIndependentAssociationsToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(336, 20);
			this.toolStripDropDownButton1.Text = "Chapter 6, 7, 8 - Entities Persistence";
			this.toolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// customerToolStripMenuItem
			// 
			this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
			this.customerToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.customerToolStripMenuItem.Text = "Customers";
			this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
			// 
			// suppToolStripMenuItem
			// 
			this.suppToolStripMenuItem.Name = "suppToolStripMenuItem";
			this.suppToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.suppToolStripMenuItem.Text = "Suppliers";
			this.suppToolStripMenuItem.Click += new System.EventHandler(this.suppToolStripMenuItem_Click);
			// 
			// ordersToolStripMenuItem
			// 
			this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
			this.ordersToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.ordersToolStripMenuItem.Text = "Orders and Foreign Key Associations";
			this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
			// 
			// ordersAndIndependentAssociationsToolStripMenuItem
			// 
			this.ordersAndIndependentAssociationsToolStripMenuItem.Name = "ordersAndIndependentAssociationsToolStripMenuItem";
			this.ordersAndIndependentAssociationsToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.ordersAndIndependentAssociationsToolStripMenuItem.Text = "Orders and Independent Associations";
			this.ordersAndIndependentAssociationsToolStripMenuItem.Click += new System.EventHandler(this.ordersAndIndependentAssociationsToolStripMenuItem_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton3.Text = "Chapter 9 - Query with Entity SQL";
			this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton4.Text = "Chapter 10 - 11 - Stored procedures functions and views";
			this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton5.Text = "Chapter 12 - EDM Metadata";
			this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.updateCustomerToolStripMenuItem,
            this.updateOrderToolStripMenuItem});
			this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
			this.toolStripButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton8.Text = "Chapter 16 - WCF Service";
			this.toolStripButton8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 22);
			this.toolStripMenuItem1.Text = "Update customer";
			// 
			// updateCustomerToolStripMenuItem
			// 
			this.updateCustomerToolStripMenuItem.Name = "updateCustomerToolStripMenuItem";
			this.updateCustomerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			this.updateCustomerToolStripMenuItem.Text = "Update customer using STE";
			this.updateCustomerToolStripMenuItem.Click += new System.EventHandler(this.updateCustomerToolStripMenuItem_Click_2);
			// 
			// updateOrderToolStripMenuItem
			// 
			this.updateOrderToolStripMenuItem.Name = "updateOrderToolStripMenuItem";
			this.updateOrderToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
			this.updateOrderToolStripMenuItem.Text = "Update order";
			this.updateOrderToolStripMenuItem.Click += new System.EventHandler(this.updateOrderToolStripMenuItem_Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
			this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton6.Text = "Chapter 17 - Windows applications";
			this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
			this.toolStripButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton7.Text = "Chapter 19 - Performance";
			this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(336, 20);
			this.toolStripButton2.Text = "Appendix B";
			this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 22);
			this.toolStripMenuItem2.Text = "Update customer using DTO";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 217);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem suppToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripMenuItem ordersAndIndependentAssociationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSplitButton toolStripButton8;
		private System.Windows.Forms.ToolStripMenuItem updateCustomerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateOrderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
	}
}