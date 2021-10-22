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
    public partial class AddingProductType : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        public AddingProductType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);

            connection.Open();


            if (textBox1.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка добавления типа товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [TypesOfGoods] (Name) VALUES (@Name)", connection))
                    {
                        cmd1.Parameters.AddWithValue("@Name", textBox1.Text);

                        cmd1.ExecuteNonQuery();
                    }

                    MessageBox.Show("Успешное добавление типа товара!", "Тип товара добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления типа товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
