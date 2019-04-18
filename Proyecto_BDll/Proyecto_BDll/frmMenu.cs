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

namespace Proyecto_BDll
{
    public partial class frmMenu : Form
    {
        SqlConnection Menu_sqlcnn;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            string connectionString = null;
            connectionString = "Data Source = lenovo-pc\\sqlserverexpress; Initial Catalog=Muebleria; Integrated Security = true";

            Menu_sqlcnn = new SqlConnection(connectionString);

            try
            {
                Menu_sqlcnn.Open();
                //MessageBox.Show("Conexión abierta!");
            }

            catch (Exception)
            {
                //MessageBox.Show("No se realizó la conexión !");
                this.Close();
            }
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu_sqlcnn.Close();
        }

        private void btnTrabajadores_frmMenu_Click(object sender, EventArgs e)
        {
            frmTrabajadores frmTrabajadores = new frmTrabajadores(Menu_sqlcnn);
            frmTrabajadores.Show();
            this.Hide();
        }

        private void btnProveedores_frmMenu_Click(object sender, EventArgs e)
        {
            frmProveedores frmProveedores = new frmProveedores(Menu_sqlcnn);
            frmProveedores.FormClosed += new FormClosedEventHandler(frmProveedores_FormClosed);
            this.Hide();
            frmProveedores.Show();           
        }

        void frmProveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnMuebleria_frmMenu_Click(object sender, EventArgs e)
        {
            frmMueblerias frmMueblerias = new frmMueblerias(Menu_sqlcnn);
            frmMueblerias.Show();
            this.Hide();
        }

        private void btnVentas_frmMenu_Click(object sender, EventArgs e)
        {
            frmVentas frmVentas = new frmVentas(Menu_sqlcnn);
            frmVentas.Show();
            this.Hide();
        }
    }
}
