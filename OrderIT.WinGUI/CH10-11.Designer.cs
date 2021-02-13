namespace OrderIT.WinGUI
{
	partial class CH10_11
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.button1);
			this.flowLayoutPanel1.Controls.Add(this.button2);
			this.flowLayoutPanel1.Controls.Add(this.button3);
			this.flowLayoutPanel1.Controls.Add(this.button4);
			this.flowLayoutPanel1.Controls.Add(this.button5);
			this.flowLayoutPanel1.Controls.Add(this.button6);
			this.flowLayoutPanel1.Controls.Add(this.button7);
			this.flowLayoutPanel1.Controls.Add(this.button8);
			this.flowLayoutPanel1.Controls.Add(this.button9);
			this.flowLayoutPanel1.Controls.Add(this.button10);
			this.flowLayoutPanel1.Controls.Add(this.button11);
			this.flowLayoutPanel1.Controls.Add(this.button12);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1229, 145);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(326, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Retrieving OrderId and total amount using Scalar Valued Function";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button2.Location = new System.Drawing.Point(335, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(322, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "Retrieving OrderId and total amount using User Defined Function";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.AutoSize = true;
			this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button3.Location = new System.Drawing.Point(663, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(416, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "Retrieving OrderId and total amount using User Defined Function via LINQ to Entit" +
					"ies";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.AutoSize = true;
			this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button4.Location = new System.Drawing.Point(3, 32);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(520, 23);
			this.button4.TabIndex = 13;
			this.button4.Text = "Retrieving OrderId and total amount using User Defined Function with ObjectParame" +
					"ter via LINQ to Entities";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.AutoSize = true;
			this.button5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button5.Location = new System.Drawing.Point(529, 32);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(490, 23);
			this.button5.TabIndex = 14;
			this.button5.Text = "Retrieving OrderId and total amount using User Defined Function with ObjectParame" +
					"ter via Entity Sql";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.AutoSize = true;
			this.button6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button6.Location = new System.Drawing.Point(3, 61);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(336, 23);
			this.button6.TabIndex = 15;
			this.button6.Text = "Retrieving customers via User Defined Function via LINQ to Entities";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.AutoSize = true;
			this.button7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button7.Location = new System.Drawing.Point(345, 61);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(352, 23);
			this.button7.TabIndex = 16;
			this.button7.Text = "Retrieving customers address via User Defined Function via Entity SQL";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.AutoSize = true;
			this.button8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button8.Location = new System.Drawing.Point(703, 61);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(194, 23);
			this.button8.TabIndex = 17;
			this.button8.Text = "Retrieving typed customers projection";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.AutoSize = true;
			this.button9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button9.Location = new System.Drawing.Point(3, 90);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(376, 23);
			this.button9.TabIndex = 18;
			this.button9.Text = "Retrieving customers address via User Defined Function via LINQ to Entities";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button10
			// 
			this.button10.AutoSize = true;
			this.button10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button10.Location = new System.Drawing.Point(385, 90);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(448, 23);
			this.button10.TabIndex = 19;
			this.button10.Text = "Retrieving collection of scalar values of details with no discounted items via LI" +
					"NQ to Entities";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.AutoSize = true;
			this.button11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button11.Location = new System.Drawing.Point(839, 90);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(299, 23);
			this.button11.TabIndex = 20;
			this.button11.Text = "Retrieving collection of projected details via LINQ to Entities";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button12
			// 
			this.button12.AutoSize = true;
			this.button12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button12.Location = new System.Drawing.Point(3, 119);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(328, 23);
			this.button12.TabIndex = 21;
			this.button12.Text = "Retrieving collection of typed projected details via LINQ to Entities";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 145);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.textBox1);
			this.splitContainer1.Size = new System.Drawing.Size(1229, 281);
			this.splitContainer1.SplitterDistance = 408;
			this.splitContainer1.TabIndex = 8;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(408, 281);
			this.treeView1.TabIndex = 5;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(817, 281);
			this.textBox1.TabIndex = 4;
			// 
			// CH10_11
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1229, 426);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "CH10_11";
			this.Text = "CH10-11 Stored procedures, Database-Defined functions, User-Defined functions and" +
					" views";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;

	}
}