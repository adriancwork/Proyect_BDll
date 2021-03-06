﻿using System;
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
    public partial class frmVentas : Form
    {
        SqlConnection Ventas_sqlcnn;

        public frmVentas()
        {
            InitializeComponent();
        }

        public frmVentas(SqlConnection Menu_sqlcnn)
        {
            InitializeComponent();
            Ventas_sqlcnn = Menu_sqlcnn;
        }


        private void frmVentas_Load(object sender, EventArgs e)
        {

        }

        //Boton de Insertar/Actualizar
        private void btnInsertar_Actualizar_frmVentas_Click(object sender, EventArgs e)
        {
            String strInsertar, strActualizar;

            String Id = txtbxID_frmVentas.Text;
            String Muebleria = txtbxMuebleria_frmVentas.Text;
            String Trabajador = txtbxTrabajador_frmVentas.Text;
            String FechaVenta = dtpFechaVenta_frmVentas.Value.ToString("yyyy-MM-dd");

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
                consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_VENTAS_FRMVENTAS " + Id;
                consultar_sqlcommand.CommandType = CommandType.Text;
                consultar_sqlcommand.Connection = Ventas_sqlcnn;

                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //se corre procedimiento almacenado
                    strActualizar = "EXECUTE UPDATE_VENTAS_FRMVENTAS " + Id + "," + Muebleria + ", " + Trabajador + ", '" + FechaVenta + "'";

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strActualizar, Ventas_sqlcnn);

                    try
                    {
                        actualizar_sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Registro Actualizado");
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
                    strInsertar = "EXECUTE INSERTAR_VENTAS_FRMVENTAS " + Id + ", " + Muebleria + ", " + Trabajador + ", '" + FechaVenta + "'";

                    SqlCommand insertar_sqlCommand = new SqlCommand(strInsertar, Ventas_sqlcnn);

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
        private void btnConsultar_frmVentas_Click(object sender, EventArgs e)
        {
            String Id = txtbxID_frmVentas.Text;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_VENTAS_FRMVENTAS " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Ventas_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows) //Checa si existen registros con el Id
                {
                    while (consultar_sqldatareader.Read())
                    {
                        //Inserta los valores en los campos en el frmTrabajadores
                        txtbxMuebleria_frmVentas.Text = consultar_sqldatareader["fkID_Muebleria"].ToString();
                        txtbxTrabajador_frmVentas.Text = consultar_sqldatareader["fkID_Trabajador"].ToString();
                        dtpFechaVenta_frmVentas.Text = consultar_sqldatareader["Fecha_Venta"].ToString();
                    }
                }
                else
                {
                    //Borra todo en los campos de frmTrabajadores
                    btnLimpiar_frmVentas.PerformClick();
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
        private void btnBorrar_frmVentas_Click(object sender, EventArgs e)
        {
            //Se checa primero si existe el Id
            String Id = txtbxID_frmVentas.Text;
            String strBorrar;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_VENTAS_FRMVENTAS " + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Ventas_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows)
                {
                    //Se cierra el sqldatareader
                    consultar_sqldatareader.Close();

                    //Corre el procedimiento almacenado
                    strBorrar = "EXECUTE BORRAR_VENTAS_FRMVENTAS " + Id;

                    SqlCommand actualizar_sqlCommand = new SqlCommand(strBorrar, Ventas_sqlcnn);
                    actualizar_sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Registro Borrado");

                    //Limpia la frmTrabajadores
                    btnLimpiar_frmVentas.PerformClick();
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
        private void btnLimpiar_frmVentas_Click(object sender, EventArgs e)
        {
            txtbxID_frmVentas.Text = "";
            txtbxMuebleria_frmVentas.Text = "";
            txtbxTrabajador_frmVentas.Text = "";
            txtbxNombreTrabajador_frmVentas.Text = "";
            dtpFechaVenta_frmVentas.Value = DateTime.Now;
        }

        //Evento para actualizar el campo de txtbxTrabajadorNombre
        private void txtbxTrabajador_frmVentas_TextChanged(object sender, EventArgs e)
        {
            String Id = txtbxID_frmVentas.Text;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "SELECT Nombre_Trabajador FROM Trabajador WHERE ID_Trabajador = " + txtbxTrabajador_frmVentas.Text;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Ventas_sqlcnn;

            if (txtbxTrabajador_frmVentas.Text.Equals(""))
            {
                consultar_sqlcommand.CommandText = "SELECT Nombre_Trabajador FROM Trabajador";
            }

            consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

            //Consultar si tiene filas (registros) el ID
            if (consultar_sqldatareader.HasRows) //Checa si existen registros con el Id
            {

                SqlCommand consultarNombreTrabajador_sqlCommand = new SqlCommand(consultar_sqlcommand.CommandText, Ventas_sqlcnn);

                try {

                    while (consultar_sqldatareader.Read())
                    {
                        //Inserta los valores en los campos en el frmTrabajadores

                        txtbxNombreTrabajador_frmVentas.Text = consultar_sqldatareader["Nombre_Trabajador"].ToString();

                    }

                } catch (SqlException) {

                    MessageBox.Show("No existe Id para consultar");

                }
            } else {
                //Borra todo en los campos de frmTrabajadores
                btnLimpiar_frmVentas.PerformClick();
                MessageBox.Show("No existe registro con el id indicado");
            }
            consultar_sqldatareader.Close();

            }

        //Boton de Ingrear/Actualizar
        private void btnIngresar_ActualizarVenta_frmVentas_Click(object sender, EventArgs e)
        {
            frmVentas_Ingresar_Actualizar frmVentas_Ingresar_Actualizar = new frmVentas_Ingresar_Actualizar(Ventas_sqlcnn, this);
            frmVentas_Ingresar_Actualizar.FormClosed += new FormClosedEventHandler(frmVentas_Ingresar_Actualizar_FormClosed);
            frmVentas_Ingresar_Actualizar.Show();
            this.Hide();
        }

        private void frmVentas_Ingresar_Actualizar_FormClosed(object sender, FormClosedEventArgs e) {
            this.Show();
        }

        //Boton de Eliminar
        private void btnEliminarVentas_frmVentas_Click(object sender, EventArgs e)
        {
            frmVentas_Eliminar frmVentas_Eliminar = new frmVentas_Eliminar(Ventas_sqlcnn);
            frmVentas_Eliminar.FormClosed += new FormClosedEventHandler(frmVentas_Eliminar_FormClosed);
            frmVentas_Eliminar.Show();
            this.Hide();
        }

        private void frmVentas_Eliminar_FormClosed(object sender, EventArgs e) {
            this.Show();
        }

        //Boton de VerDetalle - Consulta
       /* private void btnVerDetalle_frmVentas_Click(object sender, EventArgs e)
        {

            //Aqui carga los datos que son los muebles de la muebleria con la cantidad y todos los datos pertinentes 
            //Crea los campos de la tabla
            DataTable dTableVentas = new DataTable();
            dTableVentas.Columns.Add("ID", typeof(int));
            dTableVentas.Columns.Add("Mueble", typeof(int));
            dTableVentas.Columns.Add("Cantidad", typeof(int));
            dTableVentas.Columns.Add("Ajuste", typeof(decimal));

            dgvVentas_frmVentas.DataSource = dTableVentas;

            String tblID, tblIDProveedor, tblNombre, tblCosto;

            //Incia el proceso para llenar la tabla
            String Id = txtbxID_frmVentas.Text;

            //Consultado si existe registro con este ID
            SqlDataReader consultar_sqldatareader;
            SqlCommand consultar_sqlcommand = new SqlCommand();

            //Comando almacenado ejecutao
            consultar_sqlcommand.CommandText = "EXECUTE CONSULTAR_MUEBLES_FRMMUEBLERIAS" + Id;
            consultar_sqlcommand.CommandType = CommandType.Text;
            consultar_sqlcommand.Connection = Ventas_sqlcnn;

            try
            {
                consultar_sqldatareader = consultar_sqlcommand.ExecuteReader();

                //Consultar si tiene filas (registros) el ID
                if (consultar_sqldatareader.HasRows) //Checa si existen registros con el Id
                {
                    while (consultar_sqldatareader.Read())
                    {
                        //Inserta los valores en los campos en el frmTrabajadores
                        tblID = consultar_sqldatareader["ID_Mueble"].ToString();
                        tblIDProveedor = consultar_sqldatareader["fkID_Proveedor_Carpinteria"].ToString();
                        tblNombre = consultar_sqldatareader["Nombre_Mueble"].ToString();
                        tblCosto = consultar_sqldatareader["Costo_Unidad"].ToString();

                        dTableVentas.Rows.Add(tblID, tblIDProveedor, tblNombre, tblCosto);
                    }
                }
                else
                consultar_sqldatareader.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Error no existen datos, Favor de ingresar ID");
            }

            dgvVentas_frmVentas.DataSource = dTableVentas;
        }
        */

        //Boton de Limpiar tabla
        private void btnLimpiarDataViewVentas_frmVentas_Click(object sender, EventArgs e)
        {
            dgvVentas_frmVentas.DataSource = "";
        }

        //Actualiacion cuando se agrega un valor a la tabla, se actualiza el subtotal
        private void dgvVentas_frmVentas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Aqui se requiere realizar el comando en donde los articulos que tiene en la tabla
            //Se agrege la suma al txtbxsubTotal
        }

        //Actualizacion cuando se borra un valor de la tabla, se actualiza el subtotal
        private void dgvVentas_frmVentas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        //Actualizacion cuando se ingresa el impuesto en el txtbxImpuestos
        private void txtbxImpuestos_frmVentas_TextChanged(object sender, EventArgs e)
        {
            //Aqui se requiere hacer la actualiacion del campo txtbxTotal
            //Multiplicas el txtbxsubtotal y el de txtbximpuestos para sacar el valor.

            //No se puede poner el impuesto mayor que 1 o 100%, ej. .8 = 80%, .08 = 8%, etc.

        }

        //Boton de vender
        private void btnVender_frmVentas_Click(object sender, EventArgs e)
        {
            //Aqui ya guarda los datos de subtotal, impuestos y total en el registro correspondiente
            //Puede mostrar una pantalla notificando de toda la info o no

        }

        //Boton de Salir
        private void btnSalir_frmVentas_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}   