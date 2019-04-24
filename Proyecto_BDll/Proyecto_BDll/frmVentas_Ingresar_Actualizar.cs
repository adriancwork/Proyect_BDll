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

    public partial class frmVentas_Ingresar_Actualizar : Form
    {

        SqlConnection Ventas_Ingresar_Actualizar_sqlcnn;

        public frmVentas_Ingresar_Actualizar()
        {
            InitializeComponent();
        }

        public frmVentas_Ingresar_Actualizar(SqlConnection Ventas_sqlcnn)
        {
            InitializeComponent();
            Ventas_Ingresar_Actualizar_sqlcnn = Ventas_sqlcnn;

        }

        private void frmVentas_Ingresar_Actualizar_Load(object sender, EventArgs e)
        {

        }
    }
}
