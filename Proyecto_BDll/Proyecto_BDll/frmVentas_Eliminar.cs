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
    public partial class frmVentas_Eliminar : Form
    {
        SqlConnection Ventas_Eliminar_sqlcnn;

        public frmVentas_Eliminar()
        {
            InitializeComponent();
        }

        public frmVentas_Eliminar(SqlConnection Ventas_sqlcnn)
        {
            InitializeComponent();
            Ventas_Eliminar_sqlcnn = Ventas_sqlcnn;
        }

        private void frmVentas_Eliminar_Load(object sender, EventArgs e)
        {

        }
    }
}
