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
using Cafeteria.DB_Helper;

namespace Cafeteria
{
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
            comboBox1.Text = "employee";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            string tableName = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            bs.DataSource = Connector.readData(tableName).Tables[0];
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bs;
            dataGridView1.Refresh();
           
        }

        private void search_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            string textsearch = textSearch.Text;
            bs.DataSource = Connector.searchBook(textsearch).Tables[0];
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bs;
            dataGridView1.Refresh();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            string newcity = textSearch.Text;
            int store_id = int.Parse(textBox1.Text);
            Connector.updateCommand(newcity, store_id);
       
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string emp_serial = textSearch.Text;
            Connector.deleteCommand(emp_serial);
           
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string name = textSearch.Text;
            Connector.insertCommand(name);
          

        }
    }
}
