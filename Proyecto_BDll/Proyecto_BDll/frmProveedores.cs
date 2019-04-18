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
    public partial class frmProveedores : Form
    {
        SqlConnection Proveedores_sqlcnn;

        public frmProveedores()
        {
            InitializeComponent();
        }

        public frmProveedores(SqlConnection Menu_sqlcnn)
        {
            InitializeComponent();
            Proveedores_sqlcnn = Menu_sqlcnn;
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
