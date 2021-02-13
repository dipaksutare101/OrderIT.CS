namespace OrderIT.WinGUI
{
	partial class CH6_7_8Customers
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
			this.CustomerName = new System.Windows.Forms.TextBox();
			this.ShippingAddress = new System.Windows.Forms.TextBox();
			this.ShippingCity = new System.Windows.Forms.TextBox();
			this.ShippingZipCode = new System.Windows.Forms.TextBox();
			this.ShippingCountry = new System.Windows.Forms.TextBox();
			this.BillingAddress = new System.Windows.Forms.TextBox();
			this.BillingCity = new System.Windows.Forms.TextBox();
			this.BillingZipCode = new System.Windows.Forms.TextBox();
			this.BillingCountry = new System.Windows.Forms.TextBox();
			this.WSUsername = new System.Windows.Forms.TextBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.WSPassword = new System.Windows.Forms.TextBox();
			this.WSEnabled = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.CustomerId = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.btnGet = new System.Windows.Forms.Button();
			this.btnUpdateConnected = new System.Windows.Forms.Button();
			this.btnUpdateChangeObjectState = new System.Windows.Forms.Button();
			this.btnUpdateApplyCurrentValues = new System.Windows.Forms.Button();
			this.btnDeleteConnected = new System.Windows.Forms.Button();
			this.btnDeleteDisconnected = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CustomerName
			// 
			this.CustomerName.Location = new System.Drawing.Point(108, 48);
			this.CustomerName.Name = "CustomerName";
			this.CustomerName.Size = new System.Drawing.Size(100, 20);
			this.CustomerName.TabIndex = 21;
			// 
			// ShippingAddress
			// 
			this.ShippingAddress.Location = new System.Drawing.Point(108, 74);
			this.ShippingAddress.Name = "ShippingAddress";
			this.ShippingAddress.Size = new System.Drawing.Size(100, 20);
			this.ShippingAddress.TabIndex = 22;
			// 
			// ShippingCity
			// 
			this.ShippingCity.Location = new System.Drawing.Point(108, 100);
			this.ShippingCity.Name = "ShippingCity";
			this.ShippingCity.Size = new System.Drawing.Size(100, 20);
			this.ShippingCity.TabIndex = 23;
			// 
			// ShippingZipCode
			// 
			this.ShippingZipCode.Location = new System.Drawing.Point(108, 126);
			this.ShippingZipCode.Name = "ShippingZipCode";
			this.ShippingZipCode.Size = new System.Drawing.Size(100, 20);
			this.ShippingZipCode.TabIndex = 24;
			// 
			// ShippingCountry
			// 
			this.ShippingCountry.Location = new System.Drawing.Point(108, 152);
			this.ShippingCountry.Name = "ShippingCountry";
			this.ShippingCountry.Size = new System.Drawing.Size(100, 20);
			this.ShippingCountry.TabIndex = 25;
			// 
			// BillingAddress
			// 
			this.BillingAddress.Location = new System.Drawing.Point(323, 74);
			this.BillingAddress.Name = "BillingAddress";
			this.BillingAddress.Size = new System.Drawing.Size(100, 20);
			this.BillingAddress.TabIndex = 26;
			// 
			// BillingCity
			// 
			this.BillingCity.Location = new System.Drawing.Point(323, 100);
			this.BillingCity.Name = "BillingCity";
			this.BillingCity.Size = new System.Drawing.Size(100, 20);
			this.BillingCity.TabIndex = 27;
			// 
			// BillingZipCode
			// 
			this.BillingZipCode.Location = new System.Drawing.Point(323, 126);
			this.BillingZipCode.Name = "BillingZipCode";
			this.BillingZipCode.Size = new System.Drawing.Size(100, 20);
			this.BillingZipCode.TabIndex = 28;
			// 
			// BillingCountry
			// 
			this.BillingCountry.Location = new System.Drawing.Point(323, 152);
			this.BillingCountry.Name = "BillingCountry";
			this.BillingCountry.Size = new System.Drawing.Size(100, 20);
			this.BillingCountry.TabIndex = 29;
			// 
			// WSUsername
			// 
			this.WSUsername.Location = new System.Drawing.Point(554, 100);
			this.WSUsername.Name = "WSUsername";
			this.WSUsername.Size = new System.Drawing.Size(100, 20);
			this.WSUsername.TabIndex = 30;
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(12, 178);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(135, 38);
			this.btnCreate.TabIndex = 7;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreateCustomer_Click);
			// 
			// WSPassword
			// 
			this.WSPassword.Location = new System.Drawing.Point(554, 126);
			this.WSPassword.Name = "WSPassword";
			this.WSPassword.Size = new System.Drawing.Size(100, 20);
			this.WSPassword.TabIndex = 31;
			// 
			// WSEnabled
			// 
			this.WSEnabled.AutoSize = true;
			this.WSEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.WSEnabled.Location = new System.Drawing.Point(458, 77);
			this.WSEnabled.Name = "WSEnabled";
			this.WSEnabled.Size = new System.Drawing.Size(110, 17);
			this.WSEnabled.TabIndex = 32;
			this.WSEnabled.Text = "WSEnabled         ";
			this.WSEnabled.UseVisualStyleBackColor = true;
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "Shipping Address";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 103);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 35;
			this.label3.Text = "Shipping City";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 36;
			this.label4.Text = "Shipping ZipCode";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 155);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 13);
			this.label5.TabIndex = 37;
			this.label5.Text = "Shipping Country";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(228, 77);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 13);
			this.label9.TabIndex = 38;
			this.label9.Text = "Billing Address";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(228, 103);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 13);
			this.label8.TabIndex = 39;
			this.label8.Text = "Billing City";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(228, 129);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 13);
			this.label7.TabIndex = 40;
			this.label7.Text = "Billing ZipCode";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(227, 155);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 13);
			this.label6.TabIndex = 41;
			this.label6.Text = "Billing Country";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(458, 103);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(73, 13);
			this.label10.TabIndex = 42;
			this.label10.Text = "WSUsername";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(458, 129);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(71, 13);
			this.label11.TabIndex = 43;
			this.label11.Text = "WSPassword";
			// 
			// CustomerId
			// 
			this.CustomerId.Location = new System.Drawing.Point(108, 6);
			this.CustomerId.Name = "CustomerId";
			this.CustomerId.Size = new System.Drawing.Size(100, 20);
			this.CustomerId.TabIndex = 44;
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
			// btnGet
			// 
			this.btnGet.Location = new System.Drawing.Point(230, 4);
			this.btnGet.Name = "btnGet";
			this.btnGet.Size = new System.Drawing.Size(97, 23);
			this.btnGet.TabIndex = 46;
			this.btnGet.Text = "Retrieve by id";
			this.btnGet.UseVisualStyleBackColor = true;
			this.btnGet.Click += new System.EventHandler(this.btnRetrieveById_Click);
			// 
			// btnUpdateConnected
			// 
			this.btnUpdateConnected.Location = new System.Drawing.Point(12, 222);
			this.btnUpdateConnected.Name = "btnUpdateConnected";
			this.btnUpdateConnected.Size = new System.Drawing.Size(135, 53);
			this.btnUpdateConnected.TabIndex = 51;
			this.btnUpdateConnected.Text = "Update in connected scenario";
			this.btnUpdateConnected.UseVisualStyleBackColor = true;
			this.btnUpdateConnected.Click += new System.EventHandler(this.btnUpdateCustomerConnected_Click);
			// 
			// btnUpdateChangeObjectState
			// 
			this.btnUpdateChangeObjectState.Location = new System.Drawing.Point(153, 222);
			this.btnUpdateChangeObjectState.Name = "btnUpdateChangeObjectState";
			this.btnUpdateChangeObjectState.Size = new System.Drawing.Size(135, 53);
			this.btnUpdateChangeObjectState.TabIndex = 53;
			this.btnUpdateChangeObjectState.Text = "Update in disconnected scenario with ChangeObjectState";
			this.btnUpdateChangeObjectState.UseVisualStyleBackColor = true;
			this.btnUpdateChangeObjectState.Click += new System.EventHandler(this.btnUpdateCustomerChangeObjectState_Click);
			// 
			// btnUpdateApplyCurrentValues
			// 
			this.btnUpdateApplyCurrentValues.Location = new System.Drawing.Point(294, 222);
			this.btnUpdateApplyCurrentValues.Name = "btnUpdateApplyCurrentValues";
			this.btnUpdateApplyCurrentValues.Size = new System.Drawing.Size(135, 53);
			this.btnUpdateApplyCurrentValues.TabIndex = 54;
			this.btnUpdateApplyCurrentValues.Text = "Update in disconnected scenario with ApplyCurrentValues";
			this.btnUpdateApplyCurrentValues.UseVisualStyleBackColor = true;
			this.btnUpdateApplyCurrentValues.Click += new System.EventHandler(this.btnUpdateCustomerApplyCurrentValues_Click);
			// 
			// btnDeleteConnected
			// 
			this.btnDeleteConnected.Location = new System.Drawing.Point(12, 281);
			this.btnDeleteConnected.Name = "btnDeleteConnected";
			this.btnDeleteConnected.Size = new System.Drawing.Size(135, 38);
			this.btnDeleteConnected.TabIndex = 57;
			this.btnDeleteConnected.Text = "Delete in connected scenario";
			this.btnDeleteConnected.UseVisualStyleBackColor = true;
			this.btnDeleteConnected.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
			// 
			// btnDeleteDisconnected
			// 
			this.btnDeleteDisconnected.Location = new System.Drawing.Point(153, 281);
			this.btnDeleteDisconnected.Name = "btnDeleteDisconnected";
			this.btnDeleteDisconnected.Size = new System.Drawing.Size(135, 38);
			this.btnDeleteDisconnected.TabIndex = 58;
			this.btnDeleteDisconnected.Text = "Delete in disconnected scenario";
			this.btnDeleteDisconnected.UseVisualStyleBackColor = true;
			this.btnDeleteDisconnected.Click += new System.EventHandler(this.btnDeleteCustomerDisconnected_Click);
			// 
			// CH6_7_8Customers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 343);
			this.Controls.Add(this.btnDeleteDisconnected);
			this.Controls.Add(this.CustomerName);
			this.Controls.Add(this.btnDeleteConnected);
			this.Controls.Add(this.ShippingAddress);
			this.Controls.Add(this.ShippingCity);
			this.Controls.Add(this.ShippingZipCode);
			this.Controls.Add(this.btnUpdateApplyCurrentValues);
			this.Controls.Add(this.ShippingCountry);
			this.Controls.Add(this.btnUpdateChangeObjectState);
			this.Controls.Add(this.BillingAddress);
			this.Controls.Add(this.BillingCity);
			this.Controls.Add(this.btnUpdateConnected);
			this.Controls.Add(this.BillingZipCode);
			this.Controls.Add(this.BillingCountry);
			this.Controls.Add(this.WSUsername);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.WSPassword);
			this.Controls.Add(this.btnGet);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.WSEnabled);
			this.Controls.Add(this.CustomerId);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Name = "CH6_7_8Customers";
			this.Text = "Chapter 6, 7, 8 - Manage customers";
			this.Load += new System.EventHandler(this.CH6_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox CustomerName;
		private System.Windows.Forms.TextBox ShippingAddress;
		private System.Windows.Forms.TextBox ShippingCity;
		private System.Windows.Forms.TextBox ShippingZipCode;
		private System.Windows.Forms.TextBox ShippingCountry;
		private System.Windows.Forms.TextBox BillingAddress;
		private System.Windows.Forms.TextBox BillingCity;
		private System.Windows.Forms.TextBox BillingZipCode;
		private System.Windows.Forms.TextBox BillingCountry;
		private System.Windows.Forms.TextBox WSUsername;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.TextBox WSPassword;
		private System.Windows.Forms.CheckBox WSEnabled;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox CustomerId;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button btnGet;
		private System.Windows.Forms.Button btnUpdateConnected;
		private System.Windows.Forms.Button btnUpdateChangeObjectState;
		private System.Windows.Forms.Button btnUpdateApplyCurrentValues;
		private System.Windows.Forms.Button btnDeleteConnected;
		private System.Windows.Forms.Button btnDeleteDisconnected;

	}
}