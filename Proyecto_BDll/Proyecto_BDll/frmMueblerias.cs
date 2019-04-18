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
    public partial class frmMueblerias : Form
    {
        SqlConnection Muebleria_sqlcnn;

        public frmMueblerias()
        {
            InitializeComponent();
        }

        public frmMueblerias(SqlConnection Menu_sqlcnn)
        {
            InitializeComponent();
            Muebleria_sqlcnn = Menu_sqlcnn;
        }

        private void frmMueblerias_Load(object sender, EventArgs e)
        {

        }
    }
}
