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
    public partial class AddingToCart : Form
    {
		string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        string id, name, description, type, quantity, price, manufacturer, supplier;

        string userID;

        private void button9_Click(object sender, EventArgs e)
        {
            Form informationAboutProducts = new InformationAboutProducts(textBox2.Text);
            informationAboutProducts.ShowDialog();
        }

        int priceInt, quantityInt;

        public AddingToCart(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void AddingToCart_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet7.Goods". При необходимости она может быть перемещена или удалена.
            this.goodsTableAdapter.Fill(this.databaseDataSet7.Goods);
        }

        private void button10_Click(object sender, EventArgs e)
        {
			SqlConnection connection = new SqlConnection(sql);

			connection.Open();

            if(textBox4.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка добавления товара в корзину", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                id = textBox1.Text;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Name FROM Goods WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        name = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Description FROM Goods WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        description = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Type FROM Goods WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        type = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Price FROM Goods WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        price = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Manufacturer FROM Goods WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        manufacturer = cmd.ExecuteScalar().ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Supplier FROM Goods WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        supplier = cmd.ExecuteScalar().ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка просмотра информации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }

                quantityInt = Convert.ToInt32(textBox4.Text);
                priceInt = Convert.ToInt32(price);
                priceInt = priceInt * quantityInt;
                price = Convert.ToString(priceInt);
                quantity = Convert.ToString(quantityInt);

                try
                {
                    connection.Open();

                    using (SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [ShoppingCart] (Name, Description, Type, Quantity, Price, Manufacturer, Supplier, UserID) VALUES (@Name, @Description, @Type, @Quantity, @Price, @Manufacturer, @Supplier, @UserID)", connection))
                    {
                        cmd1.Parameters.AddWithValue("@Name", name);
                        cmd1.Parameters.AddWithValue("@Description", description);
                        cmd1.Parameters.AddWithValue("@Type", type);
                        cmd1.Parameters.AddWithValue("@Quantity", quantity);
                        cmd1.Parameters.AddWithValue("@Price", price);
                        cmd1.Parameters.AddWithValue("@Manufacturer", manufacturer);
                        cmd1.Parameters.AddWithValue("@Supplier", supplier);
                        cmd1.Parameters.AddWithValue("@UserID", userID);

                        cmd1.ExecuteNonQuery();
                    }

                    MessageBox.Show("Успешное добавление товара в корзину!", "Товар добавлен в корзину", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления товара в корзину!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
