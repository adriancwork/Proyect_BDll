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
        frmVentas frmVentasID;

        public frmVentas_Ingresar_Actualizar()
        {
            InitializeComponent();
        }

        //Pasa la conexion de SQL y la forma frmVentas
        public frmVentas_Ingresar_Actualizar(SqlConnection Ventas_sqlcnn, frmVentas frmVentasID_frmVentas)
        {
            InitializeComponent();
            Ventas_Ingresar_Actualizar_sqlcnn = Ventas_sqlcnn;
            this.frmVentasID = frmVentasID_frmVentas;
        }

        //Carga los Id's correspondientes
        private void frmVentas_Ingresar_Actualizar_Load(object sender, EventArgs e)
        {
            txtbxIDVenta_frmVentas_Ingresar_Actualizar.Text = frmVentasID.txtbxID_frmVentas.Text;
            txtbxIDMuebleria_frmVentas_Ingresar_Actualizar.Text = frmVentasID.txtbxMuebleria_frmVentas.Text;

            //Falta cargar el ID de los muebles en el cmbbxIDMueble
            String Id = cmbbxIDMueble_frmVentas_Ingresar_Actualizar.Text;
            //String IdMuebleria = txtbxIDMuebleria_frmVentas_Ingresar_Actualizar.Text;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "SELECT Nombre_Mueble FROM Muebles WHERE fkID_Proveedor_Carpinteria =  "; //IdMuebleria;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Ventas_Ingresar_Actualizar_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows) //Checa si existen registros con el Id
                {
                    while (consultar_sqldatareader.Read())
                    {
                        //Inserta los valores en los campos en el frmTrabajadores
                        //txtbxMueblerNombre_frmVentas_Ingresar_Actualizar.Text = consultar_sqldatareader["Nombre_Mueble"].ToString(); //Puede tener errores


                        //Linea 42,49,63 necestas el id del proveedor de la muebleria para poder usar la para hace el select del nombre del
                        //mueble que se va mostrar en la tabla del dgv
                    }
                }
                else
                {
                    //Borra todo en los campos de frmTrabajadores
                    cmbbxIDMueble_frmVentas_Ingresar_Actualizar.Text = "";
                    txtbxMueblerNombre_frmVentas_Ingresar_Actualizar.Text = "";
                    txtbxCantidad_frmVentas_Ingresar_Actualizar.Text = "";
                    txtbxAjuste_frmVentas_Ingresar_Actualizar.Text = "";

                    //MessageBox.Show("No existe registro con el id indicado");
                }
                consultar_sqldatareader.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("No existe Id para consultar");
            }
        }

        //Actualizacion de Nombre cuando se cambie el ID del Mueble
        private void cmbbxIDMueble_frmVentas_Ingresar_Actualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //Boton Cancelar
        private void btnCancelar_frmVentas_Ingresar_Actualizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
