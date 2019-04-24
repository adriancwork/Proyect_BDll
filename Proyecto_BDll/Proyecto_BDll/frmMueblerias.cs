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
            //Aqui cargar la lista de los proveedores disponibles de la base de datos
            SqlDataReader cmbbxIDProveedor_sqldatareader;
            SqlCommand cmbbxIDProveedor_sqlcommand = new SqlCommand();

            cmbbxIDProveedor_sqlcommand.CommandText = "SELECT ID_Proveedor_Carpinteria FROM Proveedor ";
            cmbbxIDProveedor_sqlcommand.CommandType = CommandType.Text;
            cmbbxIDProveedor_sqlcommand.Connection = Muebleria_sqlcnn;

            cmbbxIDProveedor_sqldatareader = cmbbxIDProveedor_sqlcommand.ExecuteReader();


            if (cmbbxIDProveedor_sqldatareader.HasRows)
            {
                SqlCommand consultarIDProveedor_sqlCommand = new SqlCommand(cmbbxIDProveedor_sqlcommand.CommandText, Muebleria_sqlcnn);

                try
                {

                    while (cmbbxIDProveedor_sqldatareader.Read())
                    {
                        int i = 0;
                        String Id = Convert.ToString(cmbbxIDProveedor_sqldatareader.GetInt32(i));
                        cmbbxIDProveedor_frmMueblerias.Items.Add(Id);
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

        //Boton de Insertar/Actualizar
        private void btnInsertar_Actualizar_frmMueblerias_Click(object sender, EventArgs e)
        {
            String strInsertar, strActualizar;

            String Id = txtbxID_frmMueblerias.Text;
            String Proveedor = cmbbxIDProveedor_frmMueblerias.Text;
            String Direccion = txtbxDireccion_frmMueblerias.Text;
            String Telefono = txtbxTelefono_frmMueblerias.Text;

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
                consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_MUEBLERIA_FRMMUEBLERIAS " + Id;
                consultar_sqlcommand.CommandType = CommandType.Text;
                consultar_sqlcommand.Connection = Muebleria_sqlcnn;

                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strActualizar = "EXECUTE UPDATE_MUEBLERIA_FRMMUEBLERIAS " + Id + "," + Proveedor + ", '" + Direccion + "', " + Telefono;

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strActualizar, Muebleria_sqlcnn);

                    try {
                        actualizar_sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro Actualizado");
                    }
                    catch (Exception){
                        MessageBox.Show("Existe un error!, porfavor revisar los datos");
                    }
                    
                }
                else
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strInsertar = "EXECUTE INSERTAR_MUEBLERIA_FRMMUEBLERIAS " + Id + "," + Proveedor + ", '" + Direccion + "', " + Telefono;

                    SqlCommand insertar_sqlCommand = new SqlCommand(strInsertar, Muebleria_sqlcnn);
                    
                    try
                    {
                        insertar_sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro Insertado");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Existe un error!, porfavor revisar los datos");
                    }

                }
            }
        }

        //Boton de Consultar
        private void btnConsultar_frmMueblerias_Click(object sender, EventArgs e)
        {
            String Id = txtbxID_frmMueblerias.Text;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_MUEBLERIA_FRMMUEBLERIAS " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Muebleria_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows) //Checa si existen registros con el Id
                {
                    while (consultar_sqldatareader.Read())
                    {
                        //Inserta los valores en los campos en el frmTrabajadores
                        cmbbxIDProveedor_frmMueblerias.Text = consultar_sqldatareader["fkID_Proveedor_Carpinteria"].ToString();
                        txtbxDireccion_frmMueblerias.Text = consultar_sqldatareader["Direccion"].ToString();
                        txtbxTelefono_frmMueblerias.Text = consultar_sqldatareader["Telefono"].ToString();
                    }
                }
                else
                {
                    //Borra todo en los campos de frmTrabajadores
                    btnLimpiar_frmMueblerias.PerformClick();
                    MessageBox.Show("No existe registro con el id indicado");
                }
                consultar_sqldatareader.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("No existe Id para consultar");
            }
        }

        //Boton de Borrar
        private void btnBorrar_frmMueblerias_Click(object sender, EventArgs e)
        {
            //Se checa primero si existe el Id
            String Id = txtbxID_frmMueblerias.Text;
            String strBorrar;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_MUEBLERIA_FRMMUEBLERIAS " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Muebleria_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //Corre el procedimiento almacenado
                    strBorrar = "EXECUTE BORRAR_MUEBLERIA_FRMMUEBLERIAS " + Id;

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strBorrar, Muebleria_sqlcnn);
                    actualizar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Borrado");

                    //Limpia la frmTrabajadores
                    btnLimpiar_frmMueblerias.PerformClick();
                }
                else
                {
                    MessageBox.Show("No existe este ID");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("No existe Id para consultar");
            }
        }

        //Boton de Limpiar
        private void btnLimpiar_frmMueblerias_Click(object sender, EventArgs e)
        {
            txtbxID_frmMueblerias.Text = "";
            cmbbxIDProveedor_frmMueblerias.Text = "";
            txtbxProveedorNombre_frmMueblerias.Text = "";
            txtbxDireccion_frmMueblerias.Text = "";
            txtbxTelefono_frmMueblerias.Text = "";
        }

        //Boton de Salir
        private void btnSalir_frmMueblerias_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbbxIDProveedor_frmMueblerias_TextChanged(object sender, EventArgs e)
        {
            //Aqui cargar la lista de los proveedores disponibles de la base de datos

            SqlDataReader txtbxProveedorNombre_sqldatareader;
            SqlCommand txtbxProveedorNombre_sqlcommand = new SqlCommand();

            txtbxProveedorNombre_sqlcommand.CommandText = "SELECT Nombre FROM Proveedor WHERE ID_Proveedor_Carpinteria = " + cmbbxIDProveedor_frmMueblerias.Text;
            txtbxProveedorNombre_sqlcommand.CommandType = CommandType.Text;
            txtbxProveedorNombre_sqlcommand.Connection = Muebleria_sqlcnn;

            if (cmbbxIDProveedor_frmMueblerias.Text.Equals("")){
                txtbxProveedorNombre_sqlcommand.CommandText = "SELECT Nombre FROM Proveedor";
            }

            txtbxProveedorNombre_sqldatareader = txtbxProveedorNombre_sqlcommand.ExecuteReader();


            if (txtbxProveedorNombre_sqldatareader.HasRows)
            {
                SqlCommand consultarMuebleria_sqlCommand = new SqlCommand(txtbxProveedorNombre_sqlcommand.CommandText, Muebleria_sqlcnn);

                try
                {
                    
                    while (txtbxProveedorNombre_sqldatareader.Read())
                    {
                        int i = 0;
                        String Nombre = txtbxProveedorNombre_sqldatareader.GetString(0);
                        txtbxProveedorNombre_frmMueblerias.Text = Nombre;
                        i++;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Existe un error!, porfavor revisar los datos");
                }

            }
            txtbxProveedorNombre_sqldatareader.Close();
        }

        //Boton de Agregar/Actualizar
        private void btnAgregar_ActualizarMueble_frmMueblerias_Click(object sender, EventArgs e)
        {
            frmMueblerias_Agregar_Actualizar frmMueblerias_Agregar_Actualizar = new frmMueblerias_Agregar_Actualizar(Muebleria_sqlcnn);
            frmMueblerias_Agregar_Actualizar.FormClosed += new FormClosedEventHandler(frmMueblerias_Agregar_Actualizar_FormedClosed);
            frmMueblerias_Agregar_Actualizar.Show();
            this.Hide();
        }

        private void frmMueblerias_Agregar_Actualizar_FormedClosed(object sender, EventArgs e) {
            this.Show();
        }

        //Boton de Eliminar
        private void btnEliminarMueble_frmMuebleria_Click(object sender, EventArgs e)
        {
            frmMueblerias_Eliminar frmMueblerias_Eliminar = new frmMueblerias_Eliminar(Muebleria_sqlcnn);
            frmMueblerias_Eliminar.FormClosed += new FormClosedEventHandler(frmMueblerias_Eliminar_FormedClosed);
            frmMueblerias_Eliminar.Show();
            this.Hide();
        }

        private void frmMueblerias_Eliminar_FormedClosed(object sender, EventArgs e) {
            this.Show();
        }

        //Boton de Detalle
        private void btnDetalle_frmMueblerias_Click(object sender, EventArgs e)
        {

        }

        //Boton Limpiar
        private void btnLimpiarDataView_frmMueblerias_Click(object sender, EventArgs e)
        {

        }
    }
}
