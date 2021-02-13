namespace OrderIT.WinGUI {
	partial class CH19 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.Result = new System.Windows.Forms.ListView();
			this.TestType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Average = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FirstIteration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.OtherIterations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button7 = new System.Windows.Forms.Button();
			this.EnableTracking = new System.Windows.Forms.CheckBox();
			this.UseCompiledQuery = new System.Windows.Forms.CheckBox();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.enablePlanCaching = new System.Windows.Forms.CheckBox();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 53);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(247, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Insert customers and suppliers with EF";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 82);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(247, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Insert customers and suppliers with ADO.NET";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 111);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(247, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "Update customers with EF";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 140);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(247, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "Update customers with ADO.NET";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(12, 169);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(247, 23);
			this.button5.TabIndex = 4;
			this.button5.Text = "Select Customers With EF and L2E";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(12, 304);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(247, 23);
			this.button6.TabIndex = 5;
			this.button6.Text = "Select customers with ADO.NET";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// Result
			// 
			this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TestType,
            this.Total,
            this.Average,
            this.FirstIteration,
            this.OtherIterations});
			this.Result.FullRowSelect = true;
			this.Result.Location = new System.Drawing.Point(265, 82);
			this.Result.Name = "Result";
			this.Result.Size = new System.Drawing.Size(246, 440);
			this.Result.TabIndex = 6;
			this.Result.UseCompatibleStateImageBehavior = false;
			this.Result.View = System.Windows.Forms.View.Details;
			// 
			// TestType
			// 
			this.TestType.Text = "Test type";
			// 
			// Total
			// 
			this.Total.Text = "Total";
			this.Total.Width = 114;
			// 
			// Average
			// 
			this.Average.Text = "Average";
			this.Average.Width = 77;
			// 
			// FirstIteration
			// 
			this.FirstIteration.Text = "First iteration";
			this.FirstIteration.Width = 100;
			// 
			// OtherIterations
			// 
			this.OtherIterations.Text = "Other iterations";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(265, 53);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(247, 23);
			this.button7.TabIndex = 7;
			this.button7.Text = "Clear list view";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// EnableTracking
			// 
			this.EnableTracking.AutoSize = true;
			this.EnableTracking.Checked = true;
			this.EnableTracking.CheckState = System.Windows.Forms.CheckState.Checked;
			this.EnableTracking.Location = new System.Drawing.Point(12, 459);
			this.EnableTracking.Name = "EnableTracking";
			this.EnableTracking.Size = new System.Drawing.Size(139, 17);
			this.EnableTracking.TabIndex = 10;
			this.EnableTracking.Text = "Enable change tracking";
			this.EnableTracking.UseVisualStyleBackColor = true;
			// 
			// UseCompiledQuery
			// 
			this.UseCompiledQuery.AutoSize = true;
			this.UseCompiledQuery.Location = new System.Drawing.Point(12, 505);
			this.UseCompiledQuery.Name = "UseCompiledQuery";
			this.UseCompiledQuery.Size = new System.Drawing.Size(119, 17);
			this.UseCompiledQuery.TabIndex = 11;
			this.UseCompiledQuery.Text = "Use compiled query";
			this.UseCompiledQuery.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(12, 198);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(247, 47);
			this.button8.TabIndex = 12;
			this.button8.Text = "Select customers with EF and EntitySQL via Object Services";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(12, 251);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(247, 47);
			this.button9.TabIndex = 13;
			this.button9.Text = "Select customers with EF and EntitySQL via Entity Client";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// enablePlanCaching
			// 
			this.enablePlanCaching.AutoSize = true;
			this.enablePlanCaching.Checked = true;
			this.enablePlanCaching.CheckState = System.Windows.Forms.CheckState.Checked;
			this.enablePlanCaching.Location = new System.Drawing.Point(12, 482);
			this.enablePlanCaching.Name = "enablePlanCaching";
			this.enablePlanCaching.Size = new System.Drawing.Size(123, 17);
			this.enablePlanCaching.TabIndex = 14;
			this.enablePlanCaching.Text = "Enable plan caching";
			this.enablePlanCaching.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(12, 333);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(247, 23);
			this.button10.TabIndex = 15;
			this.button10.Text = "Invoke stored procedure with EF";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button11
			// 
			this.button11.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button11.Location = new System.Drawing.Point(12, 12);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(247, 35);
			this.button11.TabIndex = 16;
			this.button11.Text = "Warmup application";
			this.button11.UseVisualStyleBackColor = false;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button12
			// 
			this.button12.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button12.Location = new System.Drawing.Point(265, 12);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(247, 35);
			this.button12.TabIndex = 17;
			this.button12.Text = "Restart";
			this.button12.UseVisualStyleBackColor = false;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(12, 362);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(247, 23);
			this.button13.TabIndex = 18;
			this.button13.Text = "Invoke stored procedure with ADO.NET";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(12, 391);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(247, 23);
			this.button14.TabIndex = 19;
			this.button14.Text = "Invoke stored procedure via Entity Client";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(12, 420);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(247, 23);
			this.button15.TabIndex = 20;
			this.button15.Text = "Execute queries manually handling connection ";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new System.EventHandler(this.button15_Click);
			// 
			// CH19
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(523, 535);
			this.Controls.Add(this.button15);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.enablePlanCaching);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.UseCompiledQuery);
			this.Controls.Add(this.EnableTracking);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.Result);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "CH19";
			this.Text = "CH19 - Performance";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.ListView Result;
		private System.Windows.Forms.ColumnHeader TestType;
		private System.Windows.Forms.ColumnHeader Total;
		private System.Windows.Forms.ColumnHeader Average;
		private System.Windows.Forms.ColumnHeader FirstIteration;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.CheckBox EnableTracking;
		private System.Windows.Forms.CheckBox UseCompiledQuery;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.CheckBox enablePlanCaching;
		private System.Windows.Forms.ColumnHeader OtherIterations;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;
	}
}

