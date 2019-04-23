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

        //Boton de Insertar/Actualizar
        private void btnInsertar_Actualizar_frmProveedores_Click(object sender, EventArgs e)
        {
            String strInsertar, strActualizar;

            String Id = txtbxID_frmProveedores.Text;
            String Nombre = txtbxNombre_frmProveedores.Text;
            String Direccion = txtbxDireccion_frmProveedores.Text;
            String Telefono = txtbxTelefono_frmProveedores.Text;

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
                consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_PROVEEDOR_FRMPROVEEDORES " + Id;
                consultar_sqlcommand.CommandType = CommandType.Text;
                consultar_sqlcommand.Connection = Proveedores_sqlcnn;

                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strActualizar = "EXECUTE UPDATE_PROVEEDOR_FRMPROVEEDORES " + Id + ",'" + Nombre + "', '" + Direccion + "', " + Telefono;

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strActualizar, Proveedores_sqlcnn);
                    actualizar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Actualizado");
                }
                else
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strInsertar = "EXECUTE INSERTAR_PROVEEDOR_FRMPROVEEDORES " + Id + ",'" + Nombre + "', '" + Direccion + "', " + Telefono;

                    SqlCommand insertar_sqlCommand = new SqlCommand(strInsertar, Proveedores_sqlcnn);
                    insertar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Insertado");
                }
            }
        }

        //Boton de Consultar
        private void btnConsultar_frmProveedores_Click(object sender, EventArgs e)
        {
            String Id = txtbxID_frmProveedores.Text;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_PROVEEDOR_FRMPROVEEDORES " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Proveedores_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows) //Checa si existen registros con el Id
                {
                    while (consultar_sqldatareader.Read())
                    {
                        //Inserta los valores en los campos en el frmTrabajadores
                        txtbxNombre_frmProveedores.Text = consultar_sqldatareader["Nombre"].ToString();
                        txtbxDireccion_frmProveedores.Text = consultar_sqldatareader["Direccion"].ToString();
                        txtbxTelefono_frmProveedores.Text = consultar_sqldatareader["Telefono"].ToString();
                    }
                }
                else
                {
                    //Borra todo en los campos de frmTrabajadores
                    btnLimpiar_frmProveedores.PerformClick();
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
        private void btnBorrar_frmProveedores_Click(object sender, EventArgs e)
        {
            //Se checa primero si existe el Id
            String Id = txtbxID_frmProveedores.Text;
            String strBorrar;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_PROVEEDOR_FRMPROVEEDORES " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Proveedores_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //Corre el procedimiento almacenado
                    strBorrar = "EXECUTE BORRAR_PROVEEDOR_FRMPROVEEDORES " + Id;

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strBorrar, Proveedores_sqlcnn);
                    actualizar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Borrado");

                    //Limpia la frmTrabajadores
                    btnLimpiar_frmProveedores.PerformClick();
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
        private void btnLimpiar_frmProveedores_Click(object sender, EventArgs e)
        {
            txtbxID_frmProveedores.Text = "";
            txtbxNombre_frmProveedores.Text = "";
            txtbxDireccion_frmProveedores.Text = "";
            txtbxTelefono_frmProveedores.Text = "";
        }

        //Boton de Salir
        private void btnSalir_frmProveedores_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


