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
    public partial class InformationAboutProducts : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        string id, name, description, type, price, manufacturer, supplier;

        public InformationAboutProducts(string id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void InformationAboutProducts_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(sql);
                connection.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Name FROM Goods WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    name = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Description FROM Goods WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    description = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Type FROM Goods WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    type = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Price FROM Goods WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    price = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Manufacturer FROM Goods WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    manufacturer = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Supplier FROM Goods WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    supplier = cmd.ExecuteScalar().ToString();
                }

                connection.Close();

                textBox1.Text = name;
                richTextBox1.Text = description;
                textBox3.Text = type;
                textBox4.Text = price;
                textBox5.Text = manufacturer;
                textBox6.Text = supplier;
            }
            catch
            {
                MessageBox.Show("Ошибка просмотра информации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
