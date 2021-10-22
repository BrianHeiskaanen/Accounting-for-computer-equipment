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
    public partial class AddingCompany : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        int check;

        public AddingCompany(int check)
        {
            InitializeComponent();

            this.check = check;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);

            connection.Open();


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка добавления фирмы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (check == 1)
                    {
                        using (SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [ManufacturingCompanies] (Name, Address, PhoneNumber) VALUES (@Name, @Address, @PhoneNumber)", connection))
                        {
                            cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
                            cmd1.Parameters.AddWithValue("@Address", textBox2.Text);
                            cmd1.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);

                            cmd1.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [SupplierCompanies] (Name, Address, PhoneNumber) VALUES (@Name, @Address, @PhoneNumber)", connection))
                        {
                            cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
                            cmd1.Parameters.AddWithValue("@Address", textBox2.Text);
                            cmd1.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);

                            cmd1.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Успешное добавление фирмы!", "Фирма добавлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления фирмы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
