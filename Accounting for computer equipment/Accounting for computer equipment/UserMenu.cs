using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_for_computer_equipment
{
    public partial class UserMenu : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        string id;

        SqlDataAdapter adapter, adapter1 = null;
        DataTable table = null;

        public UserMenu(string id)
        {
            InitializeComponent();

            this.id = id;
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа: Учет компьютерной техники и периферийных устройств\nРазработчик: Фомов Максим Александрович\nНомер группы: 38ТП", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void личнаяИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form personalInformation = new PersonalInformation(id);
            personalInformation.ShowDialog();
        }

        private void сменаПароляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string password;

            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Password FROM Users WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                password = cmd.ExecuteScalar().ToString();
            }
            Form passwordChange = new PasswordChange(password, id);
            passwordChange.ShowDialog();

            connection.Close();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form authorization = new Authorization();
            Hide();
            authorization.Show();
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ShoppingCart WHERE UserID = @UserID; ", connection))
            {
                cmd.Parameters.AddWithValue("@UserID", id);
                adapter = new SqlDataAdapter(cmd);
                table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

            connection.Close();

            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet5.Goods". При необходимости она может быть перемещена или удалена.
            this.goodsTableAdapter.Fill(this.databaseDataSet5.Goods);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form informationAboutProducts = new InformationAboutProducts(textBox4.Text);
            informationAboutProducts.ShowDialog();
        }

        private void добавитьВКорзинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addingToCart = new AddingToCart(id);
            addingToCart.ShowDialog();
        }

        private void удалитьИзКорзиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form deleteItemsFromCart = new DeleteItemsFromCart(id);
            deleteItemsFromCart.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form informationAboutOrder = new InformationAboutOrder(textBox1.Text);
            informationAboutOrder.ShowDialog();
        }

        private void компаниипродавцыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form viewingAdvertisingCampaigns = new ViewingAdvertisingCampaigns();
            viewingAdvertisingCampaigns.ShowDialog();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            this.databaseDataSet5.Goods.Clear();
            this.databaseDataSet6.ShoppingCart.Clear();

            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Goods; ", connection))
            {
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(this.databaseDataSet5.Goods);
                dataGridView1.DataSource = this.databaseDataSet5.Goods;
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ShoppingCart WHERE UserID = @UserID; ", connection))
            {
                cmd.Parameters.AddWithValue("@UserID", id);
                adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(this.databaseDataSet6.ShoppingCart);
                dataGridView2.DataSource = this.databaseDataSet6.ShoppingCart;
            }

            connection.Close();
        }
    }
}
