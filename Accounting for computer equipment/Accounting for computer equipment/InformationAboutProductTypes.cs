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
    public partial class InformationAboutProductTypes : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        string id, name;

        public InformationAboutProductTypes(string id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void InformationAboutProductTypes_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(sql);
                connection.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Name FROM TypesOfGoods WHERE id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    name = cmd.ExecuteScalar().ToString();
                }

                connection.Close();

                textBox1.Text = name;
            }
            catch
            {
                MessageBox.Show("Ошибка просмотра информации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
