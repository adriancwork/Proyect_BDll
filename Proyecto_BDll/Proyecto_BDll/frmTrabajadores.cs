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
    public partial class frmTrabajadores : Form
    {
        SqlConnection Trabajadores_sqlcnn;

        public frmTrabajadores()
        {
            InitializeComponent();
        }

        public frmTrabajadores(SqlConnection Menu_sqlcnn)
        {
            InitializeComponent();
            Trabajadores_sqlcnn = Menu_sqlcnn;
        }

        private void frmTrabajadores_Load(object sender, EventArgs e)
        {

        }

        private void frmTrabajadores_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }
    }
}
