namespace NegocioAntiguedades
{
    partial class FormVentas
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
            this.dgvProuctos = new System.Windows.Forms.DataGridView();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.btnComprar = new System.Windows.Forms.Button();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblCarrito = new System.Windows.Forms.Label();
            this.btnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProuctos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProuctos
            // 
            this.dgvProuctos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProuctos.Location = new System.Drawing.Point(12, 63);
            this.dgvProuctos.Name = "dgvProuctos";
            this.dgvProuctos.Size = new System.Drawing.Size(400, 260);
            this.dgvProuctos.TabIndex = 0;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(572, 63);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.Size = new System.Drawing.Size(400, 260);
            this.dgvCarrito.TabIndex = 1;
            // 
            // btnComprar
            // 
            this.btnComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.Location = new System.Drawing.Point(872, 382);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(86, 40);
            this.btnComprar.TabIndex = 5;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(97, 29);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(198, 31);
            this.lblProductos.TabIndex = 9;
            this.lblProductos.Text = "PRODUCTOS";
            // 
            // lblCarrito
            // 
            this.lblCarrito.AutoSize = true;
            this.lblCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrito.Location = new System.Drawing.Point(656, 29);
            this.lblCarrito.Name = "lblCarrito";
            this.lblCarrito.Size = new System.Drawing.Size(145, 31);
            this.lblCarrito.TabIndex = 8;
            this.lblCarrito.Text = "CARRITO";
            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlCarrito.Location = new System.Drawing.Point(213, 336);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new System.Drawing.Size(199, 40);
            this.btnAgregarAlCarrito.TabIndex = 2;
            this.btnAgregarAlCarrito.Text = "Agregar al carrito";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = true;
            this.btnAgregarAlCarrito.Click += new System.EventHandler(this.btnAgregarAlCarrito_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(572, 382);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(872, 336);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(100, 29);
            this.txtSubtotal.TabIndex = 7;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Location = new System.Drawing.Point(572, 336);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(199, 40);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.Text = "Quitar del carrito";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(410, 9);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(110, 20);
            this.lblHora.TabIndex = 10;
            this.lblHora.Text = "FechaYHora";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarAlCarrito);
            this.Controls.Add(this.lblCarrito);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.dgvProuctos);
            this.Name = "FormVentas";
            this.Text = "SECCION VENTAS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentas_FormClosing);
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProuctos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProuctos;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblCarrito;
        private System.Windows.Forms.Button btnAgregarAlCarrito;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblHora;
    }
}