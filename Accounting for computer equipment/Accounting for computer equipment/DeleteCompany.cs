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
    public partial class DeleteCompany : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        SqlDataAdapter adapter = null;
        DataTable table = null;

        int check;

        public DeleteCompany(int check)
        {
            InitializeComponent();

            this.check = check;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            try
            {
                if(check == 1)
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ManufacturingCompanies WHERE id = @id; ", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", textBox8.Text);
                        adapter = new SqlDataAdapter(cmd);
                        table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM SupplierCompanies WHERE id = @id; ", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", textBox8.Text);
                        adapter = new SqlDataAdapter(cmd);
                        table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }

                MessageBox.Show("Успешное удаление фирмы!", "Фирма удалена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления фирмы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form companyInformation = new CompanyInformation(textBox1.Text, check);
            companyInformation.ShowDialog();
        }

        private void DeleteCompany_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            if(check == 1)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ManufacturingCompanies; ", connection))
                {
                    adapter = new SqlDataAdapter(cmd);
                    table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SupplierCompanies; ", connection))
                {
                    adapter = new SqlDataAdapter(cmd);
                    table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }

            connection.Close();
        }
    }
}
