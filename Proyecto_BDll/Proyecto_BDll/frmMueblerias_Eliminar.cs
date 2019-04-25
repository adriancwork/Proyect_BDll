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

        //Carga inicial de la forma
        private void frmMueblerias_Eliminar_Load(object sender, EventArgs e)
        {
            //Aqui cargar la lista de las mueblerias disponibles de la base de datos
            SqlDataReader cmbbxIDPMuebleria_sqldatareader;
            SqlCommand cmbbxIDMuebleria_sqlcommand = new SqlCommand();

            cmbbxIDMuebleria_sqlcommand.CommandText = "SELECT ID_Mueble FROM Muebles ";
            cmbbxIDMuebleria_sqlcommand.CommandType = CommandType.Text;
            cmbbxIDMuebleria_sqlcommand.Connection = Mueblerias_Eliminar_sqlcnn;

            cmbbxIDPMuebleria_sqldatareader = cmbbxIDMuebleria_sqlcommand.ExecuteReader();


            if (cmbbxIDPMuebleria_sqldatareader.HasRows)
            {
                SqlCommand consultarIDProveedor_sqlCommand = new SqlCommand(cmbbxIDMuebleria_sqlcommand.CommandText, Mueblerias_Eliminar_sqlcnn);

                try
                {

                    while (cmbbxIDPMuebleria_sqldatareader.Read())
                    {
                        int i = 0;
                        String Id = Convert.ToString(cmbbxIDPMuebleria_sqldatareader.GetInt32(i));
                        cmbbxID_frmMueblerias_Eliminar.Items.Add(Id);
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Existe un error!, porfavor revisar los datos");
                }
            }
            cmbbxIDPMuebleria_sqldatareader.Close();

        }

        //Evento cuando cambie el valor del ID, actualiza el nombre
        private void cmbbxID_frmMueblerias_Eliminar_SelectedValueChanged(object sender, EventArgs e)
        {
            //Aqui cargar la lista de las mueblerias disponibles de la base de datos
            SqlDataReader txtbxNombreMueble_sqldatareader;
            SqlCommand txtbxNombreMueble_sqlcommand = new SqlCommand();

            String Id = cmbbxID_frmMueblerias_Eliminar.Text;

            txtbxNombreMueble_sqlcommand.CommandText = "SELECT Nombre_Mueble FROM Muebles WHERE ID_Mueble = " + Id;
            txtbxNombreMueble_sqlcommand.CommandType = CommandType.Text;
            txtbxNombreMueble_sqlcommand.Connection = Mueblerias_Eliminar_sqlcnn;

            txtbxNombreMueble_sqldatareader = txtbxNombreMueble_sqlcommand.ExecuteReader();


            if (txtbxNombreMueble_sqldatareader.HasRows)
            {
                SqlCommand consultarIDProveedor_sqlCommand = new SqlCommand(txtbxNombreMueble_sqlcommand.CommandText, Mueblerias_Eliminar_sqlcnn);

                try
                {

                    while (txtbxNombreMueble_sqldatareader.Read())
                    {
                        int i = 0;
                        String Nombre = txtbxNombreMueble_sqldatareader.GetString(i);
                        txtboxNombre_frmMueblerias_Eliminar.Text = Nombre;
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Existe un error!, porfavor revisar los datos");
                }
            }
            txtbxNombreMueble_sqldatareader.Close();

        }

        //Guardar
        private void btnGuardar_frmMueblerias_Eliminar_Click(object sender, EventArgs e)
        {
            SqlDataReader txtbxNombreMueble_sqldatareader;
            SqlCommand txtbxNombreMueble_sqlcommand = new SqlCommand();

            String Id = cmbbxID_frmMueblerias_Eliminar.Text;
            String strBorrar;

            txtbxNombreMueble_sqlcommand.CommandText = "EXECUTE CONSULTAR_MUEBLES_FRMMUEBLERIAS " + Id;
            txtbxNombreMueble_sqlcommand.CommandType = CommandType.Text;
            txtbxNombreMueble_sqlcommand.Connection = Mueblerias_Eliminar_sqlcnn;

            //Si el campo te id esta vacio muestra un error
           /* if (cmbbxID_frmMueblerias_Eliminar.Text == "")
            {
                MessageBox.Show("No existe Id para eliminar");
            }
            else {*/
                try
                {
                    //Guarda en el datareader la ejecucion del comando
                    txtbxNombreMueble_sqldatareader = txtbxNombreMueble_sqlcommand.ExecuteReader();

                    //Consultar si tiene filas (registros) el ID
                    if (txtbxNombreMueble_sqldatareader.HasRows)
                    {
                        //Se cierra el sqldatareader
                        txtbxNombreMueble_sqldatareader.Close();

                        //Corre el procedimiento almacenado
                        strBorrar = "EXECUTE BORRAR_MUEBLES_FRMMUEBLERIAS_ELIMINAR " + Id;

                        SqlCommand actualizar_sqlCommand = new SqlCommand(strBorrar, Mueblerias_Eliminar_sqlcnn);
                        actualizar_sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro Borrado");

                        //Limpia la frmMueblerias_Eliminar
                        cmbbxID_frmMueblerias_Eliminar.Text = "";
                        txtboxNombre_frmMueblerias_Eliminar.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No existe este ID");
                    }

                    txtbxNombreMueble_sqldatareader.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("No existe Id");
                }

                
            //}
        }

        //Cancelar
        private void btnCancelar_frmMueblerias_Eliminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
