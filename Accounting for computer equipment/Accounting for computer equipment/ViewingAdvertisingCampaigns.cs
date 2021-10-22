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
    public partial class ViewingAdvertisingCampaigns : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        string name, description, addresses, phoneNumbers, services;

        public ViewingAdvertisingCampaigns()
        {
            InitializeComponent();

			SqlConnection connection = new SqlConnection(sql);
			connection.Open();

			List<String> name = new List<String>();
			using (SqlCommand cmd = new SqlCommand(@"SELECT Name FROM AdvertisingBrochures", connection))
			{
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					name.Add(reader.GetString(0));
				}
				reader.Close();
			}

			foreach (var item in name)
			{
				comboBox1.Items.Add(item);
			}

			connection.Close();
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = comboBox1.Text;

            try
            {
                SqlConnection connection = new SqlConnection(sql);
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Description FROM AdvertisingBrochures WHERE Name = @Name", connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    description = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Addresses FROM AdvertisingBrochures WHERE Name = @Name", connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    addresses = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 PhoneNumbers FROM AdvertisingBrochures WHERE Name = @Name", connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    phoneNumbers = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Services FROM AdvertisingBrochures WHERE Name = @Name", connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    services = cmd.ExecuteScalar().ToString();
                }

                connection.Close();

                textBox1.Text = name;
                richTextBox1.Text = description;
                richTextBox2.Text = addresses;
                richTextBox3.Text = phoneNumbers;
                richTextBox4.Text = services;
            }
            catch
            {
                MessageBox.Show("Ошибка просмотра информации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
