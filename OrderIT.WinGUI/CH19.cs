using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using OrderIT.Model;
using System.Configuration;
using System.Diagnostics;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data.Common;
using System.Data.Objects.SqlClient;

namespace OrderIT.WinGUI {
	public partial class CH19 : Form {
		Watch _watch;

		public CH19() {
			InitializeComponent();
			_watch = new Watch(Result);
		}

		private void button1_Click(object sender, EventArgs e) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				var c = ctx.Companies.ToTraceString();
			}
			using (OrderITEntities ctx = new OrderITEntities()) {
				for (int i = 0; i < 500; i++) {
					Customer c = new Customer {
						Name = "Customer" + i,
						BillingAddress = new AddressInfo {
							Address = "Address" + i,
							City = "City" + i,
							Country = "Country" + i,
							ZipCode = "ZC" + i
						},
						ShippingAddress = new AddressInfo {
							Address = "Address" + i,
							City = "City" + i,
							Country = "Country" + i,
							ZipCode = "ZC" + i
						},
						WSEnabled = false
					};
					ctx.Companies.AddObject(c);
					Supplier s = new Supplier {
						Name = "Supplier" + i,
						IBAN = "123456789012345678901234567",
						PaymentDays = 20,
					};
					ctx.Companies.AddObject(s);
				}
				_watch.Start("Insert 500 customers and 500 suppliers with EF");
				ctx.SaveChanges();
				_watch.Stop();
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			_watch.Start("Insert 500 customers and 500 suppliers with ADO.NET");
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderITEntitiesDB"].ConnectionString)) {
				conn.Open();
				using (SqlTransaction tr = conn.BeginTransaction()) {
					try {
						for (int i = 0; i < 1000; i++) {
							using (SqlCommand comm = new SqlCommand("", conn, tr)) {
								if (i % 2 == 0) {
									comm.CommandText = "insert [dbo].[Company]([Name], [BillingAddress], [BillingCity], [BillingZipCode], [BillingCountry], [ShippingAddress], [ShippingCity], [ShippingZipCode], " +
											"[ShippingCountry], [WSUserName], [WSPassword], [WSEnabled], [Type], [IBAN], [PaymentDays]) " +
											"values (@0, @1, @2, @3, @4, @5, @6, @7, @8, null, null, @9, @10, null, null); " +
											"select [CompanyId], [Version] from [dbo].[Company] where @@ROWCOUNT > 0 and [CompanyId] = scope_identity()";
									comm.Parameters.AddWithValue("0", "Customer998");
									comm.Parameters.AddWithValue("1", "Address998");
									comm.Parameters.AddWithValue("2", "City998");
									comm.Parameters.AddWithValue("3", "ZipCode998");
									comm.Parameters.AddWithValue("4", "Country998");
									comm.Parameters.AddWithValue("5", "Address998");
									comm.Parameters.AddWithValue("6", "City998");
									comm.Parameters.AddWithValue("7", "ZipCode998");
									comm.Parameters.AddWithValue("8", "Country998");
									comm.Parameters.AddWithValue("9", "0");
									comm.Parameters.AddWithValue("10", "C");
								}
								else {
									comm.CommandText = "insert [dbo].[Company]([Name], [BillingAddress], [BillingCity], [BillingZipCode], [BillingCountry], [ShippingAddress], [ShippingCity], [ShippingZipCode], " +
											"[ShippingCountry], [WSUserName], [WSPassword], [WSEnabled], [Type], [IBAN], [PaymentDays]) " +
											"values (@0, null, null, null, null, null, null, null, null, null, null, null, @1, @2, @3); " +
											"select [CompanyId], [Version] from [dbo].[Company] where @@ROWCOUNT > 0 and [CompanyId] = scope_identity()";
									comm.Parameters.AddWithValue("0", "Supplier998");
									comm.Parameters.AddWithValue("1", "S");
									comm.Parameters.AddWithValue("2", "123456789012345678901234567");
									comm.Parameters.AddWithValue("3", "20");
								}
								comm.ExecuteNonQuery();
							}

						}
						tr.Commit();
					}
					catch (Exception er){
						tr.Rollback();
					}
				}
			}
			_watch.Stop();
		}

		private void button3_Click(object sender, EventArgs e) {
			using (OrderITEntities ctx = new OrderITEntities()) {
				var items = ctx.Companies.Where(c => c.Name.StartsWith("Customer")).ToList();
				items.ForEach(c => c.Name += "New");
				_watch.Start("Update " + items.Count + " customers with EF");
				ctx.SaveChanges();
				_watch.Stop();
			}
		}

		private void button4_Click(object sender, EventArgs e) {
			List<Company> items;
			using (OrderITEntities ctx = new OrderITEntities()) {
				items = ctx.Companies.Where(c => c.Name.StartsWith("Customer")).ToList();
			}

			_watch.Start("Update " + items.Count + " customers with ADO.NET");
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderITEntitiesDB"].ConnectionString)) {
				conn.Open();
				using (SqlTransaction tr = conn.BeginTransaction()) {
					try {
						
						for (int i = 0; i < items.Count; i++) {
							using (SqlCommand comm = new SqlCommand("", conn, tr)) {
								comm.CommandText = "update [dbo].[Company] set [Name] = @name where companyid = @companyid and version = @version ";
								comm.Parameters.AddWithValue("name", items[i].Name + "New");
								comm.Parameters.AddWithValue("companyid", items[i].CompanyId);
								comm.Parameters.AddWithValue("version", items[i].Version);
								comm.ExecuteNonQuery();
							}

						}
						tr.Commit();
					}
					catch (Exception er) {
						tr.Rollback();
					}
				}
			}
			_watch.Stop();
		}

		private void button5_Click(object sender, EventArgs e) {
			string testType = "Select Customers with EF using L2E";
			testType += ". Tracking: " + EnableTracking.Checked;
			testType += ". Compiled Query: " + UseCompiledQuery.Checked;
			SelectCustomersViaObjectServices(testType, EnableTracking.Checked, UseCompiledQuery.Checked, enablePlanCaching.Checked, false);
		}

		private void button6_Click(object sender, EventArgs e) {
			_watch.Start("SELECT customers with ADO.NET");
			for (int i = 0; i < 50; i++) {
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderITEntitiesDB"].ConnectionString)) {
					conn.Open();
					using (SqlCommand comm = new SqlCommand("select * from company where type = 'C' and name like 'C%'", conn)) {
						using (SqlDataReader reader = comm.ExecuteReader()) {
							while (reader.Read()) {
								var x = reader.GetInt32(0);
								var x1 = reader.GetString(1);
								var x2 = reader.GetString(2);
								var x3 = reader.GetString(3);
								var x4 = reader.GetString(4);
								var x5 = reader.GetString(5);
								var x6 = reader.GetString(6);
								var x7 = reader.GetString(7);
								var x8 = reader.GetString(8);
								var x9 = reader.GetString(9);
								var x10 = reader.GetValue(10);
								var x11 = reader.GetValue(11);
								var x12 = reader.GetValue(12);
								var x13 = reader.GetSqlBinary(16);
							}
						}
					}
				}
				_watch.SaveLap();
			}
			_watch.Stop();
		}
	
		private void button7_Click(object sender, EventArgs e) {
			Result.Items.Clear();
		}

		static Func<OrderITEntities, string, IQueryable<Customer>> compQuery = CompiledQuery.Compile<OrderITEntities, string, IQueryable<Customer>>((ctx, name) =>
			ctx.Companies.OfType<Customer>().Where(c => c.Name.StartsWith(name))
		);

		private void SelectCustomersViaObjectServices(string testType, bool enableTracking, bool useCompiledQuery, bool enablePlanCaching, bool useEntitySQL) {
			_watch.Start(testType);
			for (int i = 0; i < 50; i++) {
				using (OrderITEntities ctx = new OrderITEntities()) {
					List<Customer> items;
					if (!enableTracking) ctx.Companies.MergeOption = MergeOption.NoTracking;
					if (!useEntitySQL) {
						if (useCompiledQuery){
							var it = compQuery.Invoke(ctx, "C").ToList();
							foreach (var item in it) {
								object o = item;
							}
						}
						else {
							string name = "C";
							items = ctx.Companies.OfType<Customer>().Where(c => c.Name.StartsWith(name)).ToList();
						}
					}
					else {
						var oq = ctx.CreateQuery<Customer>("SELECT VALUE c FROM OFTYPE(OrderITEntities.Companies, OrderIT.Model.Customer) AS c WHERE c.name LIKE @name");
						if (!enableTracking) oq.MergeOption = MergeOption.NoTracking;
						if (!enablePlanCaching) oq.EnablePlanCaching = false;
						oq.Parameters.Add(new ObjectParameter("name", "C%"));
						items = oq.ToList();
					}
				}
				_watch.SaveLap();
			}
			_watch.Stop();
		}

		private void button8_Click(object sender, EventArgs e) {
			string testType = "Select Customers With EF and EntitySQL via ObjectServices";
			testType += ". Tracking: " + EnableTracking.Checked;
			SelectCustomersViaObjectServices(testType, EnableTracking.Checked, UseCompiledQuery.Checked, enablePlanCaching.Checked, true);
		}

		private void button9_Click(object sender, EventArgs e) {
			string testType = "Select Customers With EF and EntitySQL via Entity Client. Plan Cache Enabled: " + UseCompiledQuery.Checked;
			_watch.Start(testType);
			for (int i = 0; i < 50; i++) {
				using (EntityConnection conn = new EntityConnection(ConfigurationManager.ConnectionStrings["OrderITEntities"].ConnectionString)) {
					conn.Open();
					using (EntityCommand comm = new EntityCommand("SELECT VALUE c FROM OFTYPE(OrderITEntities.Companies, OrderITModel.Customer) AS c WHERE c.name LIKE @name", conn)) {
						comm.EnablePlanCaching = enablePlanCaching.Checked;
						comm.Parameters.AddWithValue("name", "C%");
						using (EntityDataReader reader = comm.ExecuteReader(CommandBehavior.SequentialAccess)) {
							while (reader.Read()) {
								var x = reader.GetValue(0);
								var x1 = reader.GetValue(1);
								var x2 = reader.GetValue(2);
								var x3 = reader.GetValue(3);
								var x4 = reader.GetValue(4);
							}
						}
					}
				}
				_watch.SaveLap();
			}
			_watch.Stop();
		}

		private class Watch {
			Stopwatch _sw;
			ListView _result;
			string _testType;
			List<long> _laps;

			public Watch(ListView result) {
				_result = result;
			}

			public void Start(string testType) {
				_testType = testType;
				_laps = new List<long>();
				_sw = new Stopwatch();
				_sw.Start();
			}

			public void SaveLap() {
				_laps.Add(_sw.ElapsedMilliseconds);
			}

			public void Stop() {
				_sw.Stop();
				if (_laps.Count > 0) {
					string[] localTimes = new string[_laps.Count-1];
					for (int i = 1; i < _laps.Count-1; i++) {
						localTimes[i-1] = (_laps[i] - _laps[i - 1]).ToString();
					}
					_result.Items.Add(new ListViewItem(new[] { _testType, _sw.ElapsedMilliseconds.ToString(), ((double)_sw.ElapsedMilliseconds / (double)_laps.Count).ToString(), _laps[0].ToString(), String.Join(", ", localTimes) }));
				}
				else
					_result.Items.Add(new ListViewItem(new[] { _testType, _sw.ElapsedMilliseconds.ToString(), _sw.ElapsedMilliseconds.ToString(), "0", String.Empty }));
			}
		}

		private void button10_Click(object sender, EventArgs e) {
		}

		private void button11_Click(object sender, EventArgs e) {
			_watch.Start("Warmup");
			using (OrderITEntities ctx = new OrderITEntities()) {
				var c = ctx.Companies.ToList();
			}
			_watch.Stop();
		}

		private void button12_Click(object sender, EventArgs e) {
			Application.Restart();
		}

		private void button13_Click(object sender, EventArgs e) {
			_watch.Start("SELECT customers with ADO.NET");
			for (int i = 0; i < 50; i++) {
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderITEntitiesDB"].ConnectionString)) {
					conn.Open();
					using (SqlCommand comm = new SqlCommand("GetCustomersForTest", conn)) {
						comm.CommandType = CommandType.StoredProcedure;
						comm.Parameters.AddWithValue("name", "C%");
						using (SqlDataReader reader = comm.ExecuteReader()) {
							while (reader.Read()) {
								var x = reader.GetValue(0);
								var x1 = reader.GetValue(1);
								var x2 = reader.GetValue(2);
								var x3 = reader.GetValue(3);
							}
						}
					}
				}
				_watch.SaveLap();
			}
			_watch.Stop();
		}

		private void button14_Click(object sender, EventArgs e) {
			string testType = "Stored Procedure via Entity Client";
			_watch.Start(testType);
			for (int i = 0; i < 50; i++) {
				using (EntityConnection conn = new EntityConnection(ConfigurationManager.ConnectionStrings["OrderITEntities"].ConnectionString)) {
					conn.Open();
					using (EntityCommand comm = new EntityCommand("OrderITEntities.GetCustomersForTest", conn)) {
						comm.CommandType = CommandType.StoredProcedure;
						comm.Parameters.AddWithValue("name", "C%");
						using (EntityDataReader reader = comm.ExecuteReader(CommandBehavior.SequentialAccess)) {
							while (reader.Read()) {
								var x = reader.GetValue(0);
								var x1 = reader.GetValue(1);
								var x2 = reader.GetValue(2);
								var x3 = reader.GetValue(3);
								var x4 = reader.GetValue(4);
							}
						}
					}
				}
				_watch.SaveLap();
			}
			_watch.Stop();
		}

		private void button15_Click(object sender, EventArgs e) {
			_watch.Start("linq with manual connection");
			for (int i = 0; i < 50; i++) {
				using (EntityConnection conn = new EntityConnection(ConfigurationManager.ConnectionStrings["OrderITEntities"].ConnectionString)) {
					conn.Open();
					using (OrderITEntities ctx = new OrderITEntities(conn)) {
						var items = ctx.Companies.OfType<Customer>().Execute(MergeOption.AppendOnly);
						var items1 = ctx.Companies.OfType<Supplier>().Execute(MergeOption.AppendOnly);
						var items2 = ctx.Products.Execute(MergeOption.AppendOnly);
						var items3 = ctx.Orders.Execute(MergeOption.AppendOnly);
					}
					_watch.SaveLap();
				}
			}
			_watch.Stop();

			_watch.Start("linq without manual connection");
			for (int i = 0; i < 50; i++) {
				using (OrderITEntities ctx = new OrderITEntities()) {
					var items = ctx.Companies.OfType<Customer>().Execute(MergeOption.AppendOnly);
					var items1 = ctx.Companies.OfType<Supplier>().Execute(MergeOption.AppendOnly);
					var items2 = ctx.Products.Execute(MergeOption.AppendOnly);
					var items3 = ctx.Orders.Execute(MergeOption.AppendOnly);
				}
				_watch.SaveLap();
			}
			_watch.Stop();

			_watch.Start("first");
			for (int i = 0; i < 50; i++) {
				using (OrderITEntities ctx = new OrderITEntities()) {
					var items = ctx.Companies.First(f => f.CompanyId == 3);
				}
				_watch.SaveLap();
			}
			_watch.Stop();

			_watch.Start("single");
			for (int i = 0; i < 50; i++) {
				using (OrderITEntities ctx = new OrderITEntities()) {
					var items = ctx.Companies.Single(f => f.CompanyId == 3);
				}
				_watch.SaveLap();
			}
			_watch.Stop();

			_watch.Start("sql with manual connection");
			for (int i = 0; i < 50; i++) {
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OrderITEntitiesDB"].ConnectionString)) {
					conn.Open();
					using (SqlCommand comm = new SqlCommand("SELECT * FROM Company where type = 'C'", conn)) {
						using (SqlDataReader reader = comm.ExecuteReader()) {
							while (reader.Read()) {
								var x3 = reader.GetValue(0);
							}
						}
					}

					using (SqlCommand comm = new SqlCommand("SELECT * FROM Company where type = 'S'", conn)) {
						using (SqlDataReader reader = comm.ExecuteReader()) {
							while (reader.Read()) {
								var x3 = reader.GetValue(0);
							}
						}
					}

					using (SqlCommand comm = new SqlCommand("SELECT * FROM [order]", conn)) {
						using (SqlDataReader reader = comm.ExecuteReader()) {
							while (reader.Read()) {
								var x3 = reader.GetValue(0);
							}
						}
					}

					using (SqlCommand comm = new SqlCommand("SELECT * FROM product p left join shirt s on (p.productid = s.productid) left join shoe sh on (p.productid = sh.productid)", conn)) {
						using (SqlDataReader reader = comm.ExecuteReader()) {
							while (reader.Read()) {
								var x3 = reader.GetValue(0);
							}
						}
					}
				}
				_watch.SaveLap();
			}
			_watch.Stop();
		}
	}
}