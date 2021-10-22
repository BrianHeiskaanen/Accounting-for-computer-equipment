using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_for_computer_equipment
{
    public partial class AddingProduct : Form
    {
		string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

		public AddingProduct()
        {
            InitializeComponent();

			SqlConnection connection = new SqlConnection(sql);
			connection.Open();

			List<String> typeName = new List<String>();
			using (SqlCommand cmd = new SqlCommand(@"SELECT Name FROM TypesOfGoods", connection))
			{
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					typeName.Add(reader.GetString(0));
				}
				reader.Close();
			}

			foreach (var item in typeName)
			{
				comboBox1.Items.Add(item);
			}


			List<String> manufacturingCompanies = new List<String>();
			using (SqlCommand cmd = new SqlCommand(@"SELECT Name FROM ManufacturingCompanies", connection))
			{
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					manufacturingCompanies.Add(reader.GetString(0));
				}
				reader.Close();
			}

			foreach (var item in manufacturingCompanies)
			{
				comboBox2.Items.Add(item);
			}

			List<String> supplierCompanies = new List<String>();
			using (SqlCommand cmd = new SqlCommand(@"SELECT Name FROM SupplierCompanies", connection))
			{
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					supplierCompanies.Add(reader.GetString(0));
				}
				reader.Close();
			}

			foreach (var item in supplierCompanies)
			{
				comboBox3.Items.Add(item);
			}

			connection.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
			SqlConnection connection = new SqlConnection(sql);

			connection.Open();


			if (textBox1.Text == "" || richTextBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
			{
				MessageBox.Show("Не все поля заполнены!", "Ошибка добавления товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				try
				{
					using (SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [Goods] (Name, Description, Type, Price, Manufacturer, Supplier) VALUES (@Name, @Description, @Type, @Price, @Manufacturer, @Supplier)", connection))
					{
						cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
						cmd1.Parameters.AddWithValue("@Description", richTextBox1.Text);
						cmd1.Parameters.AddWithValue("@Type", comboBox1.Text);
						cmd1.Parameters.AddWithValue("@Price", textBox2.Text);
						cmd1.Parameters.AddWithValue("@Manufacturer", comboBox2.Text);
						cmd1.Parameters.AddWithValue("@Supplier", comboBox3.Text);

						cmd1.ExecuteNonQuery();
					}

					MessageBox.Show("Успешное добавление товара!", "Товар добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch
				{
					MessageBox.Show("Ошибка добавления товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					connection.Close();
					Close();
				}
			}
		}
    }
}
