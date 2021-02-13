using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OrderIT.Model;
using System.Diagnostics;

namespace OrderIT.WinGUI {
	public partial class Main : Form {
		public Main() {
			InitializeComponent();
		}


		private void customerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ch = new CH6_7_8Customers())
			{
				ch.ShowDialog();
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			using (var ch = new AppB())
			{
				ch.ShowDialog();
			}
		}

		private void toolStripButton7_Click(object sender, EventArgs e)
		{
			using (var ch = new CH19())
			{
				ch.ShowDialog();
			}
		}

		private void toolStripButton6_Click(object sender, EventArgs e)
		{
			using (var ch = new CH17())
			{
				ch.ShowDialog();
			}
		}

		private void toolStripButton5_Click(object sender, EventArgs e)
		{
			using (var ch = new CH12())
			{
				ch.ShowDialog();
			}
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			using (var ch = new CH10_11())
			{
				ch.ShowDialog();
			}
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			using (var ch = new CH9())
			{
				ch.ShowDialog();
			}
		}

		private void suppToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ch = new CH6_7_8Suppliers())
			{
				ch.ShowDialog();
			}
		}

		private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ch = new CH6_7_8Orders())
			{
				ch.ShowDialog();
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			using (var ch = new CH4())
			{
				ch.ShowDialog();
			}
		}

		private void ordersAndIndependentAssociationsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ch = new CH6_7_8OrdersIA())
			{
				ch.ShowDialog();
			}
		}

		private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ch = new CH16Customer())
			{
				ch.ShowDialog();
			}
		}

		private void updateOrderToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void updateCustomerToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			using (var ch = new CH16CustomerDTO())
			{
				ch.ShowDialog();
			}
		}

		private void updateCustomerToolStripMenuItem_Click_2(object sender, EventArgs e)
		{
			using (var ch = new CH16CustomerSTE())
			{
				ch.ShowDialog();
			}
		}
	}
}
