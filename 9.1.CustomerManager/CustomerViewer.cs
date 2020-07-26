using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using _9._1.CodeFirst;
using System.Data.SqlClient;
using System.Configuration;

namespace _9._1.CustomerManager
{
    public partial class CustomerViewer : Form
    {
        SampleContext context = new SampleContext();
        byte[] Ph;

        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleContext>());

        private void Output() 
        { 
            if (this.CustomerradioButton.Checked == true) 
                GridView.DataSource = context.Customers.ToList(); 
            else if (this.OrderradioButton.Checked == true) 
                GridView.DataSource = context.Orders.ToList(); 
        }

        public CustomerViewer()
        {
            InitializeComponent();
            
        }

        private void CustomerViewer_Load(object sender, EventArgs e)
        {
            context.Orders.Add(new Order 
            {
                ProductName = "Аудио", 
                Quantity = 12, 
                PurchaseDate = DateTime.Parse("12.01.2016") 
            });
            context.Orders.Add(new Order 
            { 
                ProductName = "Видео", 
                Quantity = 22, 
                PurchaseDate = DateTime.Parse("10.01.2016") 
            }); 
            context.SaveChanges(); 
            orderlistBox.DataSource = context.Orders.ToList();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer 
                { 
                     Name = this.textBoxname.Text
                    , Email = this.textBoxmail.Text
                    , Age = Int32.Parse(this.textBoxage.Text)
                    , Photo = Ph,
                    //Orders = orderlistBox.SelectedItems.OfType<Order>().ToList()
                }; 
                context.Customers.Add(customer); 
                context.SaveChanges();
                Output();

                textBoxname.Text = String.Empty; 
                textBoxmail.Text = String.Empty; 
                textBoxage.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString()); 
            }
            
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog(); if (diag.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(diag.OpenFile());
                ImageConverter converter = new ImageConverter(); 
                Ph = (byte[])converter.ConvertTo(bm, typeof(byte[]));
            }
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            var query = from b in context.Customers 
                        orderby b.Name 
                        select b;
            customerList.DataSource = query.ToList();
        }

        private void customerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void orderlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OrderradioButton_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
