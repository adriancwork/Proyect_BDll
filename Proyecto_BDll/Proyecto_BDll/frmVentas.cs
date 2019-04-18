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
    public partial class frmVentas : Form
    {
        SqlConnection Ventas_sqlcnn;

        public frmVentas()
        {
            InitializeComponent();
        }

        public frmVentas(SqlConnection Menu_sqlcnn)
        {
            InitializeComponent();
            Ventas_sqlcnn = Menu_sqlcnn;
        }


        private void frmVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
