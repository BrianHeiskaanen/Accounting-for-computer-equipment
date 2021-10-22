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
    public partial class DeleteAdvertisement : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        SqlDataAdapter adapter = null;
        DataTable table = null;

        public DeleteAdvertisement()
        {
            InitializeComponent();
        }

        private void DeleteAdvertisement_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM AdvertisingBrochures; ", connection))
            {
                adapter = new SqlDataAdapter(cmd);
                table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM AdvertisingBrochures WHERE id = @id; ", connection))
                {
                    cmd.Parameters.AddWithValue("@id", textBox8.Text);
                    adapter = new SqlDataAdapter(cmd);
                    table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }

                MessageBox.Show("Успешное удаление рекламного буклета!", "Рекламный буклет удален", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления рекламного буклета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form informationAboutAdvertisement = new InformationAboutAdvertisement(textBox1.Text);
            informationAboutAdvertisement.ShowDialog();
        }
    }
}
