
namespace Accounting_for_computer_equipment
{
    partial class ChangeAdvertisement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.databaseDataSet9 = new Accounting_for_computer_equipment.DatabaseDataSet9();
            this.advertisingBrochuresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.advertisingBrochuresTableAdapter = new Accounting_for_computer_equipment.DatabaseDataSet9TableAdapters.AdvertisingBrochuresTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumbersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advertisingBrochuresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button2.Location = new System.Drawing.Point(739, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 40);
            this.button2.TabIndex = 74;
            this.button2.Text = "Посмотреть информацию";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox8.Location = new System.Drawing.Point(828, 61);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(95, 29);
            this.textBox8.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(669, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 24);
            this.label2.TabIndex = 72;
            this.label2.Text = "Введите id буклета для просмотра информации";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(828, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 68);
            this.button1.TabIndex = 71;
            this.button1.Text = "Обновить данные";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.addressesDataGridViewTextBoxColumn,
            this.phoneNumbersDataGridViewTextBoxColumn,
            this.servicesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.advertisingBrochuresBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 450);
            this.dataGridView1.TabIndex = 70;
            // 
            // databaseDataSet9
            // 
            this.databaseDataSet9.DataSetName = "DatabaseDataSet9";
            this.databaseDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // advertisingBrochuresBindingSource
            // 
            this.advertisingBrochuresBindingSource.DataMember = "AdvertisingBrochures";
            this.advertisingBrochuresBindingSource.DataSource = this.databaseDataSet9;
            // 
            // advertisingBrochuresTableAdapter
            // 
            this.advertisingBrochuresTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // addressesDataGridViewTextBoxColumn
            // 
            this.addressesDataGridViewTextBoxColumn.DataPropertyName = "Addresses";
            this.addressesDataGridViewTextBoxColumn.HeaderText = "Addresses";
            this.addressesDataGridViewTextBoxColumn.Name = "addressesDataGridViewTextBoxColumn";
            // 
            // phoneNumbersDataGridViewTextBoxColumn
            // 
            this.phoneNumbersDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumbers";
            this.phoneNumbersDataGridViewTextBoxColumn.HeaderText = "PhoneNumbers";
            this.phoneNumbersDataGridViewTextBoxColumn.Name = "phoneNumbersDataGridViewTextBoxColumn";
            // 
            // servicesDataGridViewTextBoxColumn
            // 
            this.servicesDataGridViewTextBoxColumn.DataPropertyName = "Services";
            this.servicesDataGridViewTextBoxColumn.HeaderText = "Services";
            this.servicesDataGridViewTextBoxColumn.Name = "servicesDataGridViewTextBoxColumn";
            // 
            // ChangeAdvertisement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1123, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeAdvertisement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Посмотреть или изменить рекламный буклет";
            this.Load += new System.EventHandler(this.ChangeAdvertisement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advertisingBrochuresBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DatabaseDataSet9 databaseDataSet9;
        private System.Windows.Forms.BindingSource advertisingBrochuresBindingSource;
        private DatabaseDataSet9TableAdapters.AdvertisingBrochuresTableAdapter advertisingBrochuresTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumbersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicesDataGridViewTextBoxColumn;
    }
}