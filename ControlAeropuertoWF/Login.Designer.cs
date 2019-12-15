namespace ControlAeropuertoWF
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConstrasenya = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.labelConstrasenya = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.txtConstrasenya);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.buttonAceptar);
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.labelConstrasenya);
            this.panel1.Controls.Add(this.labelUsuario);
            this.panel1.Location = new System.Drawing.Point(277, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 256);
            this.panel1.TabIndex = 0;
            // 
            // txtConstrasenya
            // 
            this.txtConstrasenya.Location = new System.Drawing.Point(53, 107);
            this.txtConstrasenya.Name = "txtConstrasenya";
            this.txtConstrasenya.PasswordChar = '*';
            this.txtConstrasenya.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConstrasenya.Size = new System.Drawing.Size(145, 20);
            this.txtConstrasenya.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(53, 57);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(145, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(135, 189);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(76, 34);
            this.buttonAceptar.TabIndex = 3;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseMnemonic = false;
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(50, 147);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(86, 13);
            this.labelError.TabIndex = 2;
            this.labelError.Text = "Mensaje de error";
            // 
            // labelConstrasenya
            // 
            this.labelConstrasenya.AutoSize = true;
            this.labelConstrasenya.Location = new System.Drawing.Point(50, 91);
            this.labelConstrasenya.Name = "labelConstrasenya";
            this.labelConstrasenya.Size = new System.Drawing.Size(61, 13);
            this.labelConstrasenya.TabIndex = 1;
            this.labelConstrasenya.Text = "Contraseña";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(50, 37);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "Usuario";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtConstrasenya;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelConstrasenya;
        private System.Windows.Forms.Label labelUsuario;
    }
}

