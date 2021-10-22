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
    public partial class InformationAboutAdvertisement : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        string id, name, description, addresses, phoneNumbers, services;

        private void InformationAboutAdvertisement_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(sql);
                connection.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Name FROM AdvertisingBrochures WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    name = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Description FROM AdvertisingBrochures WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    description = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Addresses FROM AdvertisingBrochures WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    addresses = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 PhoneNumbers FROM AdvertisingBrochures WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    phoneNumbers = cmd.ExecuteScalar().ToString();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Services FROM AdvertisingBrochures WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
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

        public InformationAboutAdvertisement(string id)
        {
            InitializeComponent();
            this.id = id;
        }
    }
}
