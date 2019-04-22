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
            //Cambiar el Data Source [la conexion del equipo requerida]
            string connectionString = null;
            connectionString = "Data Source = lenovo-pc\\sqlserverexpress; Initial Catalog=Muebleria; Integrated Security = true";

            Menu_sqlcnn = new SqlConnection(connectionString);

            //Si no esta habilitada la conexion, no se abre el frmMenu
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
        //Si no esta encendido el servidor y no se va abir el frmMenu
        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu_sqlcnn.Close();
        }

        //Intercambio de vistas de frmTrabajadores
        private void btnTrabajadores_frmMenu_Click(object sender, EventArgs e)
        {
            frmTrabajadores frmTrabajadores = new frmTrabajadores(Menu_sqlcnn);
            frmTrabajadores.FormClosed += new FormClosedEventHandler(frmTrabajadores_FormClosed);
            frmTrabajadores.Show();
            this.Hide();
        }

        void frmTrabajadores_FormClosed(object sender, FormClosedEventArgs e) {
            this.Show();
        }

        //Intercambio de vistas de frmProveedores
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

        //Intercambio de vistas Muebleria
        private void btnMuebleria_frmMenu_Click(object sender, EventArgs e)
        {
            frmMueblerias frmMueblerias = new frmMueblerias(Menu_sqlcnn);
            frmMueblerias.FormClosed += new FormClosedEventHandler(frmMuebleria_FormClosed);
            frmMueblerias.Show();
            this.Hide();
        }

        void frmMuebleria_FormClosed(object sender, FormClosedEventArgs e) {
            this.Show();
        }

        //Intercambio de vistas de Ventas
        private void btnVentas_frmMenu_Click(object sender, EventArgs e)
        {
            frmVentas frmVentas = new frmVentas(Menu_sqlcnn);
            frmVentas.FormClosed += new FormClosedEventHandler(frmVentas_FormClosed);
            frmVentas.Show();
            this.Hide();
        }

        void frmVentas_FormClosed(object sender, FormClosedEventArgs e) {
            this.Show();
        }

        //Boton de salida frmMenu
        private void btnSalir_frmMenu_Click(object sender, EventArgs e)
        {
            Menu_sqlcnn.Close();
            this.Close();
        }
    }
}
