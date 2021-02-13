namespace OrderIT.WinGUI
{
	partial class CH6_7_8Suppliers
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.btnCreateSupplier = new System.Windows.Forms.Button();
			this.btnDeleteSupplierDisconnected = new System.Windows.Forms.Button();
			this.btnDeleteSupplierConnected = new System.Windows.Forms.Button();
			this.btnUpdateSupplierApplyCurrentValues = new System.Windows.Forms.Button();
			this.btnUpdateSupplierChangeObjectState = new System.Windows.Forms.Button();
			this.btnUpdateSupplierConnected = new System.Windows.Forms.Button();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.PaymentDays = new System.Windows.Forms.TextBox();
			this.IBAN = new System.Windows.Forms.TextBox();
			this.btnGetCompany = new System.Windows.Forms.Button();
			this.label23 = new System.Windows.Forms.Label();
			this.SupplierId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SupplierName = new System.Windows.Forms.TextBox();
			this.AddProductTosupplier = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.ProductsSold = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// btnCreateSupplier
			// 
			this.btnCreateSupplier.Location = new System.Drawing.Point(12, 126);
			this.btnCreateSupplier.Name = "btnCreateSupplier";
			this.btnCreateSupplier.Size = new System.Drawing.Size(135, 29);
			this.btnCreateSupplier.TabIndex = 8;
			this.btnCreateSupplier.Text = "Create";
			this.btnCreateSupplier.UseVisualStyleBackColor = true;
			this.btnCreateSupplier.Click += new System.EventHandler(this.btnCreateSupplier_Click);
			// 
			// btnDeleteSupplierDisconnected
			// 
			this.btnDeleteSupplierDisconnected.Location = new System.Drawing.Point(153, 220);
			this.btnDeleteSupplierDisconnected.Name = "btnDeleteSupplierDisconnected";
			this.btnDeleteSupplierDisconnected.Size = new System.Drawing.Size(135, 38);
			this.btnDeleteSupplierDisconnected.TabIndex = 60;
			this.btnDeleteSupplierDisconnected.Text = "Delete in disconnected scenario";
			this.btnDeleteSupplierDisconnected.UseVisualStyleBackColor = true;
			this.btnDeleteSupplierDisconnected.Click += new System.EventHandler(this.btnDeleteSupplierDisconnected_Click);
			// 
			// btnDeleteSupplierConnected
			// 
			this.btnDeleteSupplierConnected.Location = new System.Drawing.Point(12, 220);
			this.btnDeleteSupplierConnected.Name = "btnDeleteSupplierConnected";
			this.btnDeleteSupplierConnected.Size = new System.Drawing.Size(135, 38);
			this.btnDeleteSupplierConnected.TabIndex = 59;
			this.btnDeleteSupplierConnected.Text = "Delete in connected scenario";
			this.btnDeleteSupplierConnected.UseVisualStyleBackColor = true;
			this.btnDeleteSupplierConnected.Click += new System.EventHandler(this.btnDeleteSupplierConnected_Click);
			// 
			// btnUpdateSupplierApplyCurrentValues
			// 
			this.btnUpdateSupplierApplyCurrentValues.Location = new System.Drawing.Point(294, 161);
			this.btnUpdateSupplierApplyCurrentValues.Name = "btnUpdateSupplierApplyCurrentValues";
			this.btnUpdateSupplierApplyCurrentValues.Size = new System.Drawing.Size(135, 53);
			this.btnUpdateSupplierApplyCurrentValues.TabIndex = 56;
			this.btnUpdateSupplierApplyCurrentValues.Text = "Update in disconnected scenario with ApplyCurrentValues";
			this.btnUpdateSupplierApplyCurrentValues.UseVisualStyleBackColor = true;
			this.btnUpdateSupplierApplyCurrentValues.Click += new System.EventHandler(this.btnUpdateSupplierApplyCurrentValues_Click);
			// 
			// btnUpdateSupplierChangeObjectState
			// 
			this.btnUpdateSupplierChangeObjectState.Location = new System.Drawing.Point(153, 161);
			this.btnUpdateSupplierChangeObjectState.Name = "btnUpdateSupplierChangeObjectState";
			this.btnUpdateSupplierChangeObjectState.Size = new System.Drawing.Size(135, 53);
			this.btnUpdateSupplierChangeObjectState.TabIndex = 55;
			this.btnUpdateSupplierChangeObjectState.Text = "Update in disconnected scenario with ChangeObjectState";
			this.btnUpdateSupplierChangeObjectState.UseVisualStyleBackColor = true;
			this.btnUpdateSupplierChangeObjectState.Click += new System.EventHandler(this.btnUpdateSupplierChangeObjectState_Click);
			// 
			// btnUpdateSupplierConnected
			// 
			this.btnUpdateSupplierConnected.Location = new System.Drawing.Point(12, 161);
			this.btnUpdateSupplierConnected.Name = "btnUpdateSupplierConnected";
			this.btnUpdateSupplierConnected.Size = new System.Drawing.Size(135, 53);
			this.btnUpdateSupplierConnected.TabIndex = 52;
			this.btnUpdateSupplierConnected.Text = "Update in connected scenario";
			this.btnUpdateSupplierConnected.UseVisualStyleBackColor = true;
			this.btnUpdateSupplierConnected.Click += new System.EventHandler(this.btnUpdateSupplierConnected_Click);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(12, 103);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(73, 13);
			this.label24.TabIndex = 50;
			this.label24.Text = "Payment days";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(12, 77);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(32, 13);
			this.label25.TabIndex = 49;
			this.label25.Text = "IBAN";
			// 
			// PaymentDays
			// 
			this.PaymentDays.Location = new System.Drawing.Point(108, 100);
			this.PaymentDays.Name = "PaymentDays";
			this.PaymentDays.Size = new System.Drawing.Size(100, 20);
			this.PaymentDays.TabIndex = 48;
			// 
			// IBAN
			// 
			this.IBAN.Location = new System.Drawing.Point(108, 74);
			this.IBAN.Name = "IBAN";
			this.IBAN.Size = new System.Drawing.Size(100, 20);
			this.IBAN.TabIndex = 47;
			// 
			// btnGetCompany
			// 
			this.btnGetCompany.Location = new System.Drawing.Point(230, 4);
			this.btnGetCompany.Name = "btnGetCompany";
			this.btnGetCompany.Size = new System.Drawing.Size(99, 23);
			this.btnGetCompany.TabIndex = 46;
			this.btnGetCompany.Text = "Retrieve by Id";
			this.btnGetCompany.UseVisualStyleBackColor = true;
			this.btnGetCompany.Click += new System.EventHandler(this.btnRetrieveById_Click);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(12, 9);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(16, 13);
			this.label23.TabIndex = 45;
			this.label23.Text = "Id";
			// 
			// SupplierId
			// 
			this.SupplierId.Location = new System.Drawing.Point(108, 6);
			this.SupplierId.Name = "SupplierId";
			this.SupplierId.Size = new System.Drawing.Size(100, 20);
			this.SupplierId.TabIndex = 44;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 33;
			this.label1.Text = "Name";
			// 
			// SupplierName
			// 
			this.SupplierName.Location = new System.Drawing.Point(108, 48);
			this.SupplierName.Name = "SupplierName";
			this.SupplierName.Size = new System.Drawing.Size(100, 20);
			this.SupplierName.TabIndex = 21;
			// 
			// AddProductTosupplier
			// 
			this.AddProductTosupplier.Cursor = System.Windows.Forms.Cursors.Default;
			this.AddProductTosupplier.Location = new System.Drawing.Point(11, 398);
			this.AddProductTosupplier.Name = "AddProductTosupplier";
			this.AddProductTosupplier.Size = new System.Drawing.Size(135, 23);
			this.AddProductTosupplier.TabIndex = 6;
			this.AddProductTosupplier.Text = "Add Product to supplier";
			this.AddProductTosupplier.UseVisualStyleBackColor = true;
			this.AddProductTosupplier.Click += new System.EventHandler(this.AddProductTosupplier_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 281);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 13);
			this.label2.TabIndex = 62;
			this.label2.Text = "Product sold by the supplier";
			// 
			// ProductsSold
			// 
			this.ProductsSold.CheckBoxes = true;
			this.ProductsSold.Location = new System.Drawing.Point(11, 297);
			this.ProductsSold.Name = "ProductsSold";
			this.ProductsSold.Size = new System.Drawing.Size(416, 96);
			this.ProductsSold.TabIndex = 63;
			this.ProductsSold.UseCompatibleStateImageBehavior = false;
			this.ProductsSold.View = System.Windows.Forms.View.List;
			this.ProductsSold.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ProductsSold_ItemChecked);
			// 
			// CH6_7_8Suppliers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 429);
			this.Controls.Add(this.ProductsSold);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnDeleteSupplierDisconnected);
			this.Controls.Add(this.btnDeleteSupplierConnected);
			this.Controls.Add(this.btnGetCompany);
			this.Controls.Add(this.btnUpdateSupplierApplyCurrentValues);
			this.Controls.Add(this.SupplierName);
			this.Controls.Add(this.btnUpdateSupplierChangeObjectState);
			this.Controls.Add(this.AddProductTosupplier);
			this.Controls.Add(this.btnUpdateSupplierConnected);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.PaymentDays);
			this.Controls.Add(this.IBAN);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.SupplierId);
			this.Controls.Add(this.btnCreateSupplier);
			this.Controls.Add(this.label1);
			this.Name = "CH6_7_8Suppliers";
			this.Text = "Main";
			this.Load += new System.EventHandler(this.CH6_7_8Suppliers_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCreateSupplier;
		private System.Windows.Forms.Label label1;
				private System.Windows.Forms.TextBox SupplierName;
				private System.Windows.Forms.Button btnGetCompany;
				private System.Windows.Forms.Label label23;
				private System.Windows.Forms.TextBox SupplierId;
				private System.Windows.Forms.Label label24;
				private System.Windows.Forms.Label label25;
				private System.Windows.Forms.TextBox PaymentDays;
				private System.Windows.Forms.TextBox IBAN;
				private System.Windows.Forms.Button btnUpdateSupplierConnected;
				private System.Windows.Forms.Button btnUpdateSupplierChangeObjectState;
				private System.Windows.Forms.Button btnUpdateSupplierApplyCurrentValues;
				private System.Windows.Forms.Button btnDeleteSupplierConnected;
				private System.Windows.Forms.Button btnDeleteSupplierDisconnected;
				private System.Windows.Forms.Button AddProductTosupplier;
				private System.Windows.Forms.Label label2;
				private System.Windows.Forms.ListView ProductsSold;
	}
}