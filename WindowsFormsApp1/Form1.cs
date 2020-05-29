using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        protected DataClasses1DataContext dc;
        protected SqlConnection connection;
        public Form1()
        {
            InitializeComponent();

            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kseno\Downloads\UI_SQLDB-master\UI_SQLDB-master\WindowsFormsApp1\Database1.mdf;Integrated Security=True");

            dc = new DataClasses1DataContext(connection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.Table;
        }

        private void OnFilterBtnClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.Table.Where(p =>
               p.Id > 1);
        }

        private void OnSaveBtnClick(object sender, EventArgs e)
        {
            dc.SubmitChanges();
        }

        private void OnClearBtnClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dc.Table;
        }

        private void OnLoadBtnClick(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Table] WHERE Id = 2", connection);
            command.ExecuteNonQuery();
            connection.Close();

            dc = new DataClasses1DataContext(connection);
            dataGridView1.DataSource = dc.Table;
        }
    }
}
