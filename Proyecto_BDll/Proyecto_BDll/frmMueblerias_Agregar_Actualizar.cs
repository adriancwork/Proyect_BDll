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
    public partial class frmMueblerias_Agregar_Actualizar : Form
    {
        SqlConnection Ventas_Ingreso_Actualizar_sqlcnn;

        public frmMueblerias_Agregar_Actualizar()
        {
            InitializeComponent();
        }

        public frmMueblerias_Agregar_Actualizar(SqlConnection Mueblerias_sqlcnn)
        {
            InitializeComponent();
            Ventas_Ingreso_Actualizar_sqlcnn = Mueblerias_sqlcnn;
        }

        private void frmMueblerias_Agregar_Actualizar_Load(object sender, EventArgs e)
        {

        }
    }
}
