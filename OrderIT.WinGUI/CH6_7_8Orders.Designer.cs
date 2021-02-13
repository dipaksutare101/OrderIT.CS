namespace OrderIT.WinGUI
{
	partial class CH6_7_8Orders
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
			this.CreateOrder = new System.Windows.Forms.Button();
			this.UpdateOrder = new System.Windows.Forms.Button();
			this.DeleteOrder = new System.Windows.Forms.Button();
			this.Details = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AddDetail = new System.Windows.Forms.Button();
			this.txtOrderDiscount = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.txtOrderPrice = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.txtOrderQuantity = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.cmbProducts = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.cmbCustomers = new System.Windows.Forms.ComboBox();
			this.btnRetrieveById = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.OrderId = new System.Windows.Forms.TextBox();
			this.ShippingAddress = new System.Windows.Forms.TextBox();
			this.ShippingCity = new System.Windows.Forms.TextBox();
			this.ShippingZipCode = new System.Windows.Forms.TextBox();
			this.ShippingCountry = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.RemoveSelected = new System.Windows.Forms.Button();
			this.OrderDate = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.EstimatedShippingDate = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.ActualShippindDate = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnDeleteDisconnected = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CreateOrder
			// 
			this.CreateOrder.Cursor = System.Windows.Forms.Cursors.Default;
			this.CreateOrder.Location = new System.Drawing.Point(12, 416);
			this.CreateOrder.Name = "CreateOrder";
			this.CreateOrder.Size = new System.Drawing.Size(133, 52);
			this.CreateOrder.TabIndex = 1;
			this.CreateOrder.Text = "Create";
			this.CreateOrder.UseVisualStyleBackColor = true;
			this.CreateOrder.Click += new System.EventHandler(this.CreateOrder_Click);
			// 
			// UpdateOrder
			// 
			this.UpdateOrder.Cursor = System.Windows.Forms.Cursors.Default;
			this.UpdateOrder.Location = new System.Drawing.Point(12, 474);
			this.UpdateOrder.Name = "UpdateOrder";
			this.UpdateOrder.Size = new System.Drawing.Size(133, 49);
			this.UpdateOrder.TabIndex = 2;
			this.UpdateOrder.Text = "Update using ApplyCurrentValues";
			this.UpdateOrder.UseVisualStyleBackColor = true;
			this.UpdateOrder.Click += new System.EventHandler(this.UpdateOrderUsingApplyCurrentValues_Click);
			// 
			// DeleteOrder
			// 
			this.DeleteOrder.Cursor = System.Windows.Forms.Cursors.Default;
			this.DeleteOrder.Location = new System.Drawing.Point(12, 529);
			this.DeleteOrder.Name = "DeleteOrder";
			this.DeleteOrder.Size = new System.Drawing.Size(133, 38);
			this.DeleteOrder.TabIndex = 4;
			this.DeleteOrder.Text = "Delete in connected scenario";
			this.DeleteOrder.UseVisualStyleBackColor = true;
			// 
			// Details
			// 
			this.Details.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.Details.FullRowSelect = true;
			this.Details.GridLines = true;
			this.Details.Location = new System.Drawing.Point(13, 222);
			this.Details.MultiSelect = false;
			this.Details.Name = "Details";
			this.Details.Size = new System.Drawing.Size(640, 188);
			this.Details.TabIndex = 76;
			this.Details.UseCompatibleStateImageBehavior = false;
			this.Details.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Product";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Quantity";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Price";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Discount";
			// 
			// AddDetail
			// 
			this.AddDetail.Location = new System.Drawing.Point(504, 193);
			this.AddDetail.Name = "AddDetail";
			this.AddDetail.Size = new System.Drawing.Size(44, 23);
			this.AddDetail.TabIndex = 75;
			this.AddDetail.Text = "Add detail";
			this.AddDetail.UseVisualStyleBackColor = true;
			this.AddDetail.Click += new System.EventHandler(this.AddDetail_Click);
			// 
			// txtOrderDiscount
			// 
			this.txtOrderDiscount.Location = new System.Drawing.Point(435, 194);
			this.txtOrderDiscount.Name = "txtOrderDiscount";
			this.txtOrderDiscount.Size = new System.Drawing.Size(63, 20);
			this.txtOrderDiscount.TabIndex = 74;
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(380, 197);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(49, 13);
			this.label30.TabIndex = 73;
			this.label30.Text = "Discount";
			// 
			// txtOrderPrice
			// 
			this.txtOrderPrice.Location = new System.Drawing.Point(311, 194);
			this.txtOrderPrice.Name = "txtOrderPrice";
			this.txtOrderPrice.Size = new System.Drawing.Size(63, 20);
			this.txtOrderPrice.TabIndex = 72;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(274, 197);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(31, 13);
			this.label29.TabIndex = 71;
			this.label29.Text = "Price";
			// 
			// txtOrderQuantity
			// 
			this.txtOrderQuantity.Location = new System.Drawing.Point(241, 194);
			this.txtOrderQuantity.Name = "txtOrderQuantity";
			this.txtOrderQuantity.Size = new System.Drawing.Size(27, 20);
			this.txtOrderQuantity.TabIndex = 70;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(189, 197);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(46, 13);
			this.label28.TabIndex = 69;
			this.label28.Text = "Quantity";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(12, 197);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(44, 13);
			this.label27.TabIndex = 68;
			this.label27.Text = "Product";
			// 
			// cmbProducts
			// 
			this.cmbProducts.DisplayMember = "Name";
			this.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProducts.FormattingEnabled = true;
			this.cmbProducts.Location = new System.Drawing.Point(62, 194);
			this.cmbProducts.Name = "cmbProducts";
			this.cmbProducts.Size = new System.Drawing.Size(121, 21);
			this.cmbProducts.TabIndex = 67;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(12, 58);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(51, 13);
			this.label26.TabIndex = 66;
			this.label26.Text = "Customer";
			// 
			// cmbCustomers
			// 
			this.cmbCustomers.DisplayMember = "Name";
			this.cmbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCustomers.FormattingEnabled = true;
			this.cmbCustomers.Location = new System.Drawing.Point(76, 55);
			this.cmbCustomers.Name = "cmbCustomers";
			this.cmbCustomers.Size = new System.Drawing.Size(121, 21);
			this.cmbCustomers.TabIndex = 6;
			this.cmbCustomers.SelectedIndexChanged += new System.EventHandler(this.cmbCustomers_SelectedIndexChanged);
			// 
			// btnRetrieveById
			// 
			this.btnRetrieveById.Location = new System.Drawing.Point(100, 4);
			this.btnRetrieveById.Name = "btnRetrieveById";
			this.btnRetrieveById.Size = new System.Drawing.Size(97, 23);
			this.btnRetrieveById.TabIndex = 81;
			this.btnRetrieveById.Text = "Retrieve by Id";
			this.btnRetrieveById.UseVisualStyleBackColor = true;
			this.btnRetrieveById.Click += new System.EventHandler(this.btnRetrieveById_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 13);
			this.label1.TabIndex = 79;
			this.label1.Text = "Id";
			// 
			// OrderId
			// 
			this.OrderId.Location = new System.Drawing.Point(43, 6);
			this.OrderId.Name = "OrderId";
			this.OrderId.Size = new System.Drawing.Size(48, 20);
			this.OrderId.TabIndex = 80;
			// 
			// ShippingAddress
			// 
			this.ShippingAddress.Location = new System.Drawing.Point(108, 119);
			this.ShippingAddress.Name = "ShippingAddress";
			this.ShippingAddress.Size = new System.Drawing.Size(100, 20);
			this.ShippingAddress.TabIndex = 82;
			// 
			// ShippingCity
			// 
			this.ShippingCity.Location = new System.Drawing.Point(108, 145);
			this.ShippingCity.Name = "ShippingCity";
			this.ShippingCity.Size = new System.Drawing.Size(100, 20);
			this.ShippingCity.TabIndex = 83;
			// 
			// ShippingZipCode
			// 
			this.ShippingZipCode.Location = new System.Drawing.Point(324, 116);
			this.ShippingZipCode.Name = "ShippingZipCode";
			this.ShippingZipCode.Size = new System.Drawing.Size(100, 20);
			this.ShippingZipCode.TabIndex = 84;
			// 
			// ShippingCountry
			// 
			this.ShippingCountry.Location = new System.Drawing.Point(324, 142);
			this.ShippingCountry.Name = "ShippingCountry";
			this.ShippingCountry.Size = new System.Drawing.Size(100, 20);
			this.ShippingCountry.TabIndex = 85;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 86;
			this.label2.Text = "Shipping Address";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 148);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 87;
			this.label3.Text = "Shipping City";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(228, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 88;
			this.label4.Text = "Shipping ZipCode";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(228, 145);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 13);
			this.label5.TabIndex = 89;
			this.label5.Text = "Shipping Country";
			// 
			// RemoveSelected
			// 
			this.RemoveSelected.Location = new System.Drawing.Point(554, 194);
			this.RemoveSelected.Name = "RemoveSelected";
			this.RemoveSelected.Size = new System.Drawing.Size(99, 21);
			this.RemoveSelected.TabIndex = 90;
			this.RemoveSelected.Text = "Remove detail";
			this.RemoveSelected.UseVisualStyleBackColor = true;
			this.RemoveSelected.Click += new System.EventHandler(this.RemoveSelected_Click);
			// 
			// OrderDate
			// 
			this.OrderDate.Location = new System.Drawing.Point(108, 93);
			this.OrderDate.Name = "OrderDate";
			this.OrderDate.Size = new System.Drawing.Size(100, 20);
			this.OrderDate.TabIndex = 91;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 13);
			this.label6.TabIndex = 92;
			this.label6.Text = "Order date";
			// 
			// EstimatedShippingDate
			// 
			this.EstimatedShippingDate.Location = new System.Drawing.Point(324, 90);
			this.EstimatedShippingDate.Name = "EstimatedShippingDate";
			this.EstimatedShippingDate.Size = new System.Drawing.Size(100, 20);
			this.EstimatedShippingDate.TabIndex = 93;
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(228, 93);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(91, 13);
			this.label56.TabIndex = 94;
			this.label56.Text = "Est. shipping date";
			// 
			// ActualShippindDate
			// 
			this.ActualShippindDate.Location = new System.Drawing.Point(554, 93);
			this.ActualShippindDate.Name = "ActualShippindDate";
			this.ActualShippindDate.Size = new System.Drawing.Size(99, 20);
			this.ActualShippindDate.TabIndex = 95;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(456, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 13);
			this.label7.TabIndex = 96;
			this.label7.Text = "Act. shipping date";
			// 
			// btnDeleteDisconnected
			// 
			this.btnDeleteDisconnected.Location = new System.Drawing.Point(151, 529);
			this.btnDeleteDisconnected.Name = "btnDeleteDisconnected";
			this.btnDeleteDisconnected.Size = new System.Drawing.Size(135, 38);
			this.btnDeleteDisconnected.TabIndex = 97;
			this.btnDeleteDisconnected.Text = "Delete in disconnected scenario";
			this.btnDeleteDisconnected.UseVisualStyleBackColor = true;
			// 
			// CH6_7_8Orders
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 573);
			this.Controls.Add(this.btnDeleteDisconnected);
			this.Controls.Add(this.ActualShippindDate);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.EstimatedShippingDate);
			this.Controls.Add(this.label56);
			this.Controls.Add(this.OrderDate);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.RemoveSelected);
			this.Controls.Add(this.ShippingAddress);
			this.Controls.Add(this.ShippingCity);
			this.Controls.Add(this.ShippingZipCode);
			this.Controls.Add(this.ShippingCountry);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnRetrieveById);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.OrderId);
			this.Controls.Add(this.cmbCustomers);
			this.Controls.Add(this.DeleteOrder);
			this.Controls.Add(this.UpdateOrder);
			this.Controls.Add(this.CreateOrder);
			this.Controls.Add(this.Details);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.AddDetail);
			this.Controls.Add(this.cmbProducts);
			this.Controls.Add(this.txtOrderDiscount);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.label30);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.txtOrderPrice);
			this.Controls.Add(this.txtOrderQuantity);
			this.Controls.Add(this.label29);
			this.Name = "CH6_7_8Orders";
			this.Text = "Main";
			this.Load += new System.EventHandler(this.CH6_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CreateOrder;
		private System.Windows.Forms.Button UpdateOrder;
		private System.Windows.Forms.Button DeleteOrder;
				private System.Windows.Forms.Label label26;
				private System.Windows.Forms.ComboBox cmbCustomers;
				private System.Windows.Forms.Button AddDetail;
				private System.Windows.Forms.TextBox txtOrderDiscount;
				private System.Windows.Forms.Label label30;
				private System.Windows.Forms.TextBox txtOrderPrice;
				private System.Windows.Forms.Label label29;
				private System.Windows.Forms.TextBox txtOrderQuantity;
				private System.Windows.Forms.Label label28;
				private System.Windows.Forms.Label label27;
				private System.Windows.Forms.ComboBox cmbProducts;
				private System.Windows.Forms.ListView Details;
				private System.Windows.Forms.ColumnHeader columnHeader1;
				private System.Windows.Forms.ColumnHeader columnHeader2;
				private System.Windows.Forms.ColumnHeader columnHeader3;
				private System.Windows.Forms.ColumnHeader columnHeader4;
				private System.Windows.Forms.Button btnRetrieveById;
				private System.Windows.Forms.Label label1;
				private System.Windows.Forms.TextBox OrderId;
				private System.Windows.Forms.TextBox ShippingAddress;
				private System.Windows.Forms.TextBox ShippingCity;
				private System.Windows.Forms.TextBox ShippingZipCode;
				private System.Windows.Forms.TextBox ShippingCountry;
				private System.Windows.Forms.Label label2;
				private System.Windows.Forms.Label label3;
				private System.Windows.Forms.Label label4;
				private System.Windows.Forms.Label label5;
				private System.Windows.Forms.Button RemoveSelected;
				private System.Windows.Forms.TextBox OrderDate;
				private System.Windows.Forms.Label label6;
				private System.Windows.Forms.TextBox EstimatedShippingDate;
				private System.Windows.Forms.Label label56;
				private System.Windows.Forms.TextBox ActualShippindDate;
				private System.Windows.Forms.Label label7;
				private System.Windows.Forms.Button btnDeleteDisconnected;
	}
}