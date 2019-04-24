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
    public partial class frmMueblerias_Eliminar : Form
    {
        SqlConnection Mueblerias_Eliminar_sqlcnn;

        public frmMueblerias_Eliminar()
        {
            InitializeComponent();
        }

        public frmMueblerias_Eliminar(SqlConnection Mueblerias_sqlcnn)
        {
            InitializeComponent();
            Mueblerias_Eliminar_sqlcnn = Mueblerias_sqlcnn;
        }

        private void frmMueblerias_Eliminar_Load(object sender, EventArgs e)
        {

        }
    }
}
