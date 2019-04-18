namespace Proyecto_BDll
{
    partial class frmMenu
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
            this.btnTrabajadores_frmMenu = new System.Windows.Forms.Button();
            this.btnProveedores_frmMenu = new System.Windows.Forms.Button();
            this.btnMuebleria_frmMenu = new System.Windows.Forms.Button();
            this.btnVentas_frmMenu = new System.Windows.Forms.Button();
            this.picBox_Logo_frmMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Logo_frmMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrabajadores_frmMenu
            // 
            this.btnTrabajadores_frmMenu.Location = new System.Drawing.Point(361, 12);
            this.btnTrabajadores_frmMenu.Name = "btnTrabajadores_frmMenu";
            this.btnTrabajadores_frmMenu.Size = new System.Drawing.Size(94, 23);
            this.btnTrabajadores_frmMenu.TabIndex = 0;
            this.btnTrabajadores_frmMenu.Text = "Trabajadores";
            this.btnTrabajadores_frmMenu.UseVisualStyleBackColor = true;
            this.btnTrabajadores_frmMenu.Click += new System.EventHandler(this.btnTrabajadores_frmMenu_Click);
            // 
            // btnProveedores_frmMenu
            // 
            this.btnProveedores_frmMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnProveedores_frmMenu.Location = new System.Drawing.Point(361, 41);
            this.btnProveedores_frmMenu.Name = "btnProveedores_frmMenu";
            this.btnProveedores_frmMenu.Size = new System.Drawing.Size(94, 23);
            this.btnProveedores_frmMenu.TabIndex = 1;
            this.btnProveedores_frmMenu.Text = "Proveedores";
            this.btnProveedores_frmMenu.UseVisualStyleBackColor = true;
            this.btnProveedores_frmMenu.Click += new System.EventHandler(this.btnProveedores_frmMenu_Click);
            // 
            // btnMuebleria_frmMenu
            // 
            this.btnMuebleria_frmMenu.Location = new System.Drawing.Point(361, 70);
            this.btnMuebleria_frmMenu.Name = "btnMuebleria_frmMenu";
            this.btnMuebleria_frmMenu.Size = new System.Drawing.Size(94, 23);
            this.btnMuebleria_frmMenu.TabIndex = 2;
            this.btnMuebleria_frmMenu.Text = "Mueblerias";
            this.btnMuebleria_frmMenu.UseVisualStyleBackColor = true;
            this.btnMuebleria_frmMenu.Click += new System.EventHandler(this.btnMuebleria_frmMenu_Click);
            // 
            // btnVentas_frmMenu
            // 
            this.btnVentas_frmMenu.Location = new System.Drawing.Point(361, 99);
            this.btnVentas_frmMenu.Name = "btnVentas_frmMenu";
            this.btnVentas_frmMenu.Size = new System.Drawing.Size(94, 23);
            this.btnVentas_frmMenu.TabIndex = 3;
            this.btnVentas_frmMenu.Text = "Ventas";
            this.btnVentas_frmMenu.UseVisualStyleBackColor = true;
            this.btnVentas_frmMenu.Click += new System.EventHandler(this.btnVentas_frmMenu_Click);
            // 
            // picBox_Logo_frmMenu
            // 
            this.picBox_Logo_frmMenu.BackColor = System.Drawing.Color.Transparent;
            this.picBox_Logo_frmMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBox_Logo_frmMenu.Image = global::Proyecto_BDll.Properties.Resources.Muebles;
            this.picBox_Logo_frmMenu.InitialImage = null;
            this.picBox_Logo_frmMenu.Location = new System.Drawing.Point(12, 2);
            this.picBox_Logo_frmMenu.Name = "picBox_Logo_frmMenu";
            this.picBox_Logo_frmMenu.Size = new System.Drawing.Size(330, 290);
            this.picBox_Logo_frmMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_Logo_frmMenu.TabIndex = 4;
            this.picBox_Logo_frmMenu.TabStop = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnProveedores_frmMenu;
            this.ClientSize = new System.Drawing.Size(467, 292);
            this.Controls.Add(this.picBox_Logo_frmMenu);
            this.Controls.Add(this.btnVentas_frmMenu);
            this.Controls.Add(this.btnMuebleria_frmMenu);
            this.Controls.Add(this.btnProveedores_frmMenu);
            this.Controls.Add(this.btnTrabajadores_frmMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Logo_frmMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrabajadores_frmMenu;
        private System.Windows.Forms.Button btnProveedores_frmMenu;
        private System.Windows.Forms.Button btnMuebleria_frmMenu;
        private System.Windows.Forms.Button btnVentas_frmMenu;
        private System.Windows.Forms.PictureBox picBox_Logo_frmMenu;
    }
}