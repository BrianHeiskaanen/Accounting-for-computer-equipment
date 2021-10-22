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
    public partial class ChangeAdvertisement : Form
    {
        string sql = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maksi\OneDrive\Desktop\Accounting for computer equipment\Accounting for computer equipment\Database.mdf;Integrated Security=True";

        SqlDataAdapter adapter = null;

        public ChangeAdvertisement()
        {
            InitializeComponent();
        }

        private void ChangeAdvertisement_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet9.AdvertisingBrochures". При необходимости она может быть перемещена или удалена.
            this.advertisingBrochuresTableAdapter.Fill(this.databaseDataSet9.AdvertisingBrochures);

            this.databaseDataSet9.AdvertisingBrochures.Clear();

            SqlConnection connection = new SqlConnection(sql);
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM AdvertisingBrochures; ", connection))
            {
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(this.databaseDataSet9.AdvertisingBrochures);
                dataGridView1.DataSource = this.databaseDataSet9.AdvertisingBrochures;
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form informationAboutAdvertisement = new InformationAboutAdvertisement(textBox8.Text);
            informationAboutAdvertisement.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.databaseDataSet9.HasChanges(DataRowState.Modified)) return;
                DataSet tempDataSet = databaseDataSet9.GetChanges(DataRowState.Modified);
                adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
                adapter.Update(tempDataSet, "AdvertisingBrochures");
            }
            catch
            {
                MessageBox.Show("Вы уже обновили данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
