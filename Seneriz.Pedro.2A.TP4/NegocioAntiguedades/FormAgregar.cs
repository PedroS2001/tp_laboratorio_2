using Entidades;
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
    public partial class FormAgregar : Form
    {
        #region Atributos
        private AccesoDatos pedro = new AccesoDatos();
        private Antiguedades antiguedad;
        #endregion

        /// <summary>
        /// Oculto todos los textbox
        /// inicio el formulario en el centro
        /// </summary>
        public FormAgregar()
        {
            InitializeComponent();

            this.txtAlmohadones.Hide();
            this.txtCajones.Hide();
            this.txtCapacidad.Hide();
            this.txtPatas.Hide();
            this.txtPuertas.Hide();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Botones
        /// <summary>
        /// Crea un producto con los datos recogidos de los textbox
        /// Genero un codigo valido
        /// Segun el valor del combobox se que producto ingresa
        /// creo un producto y lo agrego a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoNuevo = this.antiguedad != null ? this.antiguedad.codigo : 0;

                switch (this.cmbTipo.SelectedIndex)
                {
                    case 0://Armario
                        Armario armarito = new Armario(double.Parse(this.txtPrecio.Text), int.Parse(this.txtAnio.Text),
                            int.Parse(this.txtPuertas.Text), int.Parse(this.txtCajones.Text), CodigoNuevo, this.cmbTipo.Text.ToString());
                        if (pedro.InsertarArmario(armarito))
                            this.DialogResult = DialogResult.OK;
                        break;

                    case 1://Mesa
                        Mesa mesita = new Mesa(double.Parse(this.txtPrecio.Text), int.Parse(this.txtAnio.Text),
                            int.Parse(this.txtPatas.Text), int.Parse(this.txtCapacidad.Text), CodigoNuevo, this.cmbTipo.Text.ToString());
                        if (pedro.InsertarMesa(mesita))
                            this.DialogResult = DialogResult.OK;
                        break;

                    case 2://Sillon
                        Sillon silloncito = new Sillon(double.Parse(this.txtPrecio.Text), int.Parse(this.txtAnio.Text),
                            int.Parse(this.txtAlmohadones.Text), CodigoNuevo, this.cmbTipo.Text.ToString());
                        if (pedro.InsertarSillon(silloncito))
                            this.DialogResult = DialogResult.OK;
                        break;
                    default:
                        MessageBox.Show("Debe seleccionar un tipo");
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Cancela la subida de producto y cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        /// <summary>
        /// Decide que textbox mostrar segun el valor del combobox
        /// cada vez que se cambie el valor, mostrara los textbox que corresponden llenar y ocultara los que no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtAlmohadones.Hide();
            this.txtCajones.Hide();
            this.txtCapacidad.Hide();
            this.txtPatas.Hide();
            this.txtPuertas.Hide();

            switch (this.cmbTipo.SelectedIndex)
            {
                case 0:
                    this.txtPuertas.Show();
                    this.txtCajones.Show();
                    break;
                case 1:
                    this.txtCapacidad.Show();
                    this.txtPatas.Show();
                    break;
                case 2:
                    this.txtAlmohadones.Show();
                    break;
            }
        }
        #region Validaciones
        /// <summary>
        /// Valida que lo ingresado en los textbox sean solo numeros
        /// </summary>
        /// <param name="V"></param>
        public static void SoloNumeros(KeyPressEventArgs V)
        {
            if (char.IsDigit(V.KeyChar))
            {
                V.Handled = false;
            }
            else if(char.IsControl(V.KeyChar))
            {
                V.Handled = false;
            }
            else
            {
                V.Handled = true;
            }
        }

        /// <summary>
        /// Este evento se le agrega a todos los textbox.Valida que sean solo numeros en cada tecla que se presiona dentro de ellos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormAgregar.SoloNumeros(e);
        }
        #endregion
    }
}


