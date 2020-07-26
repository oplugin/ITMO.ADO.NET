using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8._3.LINQsqlSproc
{
    public partial class Form1 : Form
    {

        Northwnd db = new Northwnd(@"Data Source=(LocalDB)\MSSQLLocalDB;
                        Initial Catalog=Northwind;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
