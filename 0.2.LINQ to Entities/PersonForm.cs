using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace _0._2.LINQ_to_Entities
{
    public partial class PersonForm : Form
    {
        DataContext db;

        public PersonForm()
        {
            InitializeComponent();
            db = new DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var results = from c in db.GetTable<Person>()
                          where c.LastName != "Li"
                          select c;

            foreach (var c in results)
                listBox1.Items.Add(c.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
