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
    public partial class CompanyInformation : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        int check;
        string id, name, address, phoneNumber;

        private void CompanyInformation_Load(object sender, EventArgs e)
        {
            try
            {
                if(check == 1)
                {
                    SqlConnection connection = new SqlConnection(sql);
                    connection.Open();


                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Name FROM ManufacturingCompanies WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        name = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Address FROM ManufacturingCompanies WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        address = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 PhoneNumber FROM ManufacturingCompanies WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        phoneNumber = cmd.ExecuteScalar().ToString();
                    }

                    connection.Close();

                    textBox1.Text = name;
                    textBox2.Text = address;
                    textBox3.Text = phoneNumber;
                }
                else
                {
                    SqlConnection connection = new SqlConnection(sql);
                    connection.Open();


                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Name FROM SupplierCompanies WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        name = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Address FROM SupplierCompanies WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        address = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 PhoneNumber FROM SupplierCompanies WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        phoneNumber = cmd.ExecuteScalar().ToString();
                    }

                    connection.Close();

                    textBox1.Text = name;
                    textBox2.Text = address;
                    textBox3.Text = phoneNumber;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка просмотра информации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public CompanyInformation(string id, int check)
        {
            InitializeComponent();

            this.id = id;
            this.check = check;
        }
    }
}
