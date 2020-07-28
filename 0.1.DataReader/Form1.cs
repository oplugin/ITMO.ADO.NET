using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _0._1.DataReader
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog = School; Integrated Security = True";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT Title FROM Course", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listView1.Items.Add(reader["Title"].ToString());
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
