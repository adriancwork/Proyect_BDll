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

namespace Proyecto_BDll
{
    public partial class Form1 : Form
    {
        SqlConnection sqlcnn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = null;
            connectionString = "Data Source = lenovo-pc\\sqlserverexpress; Initial Catalog=Muebleria; Integrated Security = true";

            sqlcnn = new SqlConnection(connectionString);

            try
            {
                sqlcnn.Open();
                //MessageBox.Show("Conexión abierta!");
            }

            catch (Exception ex)
            {
                //MessageBox.Show("No se realizó la conexión !");
                this.Close();
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlcnn.Close();
        }
    }
}
