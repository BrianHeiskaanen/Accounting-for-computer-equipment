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
    public partial class AddingAdvertisement : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        public AddingAdvertisement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			SqlConnection connection = new SqlConnection(sql);

			connection.Open();


			if (textBox1.Text == "" || richTextBox1.Text == "" || richTextBox2.Text == "" || richTextBox3.Text == "" || richTextBox4.Text == "")
			{
				MessageBox.Show("Не все поля заполнены!", "Ошибка добавления рекламного буклета", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				try
				{
					using (SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [AdvertisingBrochures] (Name, Description, Addresses, PhoneNumbers, Services) VALUES (@Name, @Description, @Addresses, @PhoneNumbers, @Services)", connection))
					{
						cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
						cmd1.Parameters.AddWithValue("@Description", richTextBox1.Text);
						cmd1.Parameters.AddWithValue("@Addresses", richTextBox2.Text);
						cmd1.Parameters.AddWithValue("@PhoneNumbers", richTextBox3.Text);
						cmd1.Parameters.AddWithValue("@Services", richTextBox4.Text);

						cmd1.ExecuteNonQuery();
					}

					MessageBox.Show("Успешное добавление рекламного буклета!", "Рекламный буклет добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch
				{
					MessageBox.Show("Ошибка добавления рекламного буклета!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
