namespace Proyecto_BDll
{
    partial class frmMueblerias_Eliminar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblID_frmMueble_Eliminar = new System.Windows.Forms.Label();
            this.cmbbxID_frmMueblerias_Eliminar = new System.Windows.Forms.ComboBox();
            this.btnGuardar_frmMueblerias_Eliminar = new System.Windows.Forms.Button();
            this.btnCancelar_frmMueblerias_Eliminar = new System.Windows.Forms.Button();
            this.txtboxNombre_frmMueblerias_Eliminar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblID_frmMueble_Eliminar
            // 
            this.lblID_frmMueble_Eliminar.AutoSize = true;
            this.lblID_frmMueble_Eliminar.Location = new System.Drawing.Point(23, 9);
            this.lblID_frmMueble_Eliminar.Name = "lblID_frmMueble_Eliminar";
            this.lblID_frmMueble_Eliminar.Size = new System.Drawing.Size(171, 13);
            this.lblID_frmMueble_Eliminar.TabIndex = 0;
            this.lblID_frmMueble_Eliminar.Text = "Ingresar el ID del mueble a eliminar";
            // 
            // cmbbxID_frmMueblerias_Eliminar
            // 
            this.cmbbxID_frmMueblerias_Eliminar.FormattingEnabled = true;
            this.cmbbxID_frmMueblerias_Eliminar.Location = new System.Drawing.Point(15, 37);
            this.cmbbxID_frmMueblerias_Eliminar.Name = "cmbbxID_frmMueblerias_Eliminar";
            this.cmbbxID_frmMueblerias_Eliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbbxID_frmMueblerias_Eliminar.Size = new System.Drawing.Size(188, 21);
            this.cmbbxID_frmMueblerias_Eliminar.TabIndex = 1;
            this.cmbbxID_frmMueblerias_Eliminar.SelectedValueChanged += new System.EventHandler(this.cmbbxID_frmMueblerias_Eliminar_SelectedValueChanged);
            // 
            // btnGuardar_frmMueblerias_Eliminar
            // 
            this.btnGuardar_frmMueblerias_Eliminar.Location = new System.Drawing.Point(15, 124);
            this.btnGuardar_frmMueblerias_Eliminar.Name = "btnGuardar_frmMueblerias_Eliminar";
            this.btnGuardar_frmMueblerias_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar_frmMueblerias_Eliminar.TabIndex = 2;
            this.btnGuardar_frmMueblerias_Eliminar.Text = "Guardar";
            this.btnGuardar_frmMueblerias_Eliminar.UseVisualStyleBackColor = true;
            this.btnGuardar_frmMueblerias_Eliminar.Click += new System.EventHandler(this.btnGuardar_frmMueblerias_Eliminar_Click);
            // 
            // btnCancelar_frmMueblerias_Eliminar
            // 
            this.btnCancelar_frmMueblerias_Eliminar.Location = new System.Drawing.Point(128, 124);
            this.btnCancelar_frmMueblerias_Eliminar.Name = "btnCancelar_frmMueblerias_Eliminar";
            this.btnCancelar_frmMueblerias_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar_frmMueblerias_Eliminar.TabIndex = 3;
            this.btnCancelar_frmMueblerias_Eliminar.Text = "Cancelar";
            this.btnCancelar_frmMueblerias_Eliminar.UseVisualStyleBackColor = true;
            this.btnCancelar_frmMueblerias_Eliminar.Click += new System.EventHandler(this.btnCancelar_frmMueblerias_Eliminar_Click);
            // 
            // txtboxNombre_frmMueblerias_Eliminar
            // 
            this.txtboxNombre_frmMueblerias_Eliminar.Location = new System.Drawing.Point(15, 75);
            this.txtboxNombre_frmMueblerias_Eliminar.Name = "txtboxNombre_frmMueblerias_Eliminar";
            this.txtboxNombre_frmMueblerias_Eliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtboxNombre_frmMueblerias_Eliminar.Size = new System.Drawing.Size(188, 20);
            this.txtboxNombre_frmMueblerias_Eliminar.TabIndex = 4;
            this.txtboxNombre_frmMueblerias_Eliminar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmMueblerias_Eliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 159);
            this.Controls.Add(this.txtboxNombre_frmMueblerias_Eliminar);
            this.Controls.Add(this.btnCancelar_frmMueblerias_Eliminar);
            this.Controls.Add(this.btnGuardar_frmMueblerias_Eliminar);
            this.Controls.Add(this.cmbbxID_frmMueblerias_Eliminar);
            this.Controls.Add(this.lblID_frmMueble_Eliminar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMueblerias_Eliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMueblerias_Eliminar";
            this.Load += new System.EventHandler(this.frmMueblerias_Eliminar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID_frmMueble_Eliminar;
        private System.Windows.Forms.ComboBox cmbbxID_frmMueblerias_Eliminar;
        private System.Windows.Forms.Button btnGuardar_frmMueblerias_Eliminar;
        private System.Windows.Forms.Button btnCancelar_frmMueblerias_Eliminar;
        private System.Windows.Forms.TextBox txtboxNombre_frmMueblerias_Eliminar;
    }
}