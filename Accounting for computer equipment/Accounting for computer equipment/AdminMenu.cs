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
    public partial class AdminMenu : Form
    {
        SqlDataAdapter adapter, adapter1, adapter2, adapter3, adapter4 = null;

        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        public AdminMenu()
        {
            InitializeComponent();
        }

        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            this.databaseDataSet.Users.Clear();
            this.databaseDataSet1.ManufacturingCompanies.Clear();
            this.databaseDataSet2.SupplierCompanies.Clear();
            this.databaseDataSet3.TypesOfGoods.Clear();
            this.databaseDataSet41.Goods.Clear();

            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users; ", connection))
            {
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(this.databaseDataSet.Users);
                dataGridView1.DataSource = this.databaseDataSet.Users;
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ManufacturingCompanies; ", connection))
            {
                adapter1 = new SqlDataAdapter(cmd);
                adapter1.Fill(this.databaseDataSet1.ManufacturingCompanies);
                dataGridView2.DataSource = this.databaseDataSet1.ManufacturingCompanies;
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM SupplierCompanies; ", connection))
            {
                adapter2 = new SqlDataAdapter(cmd);
                adapter2.Fill(this.databaseDataSet2.SupplierCompanies);
                dataGridView3.DataSource = this.databaseDataSet2.SupplierCompanies;
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM TypesOfGoods; ", connection))
            {
                adapter3 = new SqlDataAdapter(cmd);
                adapter3.Fill(this.databaseDataSet3.TypesOfGoods);
                dataGridView4.DataSource = this.databaseDataSet3.TypesOfGoods;
            }

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Goods; ", connection))
            {
                adapter4 = new SqlDataAdapter(cmd);
                adapter4.Fill(this.databaseDataSet41.Goods);
                dataGridView5.DataSource = this.databaseDataSet41.Goods;
            }

            connection.Close();
        }

        private void доабвитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addingCompany = new AddingCompany(1);
            addingCompany.ShowDialog();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addingCompany = new AddingCompany(2);
            addingCompany.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.databaseDataSet2.HasChanges(DataRowState.Modified)) return;
                DataSet tempDataSet = databaseDataSet2.GetChanges(DataRowState.Modified);
                adapter2.UpdateCommand = new SqlCommandBuilder(adapter2).GetUpdateCommand();
                adapter2.Update(tempDataSet, "SupplierCompanies");
            }
            catch
            {
                MessageBox.Show("Вы уже обновили данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.databaseDataSet3.HasChanges(DataRowState.Modified)) return;
                DataSet tempDataSet = databaseDataSet3.GetChanges(DataRowState.Modified);
                adapter3.UpdateCommand = new SqlCommandBuilder(adapter3).GetUpdateCommand();
                adapter3.Update(tempDataSet, "TypesOfGoods");
            }
            catch
            {
                MessageBox.Show("Вы уже обновили данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.databaseDataSet41.HasChanges(DataRowState.Modified)) return;
                DataSet tempDataSet = databaseDataSet41.GetChanges(DataRowState.Modified);
                adapter4.UpdateCommand = new SqlCommandBuilder(adapter4).GetUpdateCommand();
                adapter4.Update(tempDataSet, "Goods");
            }
            catch
            {
                MessageBox.Show("Вы уже обновили данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form addingProductType = new AddingProductType();
            addingProductType.ShowDialog();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form addingProduct = new AddingProduct();
            addingProduct.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form companyInformation = new CompanyInformation(textBox1.Text, 1);
            companyInformation.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form companyInformation = new CompanyInformation(textBox2.Text, 2);
            companyInformation.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form deleteCompany = new DeleteCompany(1);
            deleteCompany.ShowDialog();
        }

        private void удалитььToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form deleteCompany = new DeleteCompany(2);
            deleteCompany.ShowDialog();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form deleteProductTypes = new DeleteProductTypes();
            deleteProductTypes.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form informationAboutProductTypes = new InformationAboutProductTypes(textBox3.Text);
            informationAboutProductTypes.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа: Учет компьютерной техники и периферийных устройств\nРазработчик: Фомов Максим Александрович\nНомер группы: 38ТП", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void удалитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form deleteProduct = new DeleteProduct();
            deleteProduct.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form informationAboutProducts = new InformationAboutProducts(textBox4.Text);
            informationAboutProducts.ShowDialog();
        }

        private void добавитьФирмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addingAdvertisement = new AddingAdvertisement();
            addingAdvertisement.ShowDialog();
        }

        private void удалитьФирмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form deleteAdvertisement = new DeleteAdvertisement();
            deleteAdvertisement.ShowDialog();
        }

        private void посмотретьФирмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form changeAdvertisement = new ChangeAdvertisement();
            changeAdvertisement.ShowDialog();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form authorization = new Authorization();
            Hide();
            authorization.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.databaseDataSet1.HasChanges(DataRowState.Modified)) return;
                DataSet tempDataSet = databaseDataSet1.GetChanges(DataRowState.Modified);
                adapter1.UpdateCommand = new SqlCommandBuilder(adapter1).GetUpdateCommand();
                adapter1.Update(tempDataSet, "ManufacturingCompanies");
            }
            catch
            {
                MessageBox.Show("Вы уже обновили данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet41.Goods". При необходимости она может быть перемещена или удалена.
            this.goodsTableAdapter1.Fill(this.databaseDataSet41.Goods);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet3.TypesOfGoods". При необходимости она может быть перемещена или удалена.
            this.typesOfGoodsTableAdapter.Fill(this.databaseDataSet3.TypesOfGoods);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet2.SupplierCompanies". При необходимости она может быть перемещена или удалена.
            this.supplierCompaniesTableAdapter.Fill(this.databaseDataSet2.SupplierCompanies);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet1.ManufacturingCompanies". При необходимости она может быть перемещена или удалена.
            this.manufacturingCompaniesTableAdapter.Fill(this.databaseDataSet1.ManufacturingCompanies);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.databaseDataSet.Users);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form personalInformation = new PersonalInformation(textBox8.Text);
            personalInformation.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.databaseDataSet.HasChanges(DataRowState.Modified)) return;
                DataSet tempDataSet = databaseDataSet.GetChanges(DataRowState.Modified);
                adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
                adapter.Update(tempDataSet, "Users");
            }
            catch
            {
                MessageBox.Show("Вы уже обновили данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
