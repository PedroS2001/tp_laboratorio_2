using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NegocioAntiguedades
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Botones
        /// <summary>
        /// Abre el formulario para agregar un nuevo producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar frm= new FormAgregar();

            if (frm.ShowDialog() == DialogResult.OK)
                MessageBox.Show("Se agrego el producto correctamente");

        }

        /// <summary>
        /// Abre el formulario para realizar una venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            FormVentas frm = new FormVentas();

            frm.ShowDialog();
        }

        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
