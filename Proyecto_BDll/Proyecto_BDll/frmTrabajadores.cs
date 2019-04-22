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

        //Constructor sobrecargado para aceptar conexion a BD Muebleria
        public frmTrabajadores(SqlConnection Menu_sqlcnn)
        {
            InitializeComponent();
            Trabajadores_sqlcnn = Menu_sqlcnn;
        }

        private void frmTrabajadores_Load(object sender, EventArgs e)
        {

        }

        //Boton de Insertar/Actualizar
        private void btnInserat_Actualizar_frmTrabajadores_Click(object sender, EventArgs e)
        {
            String strInsertar, strActualizar; //Un string para Insertar y otro para Actualizar

            //Declaracion de variables 
            String Id = txtbxID_frmTrabajadores.Text;
            String Nombre = txtbxNombre_frmTrabajadores.Text;
            String Puesto = txtbxPuesto_frmTrabajadores.Text;
            String Salario = txtbxSalario_frmTrabajadores.Text;
            String FechaNac = dtpFechaNacimiento_frmTrabajadores.Value.ToString("yyyy-MM-dd");

            //Checar que no este vacio el txtbxID_frmTrabajadores o que no contega " " al inicio o al final
            if (Id.Length.Equals(0))
            {
                MessageBox.Show("Falta insert Id");
            }
            else if (Id.StartsWith(" ") || Id.EndsWith(" ")) {
                MessageBox.Show("Existe un caracter no valido en el campo, porfavor corrige");
            }
            else
            {
                //Consultado si existe registro con este ID
                SqlDataReader consultar_sqldatareader;

                SqlCommand consultar_sqlcommand = new SqlCommand();

                //Comando almacenado ejecutao
                consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_TRABAJADORES_FRMTRABAJADORES " + Id; 
                consultar_sqlcommand.CommandType = CommandType.Text;
                consultar_sqlcommand.Connection = Trabajadores_sqlcnn;

                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows) {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strActualizar = "EXECUTE UPDATE_TRABAJADOR_FRMTRABAJADORES " + Id + ",'" + Nombre + "', '" + Puesto + "', " + Salario + ", '" + FechaNac + "'";

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strActualizar, Trabajadores_sqlcnn);
                    actualizar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Actualizado");

                    
                }
                else {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strInsertar = "EXECUTE INSERT_TRABAJADOR_FRMTRABAJADORES " + Id + ",'"+ Nombre +"', '"+ Puesto +"', " + Salario + ", '"+ FechaNac + "'";

                    SqlCommand insertar_sqlCommand = new SqlCommand(strInsertar, Trabajadores_sqlcnn);
                    insertar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Insertado");

                }
            }
        }

        //Boton de consultar
        private void btnConsultar_frmTrabajadores_Click(object sender, EventArgs e)
        {
            String Id = txtbxID_frmTrabajadores.Text;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_TRABAJADORES_FRMTRABAJADORES " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Trabajadores_sqlcnn;

            try {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows) //Checa si existen registros con el Id
                {
                    while (consultar_sqldatareader.Read())
                    {
                        //Inserta los valores en los campos en el frmTrabajadores
                        txtbxNombre_frmTrabajadores.Text = consultar_sqldatareader["Nombre_Trabajador"].ToString();
                        txtbxPuesto_frmTrabajadores.Text = consultar_sqldatareader["Puesto_Trabajador"].ToString();
                        txtbxSalario_frmTrabajadores.Text = consultar_sqldatareader["Salario"].ToString();
                        this.dtpFechaNacimiento_frmTrabajadores.Value = (DateTime)consultar_sqldatareader["Fecha_Nac"];
                    }
                }
                else
                {
                    //Borra todo en los campos de frmTrabajadores
                    txtbxNombre_frmTrabajadores.Text = "";
                    txtbxPuesto_frmTrabajadores.Text = "";
                    txtbxSalario_frmTrabajadores.Text = "";
                    dtpFechaNacimiento_frmTrabajadores.Value = DateTime.Now;
                    MessageBox.Show("No existe registro con el id indicado");
                }
                consultar_sqldatareader.Close();
            }
            catch (SqlException){
                MessageBox.Show("No existe Id para consultar");
            }
        }

        //Boton de borrar
        private void btnBorrar_frmTrabajadores_Click(object sender, EventArgs e)
        {
            //Se checa primero si existe el Id
            String Id = txtbxID_frmTrabajadores.Text;
            String strBorrar;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_TRABAJADORES_FRMTRABAJADORES " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Trabajadores_sqlcnn;

            try{
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //Corre el procedimiento almacenado
                    strBorrar = "EXECUTE BORRAR_TRABAJADORES_FRMTRABAJADORES " + Id;

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strBorrar, Trabajadores_sqlcnn);
                    actualizar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Borrado");

                    //Limpia la frmTrabajadores
                    btnLimpiar_frmTrabajadores.PerformClick();
                }
                else
                {
                    MessageBox.Show("No existe este ID");
                }
            }
            catch (SqlException ) {
                MessageBox.Show("No existe Id para consultar");
            }
        }

        //Boton de limpiar
        private void btnLimpiar_frmTrabajadores_Click(object sender, EventArgs e)
        {
            txtbxID_frmTrabajadores.Text = "";
            txtbxNombre_frmTrabajadores.Text = "";
            txtbxPuesto_frmTrabajadores.Text = "";
            txtbxSalario_frmTrabajadores.Text = "";
            dtpFechaNacimiento_frmTrabajadores.Value = DateTime.Now;

        }

        //Boton de Salir
        private void btnSalir_frmTrabajadores_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
