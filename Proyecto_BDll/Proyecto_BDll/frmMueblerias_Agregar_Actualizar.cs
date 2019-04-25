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
        SqlConnection Muebles_Agregar_Actualizar_sqlcnn;

        public frmMueblerias_Agregar_Actualizar()
        {
            InitializeComponent();
        }

        public frmMueblerias_Agregar_Actualizar(SqlConnection Mueblerias_sqlcnn)
        {
            InitializeComponent();
            Muebles_Agregar_Actualizar_sqlcnn = Mueblerias_sqlcnn;
        }

        //Carga inicialmente el Id en el cmbbx
        private void frmMueblerias_Agregar_Actualizar_Load(object sender, EventArgs e)
        {
            //Aqui cargar la lista de los proveedores disponibles de la base de datos
            SqlDataReader cmbbxIDProveedor_sqldatareader;
            SqlCommand cmbbxIDProveedor_sqlcommand = new SqlCommand();

            cmbbxIDProveedor_sqlcommand.CommandText = "SELECT ID_Proveedor_Carpinteria FROM Proveedor ";
            cmbbxIDProveedor_sqlcommand.CommandType = CommandType.Text;
            cmbbxIDProveedor_sqlcommand.Connection = Muebles_Agregar_Actualizar_sqlcnn;

            cmbbxIDProveedor_sqldatareader = cmbbxIDProveedor_sqlcommand.ExecuteReader();


            if (cmbbxIDProveedor_sqldatareader.HasRows)
            {
                SqlCommand consultarIDProveedor_sqlCommand = new SqlCommand(cmbbxIDProveedor_sqlcommand.CommandText, Muebles_Agregar_Actualizar_sqlcnn);

                try
                {

                    while (cmbbxIDProveedor_sqldatareader.Read())
                    {
                        int i = 0;
                        String Id = Convert.ToString(cmbbxIDProveedor_sqldatareader.GetInt32(i));
                        cmbbxProveedorID_frmMueblerias_Agregar_Actualizar.Items.Add(Id);
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Existe un error!, porfavor revisar los datos");
                }
            }
            cmbbxIDProveedor_sqldatareader.Close();
        }

        //Actualizacion de Nombre cuando cambia a ID proveedor
        private void cmbbxProveedorID_frmMueblerias_Agregar_Actualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui cargar la lista de los proveedores disponibles de la base de datos
            SqlDataReader cmbbxIDProveedor_sqldatareader;
            SqlCommand cmbbxIDProveedor_sqlcommand = new SqlCommand();

            String Id = cmbbxProveedorID_frmMueblerias_Agregar_Actualizar.Text;

            cmbbxIDProveedor_sqlcommand.CommandText = "SELECT Nombre FROM Proveedor WHERE ID_Proveedor_Carpinteria = " + Id;
            cmbbxIDProveedor_sqlcommand.CommandType = CommandType.Text;
            cmbbxIDProveedor_sqlcommand.Connection = Muebles_Agregar_Actualizar_sqlcnn;

            cmbbxIDProveedor_sqldatareader = cmbbxIDProveedor_sqlcommand.ExecuteReader();


            if (cmbbxIDProveedor_sqldatareader.HasRows)
            {
                SqlCommand consultarIDProveedor_sqlCommand = new SqlCommand(cmbbxIDProveedor_sqlcommand.CommandText, Muebles_Agregar_Actualizar_sqlcnn);

                try
                {

                    while (cmbbxIDProveedor_sqldatareader.Read())
                    {
                        int i = 0;
                        String Nombre = cmbbxIDProveedor_sqldatareader.GetString(i);
                        txtbxProveedorNombre_frmMueblerias_Agregar_Actualizar.Text = Nombre;
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Existe un error!, porfavor revisar los datos");
                }
            }
            cmbbxIDProveedor_sqldatareader.Close();
        }

        //Boton Guardar
        private void btnGuardar_frmMueblerias_Agregar_Actualizar_Click(object sender, EventArgs e)
        {
            String strInsertar, strActualizar;

            String Id = txtbxID_frmMueblerias_Agregar_Actualizar.Text;
            String ProveedorID = cmbbxProveedorID_frmMueblerias_Agregar_Actualizar.Text;
            String Nombre = txtbxNombreMueble__frmMueblerias_Agregar_Actualizar.Text;
            String Costo = txtbxCosto_Unidad_frmMueblerias_Agregar_Actualizar.Text;

            //Checar que no este vacio el txtbxID_frmTrabajadores o que no contega " " al inicio o al final
            if (Id.Length.Equals(0))
            {
                MessageBox.Show("Falta insert Id");
            }
            else if (Id.StartsWith(" ") || Id.EndsWith(" "))
            {
                MessageBox.Show("Existe un caracter no valido en el campo, porfavor corrige");
            }
            else
            {
                //Consultado si existe registro con este ID
                SqlDataReader consultar_sqldatareader;

                SqlCommand consultar_sqlcommand = new SqlCommand();

                //Comando almacenado ejecutao
                consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_MUEBLES_FRMMUEBLERIAS " + Id;
                consultar_sqlcommand.CommandType = CommandType.Text;
                consultar_sqlcommand.Connection = Muebles_Agregar_Actualizar_sqlcnn;

                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strActualizar = "EXECUTE UPDATE_MUEBLES_FRMMUEBLERIAS_AGREGAR_ACTUALIZAR " + Id + "," + ProveedorID + ", '" + Nombre + "', " + Costo;

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strActualizar, Muebles_Agregar_Actualizar_sqlcnn);

                    try
                    {
                        actualizar_sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro Actualizado");

                        txtbxID_frmMueblerias_Agregar_Actualizar.Text = "";
                        cmbbxProveedorID_frmMueblerias_Agregar_Actualizar.Text = "";
                        txtbxProveedorNombre_frmMueblerias_Agregar_Actualizar.Text = "";
                        txtbxNombreMueble__frmMueblerias_Agregar_Actualizar.Text = "";
                        txtbxCosto_Unidad_frmMueblerias_Agregar_Actualizar.Text = "";
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Existe un error!, porfavor revisar los datos");
                    }

                }
                else
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strInsertar = "EXECUTE INSERTAR_MUEBLES_FRMMUEBLERIAS_AGREGAR_ACTUALIZAR " + Id + "," + ProveedorID + ", '" + Nombre + "', " + Costo;

                    SqlCommand insertar_sqlCommand = new SqlCommand(strInsertar, Muebles_Agregar_Actualizar_sqlcnn);

                    try
                    {
                        insertar_sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro Insertado");

                        txtbxID_frmMueblerias_Agregar_Actualizar.Text = "";
                        cmbbxProveedorID_frmMueblerias_Agregar_Actualizar.Text = "";
                        txtbxProveedorNombre_frmMueblerias_Agregar_Actualizar.Text = "";
                        txtbxNombreMueble__frmMueblerias_Agregar_Actualizar.Text = "";
                        txtbxCosto_Unidad_frmMueblerias_Agregar_Actualizar.Text = "";
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Existe un error!, porfavor revisar los datos");
                    }

                }
            }
        }

        //Boton cancelar
        private void btnCancelar_frmMueblerias_Agregar_Actualizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
