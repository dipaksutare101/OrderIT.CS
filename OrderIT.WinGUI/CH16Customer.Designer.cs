namespace OrderIT.WinGUI {
	partial class CH16Customer {
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
			this.CustomerName = new System.Windows.Forms.TextBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.ShippingAddress = new System.Windows.Forms.TextBox();
			this.ShippingCity = new System.Windows.Forms.TextBox();
			this.ShippingZipCode = new System.Windows.Forms.TextBox();
			this.ShippingCountry = new System.Windows.Forms.TextBox();
			this.BillingAddress = new System.Windows.Forms.TextBox();
			this.BillingCity = new System.Windows.Forms.TextBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.BillingZipCode = new System.Windows.Forms.TextBox();
			this.BillingCountry = new System.Windows.Forms.TextBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnRetrieveById = new System.Windows.Forms.Button();
			this.label23 = new System.Windows.Forms.Label();
			this.CustomerId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// CustomerName
			// 
			this.CustomerName.Location = new System.Drawing.Point(108, 48);
			this.CustomerName.Name = "CustomerName";
			this.CustomerName.Size = new System.Drawing.Size(100, 20);
			this.CustomerName.TabIndex = 60;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(294, 178);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(135, 38);
			this.btnDelete.TabIndex = 89;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// ShippingAddress
			// 
			this.ShippingAddress.Location = new System.Drawing.Point(108, 74);
			this.ShippingAddress.Name = "ShippingAddress";
			this.ShippingAddress.Size = new System.Drawing.Size(100, 20);
			this.ShippingAddress.TabIndex = 61;
			// 
			// ShippingCity
			// 
			this.ShippingCity.Location = new System.Drawing.Point(108, 100);
			this.ShippingCity.Name = "ShippingCity";
			this.ShippingCity.Size = new System.Drawing.Size(100, 20);
			this.ShippingCity.TabIndex = 62;
			// 
			// ShippingZipCode
			// 
			this.ShippingZipCode.Location = new System.Drawing.Point(108, 126);
			this.ShippingZipCode.Name = "ShippingZipCode";
			this.ShippingZipCode.Size = new System.Drawing.Size(100, 20);
			this.ShippingZipCode.TabIndex = 63;
			// 
			// ShippingCountry
			// 
			this.ShippingCountry.Location = new System.Drawing.Point(108, 152);
			this.ShippingCountry.Name = "ShippingCountry";
			this.ShippingCountry.Size = new System.Drawing.Size(100, 20);
			this.ShippingCountry.TabIndex = 64;
			// 
			// BillingAddress
			// 
			this.BillingAddress.Location = new System.Drawing.Point(323, 74);
			this.BillingAddress.Name = "BillingAddress";
			this.BillingAddress.Size = new System.Drawing.Size(100, 20);
			this.BillingAddress.TabIndex = 65;
			// 
			// BillingCity
			// 
			this.BillingCity.Location = new System.Drawing.Point(323, 100);
			this.BillingCity.Name = "BillingCity";
			this.BillingCity.Size = new System.Drawing.Size(100, 20);
			this.BillingCity.TabIndex = 66;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(153, 178);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(135, 38);
			this.btnUpdate.TabIndex = 86;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// BillingZipCode
			// 
			this.BillingZipCode.Location = new System.Drawing.Point(323, 126);
			this.BillingZipCode.Name = "BillingZipCode";
			this.BillingZipCode.Size = new System.Drawing.Size(100, 20);
			this.BillingZipCode.TabIndex = 67;
			// 
			// BillingCountry
			// 
			this.BillingCountry.Location = new System.Drawing.Point(323, 152);
			this.BillingCountry.Name = "BillingCountry";
			this.BillingCountry.Size = new System.Drawing.Size(100, 20);
			this.BillingCountry.TabIndex = 68;
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(12, 178);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(135, 38);
			this.btnCreate.TabIndex = 59;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// btnRetrieveById
			// 
			this.btnRetrieveById.Location = new System.Drawing.Point(230, 4);
			this.btnRetrieveById.Name = "btnRetrieveById";
			this.btnRetrieveById.Size = new System.Drawing.Size(97, 23);
			this.btnRetrieveById.TabIndex = 85;
			this.btnRetrieveById.Text = "Retrieve by id";
			this.btnRetrieveById.UseVisualStyleBackColor = true;
			this.btnRetrieveById.Click += new System.EventHandler(this.btnRetrieveById_Click);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(12, 9);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(16, 13);
			this.label23.TabIndex = 84;
			this.label23.Text = "Id";
			// 
			// CustomerId
			// 
			this.CustomerId.Location = new System.Drawing.Point(108, 6);
			this.CustomerId.Name = "CustomerId";
			this.CustomerId.Size = new System.Drawing.Size(100, 20);
			this.CustomerId.TabIndex = 83;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 72;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 73;
			this.label2.Text = "Shipping Address";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 74;
			this.label3.Text = "Shipping City";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(227, 155);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 13);
			this.label6.TabIndex = 80;
			this.label6.Text = "Billing Country";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 75;
			this.label4.Text = "Shipping ZipCode";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(228, 129);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 13);
			this.label7.TabIndex = 79;
			this.label7.Text = "Billing ZipCode";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 155);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 13);
			this.label5.TabIndex = 76;
			this.label5.Text = "Shipping Country";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(228, 103);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 13);
			this.label8.TabIndex = 78;
			this.label8.Text = "Billing City";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(228, 77);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 13);
			this.label9.TabIndex = 77;
			this.label9.Text = "Billing Address";
			// 
			// CH16Customer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 226);
			this.Controls.Add(this.CustomerName);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.ShippingAddress);
			this.Controls.Add(this.ShippingCity);
			this.Controls.Add(this.ShippingZipCode);
			this.Controls.Add(this.ShippingCountry);
			this.Controls.Add(this.BillingAddress);
			this.Controls.Add(this.BillingCity);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.BillingZipCode);
			this.Controls.Add(this.BillingCountry);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.btnRetrieveById);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.CustomerId);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Name = "CH16Customer";
			this.Text = "CH16 - Update customer using WCF and generated objects";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox CustomerName;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.TextBox ShippingAddress;
		private System.Windows.Forms.TextBox ShippingCity;
		private System.Windows.Forms.TextBox ShippingZipCode;
		private System.Windows.Forms.TextBox ShippingCountry;
		private System.Windows.Forms.TextBox BillingAddress;
		private System.Windows.Forms.TextBox BillingCity;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.TextBox BillingZipCode;
		private System.Windows.Forms.TextBox BillingCountry;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnRetrieveById;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox CustomerId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
	}
}

