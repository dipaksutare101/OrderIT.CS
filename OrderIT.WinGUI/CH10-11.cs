using System;
using System.Xml.XPath;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.Model;
using System.Data.Metadata.Edm;
using System.Xml.Linq;
using System.IO;
using System.Data.Entity.Design;
using System.Xml;
using System.Data.Common;
using System.Data.EntityClient;
using SampleSupport;

namespace OrderIT.WinGUI
{
	public partial class CH10_11 : Form
	{
		/*
		//var ex = ctx.GetCompanies();
		/*Order o = new Order();
		o.CustomerId = 1;
		o.OrderDate = DateTime.Now;
		o.ShippingAddress = new AddressInfo() { Address = "V", City = "C", Country = "CO", ZipCode = "000" };
		o.OrderDetails.Add(new OrderDetail() { Discount = 0, ProductId = 1, Quantity = 4, UnitPrice = 10 });
		o.OrderDetails.Add(new OrderDetail() { Discount = 0, ProductId = 2, Quantity = 3, UnitPrice = 20 });
		ctx.Orders.AddObject(o);
		ctx.SaveChanges();*/
		public CH10_11()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				//var result = (from c in ctx.Orders select new { c.OrderId, Amount = c.OrderDetails.Sum(d => OrderITEntities.GetTotalAmount(d.UnitPrice, d.Quantity, d.Discount)) }).ToList();
				//Dump(result);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId,  SUM(SELECT VALUE OrderITModel.GetUDFTotalAmount(d.UnitPrice, d.Quantity, d.Discount) FROM o.OrderDetails As d) FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void Dump(object p)
		{
			ObjectDumper.Write(p, treeView1, textBox1);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = (from c in ctx.Orders select new { c.OrderId, Amount = c.OrderDetails.Sum(d => OrderITEntities.GetUDFTotalAmount(d.UnitPrice, d.Quantity, d.Discount)) }).ToList();
				Dump(result);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = (from c in ctx.Orders select new { c.OrderId, Amount = c.OrderDetails.Sum(d => OrderITEntities.GetUDFTotalAmountWithObjectParameter(d)) }).ToList();
				Dump(result);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = ctx.CreateQuery<DbDataRecord>("SELECT o.OrderId, SUM(SELECT VALUE OrderITModel.GetUDFTotalAmountWithObjectParameter(d) FROM o.OrderDetails As d) FROM OrderITEntities.Orders AS o");
				Dump(result);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = (from c in ctx.Companies.OfType<Customer>() select OrderITEntities.GetUDFAddresses(c)).ToList();
				Dump(result);
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = ctx.CreateQuery<DbDataRecord>("SELECT OrderITModel.GetUDFAddresses(c) FROM OFTYPE(OrderITEntities.Companies, OrderIT.Model.Customer) As c");
				Dump(result);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = ctx.CreateQuery<CustomerProjection>("SELECT VALUE OrderIT.Model.CustomerProjection(detail.Name, detail.BillingAddress.Address, detail.BillingAddress.City, detail.ShippingAddress.Address, detail.ShippingAddress.City) FROM OFTYPE(OrderITEntities.Companies, OrderIT.Model.Customer) As detail").ToList();
				Dump(result);
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = (from c in ctx.Companies.OfType<Customer>() select OrderITEntities.GetUDFTypedAddresses(c)).ToList();
				Dump(result);
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = (from c in ctx.Orders select new { c.OrderId, Details = OrderITEntities.GetUDFDetailsWithNoDiscount_Scalar(c) }).ToList();
				Dump(result);
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = (from c in ctx.Orders select new { c.OrderId, Details = OrderITEntities.GetUDFDetailsWithNoDiscount_Record(c) }).ToList();
				Dump(result);
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			using (var ctx = new OrderITEntities())
			{
				var result = (from c in ctx.Orders select new { c.OrderId, Details = OrderITEntities.GetUDFDetailsWithNoDiscount_Object(c) }).ToList();
				Dump(result);
			}
		}
	}
}