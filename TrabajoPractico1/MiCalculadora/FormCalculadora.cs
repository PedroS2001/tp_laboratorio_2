using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            //agrego esto para que el primer operador sea en blanco y no nulo
            this.cmbOperador.Items.Insert(0, "");
            this.cmbOperador.SelectedIndex = 0;
            
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            string operador = Convert.ToString(this.cmbOperador.SelectedItem);
            resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, operador);

            this.lblResultado.Text = resultado.ToString();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            double retorno = Calculadora.Operar(num1,num2,operador);

            return retorno;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        /// <summary>
        /// limpia los textbox, el label de resultado y el combobox en blanco
        /// </summary>
        private void limpiar()
        {
            this.cmbOperador.SelectedIndex = 0;
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// pregunta si esta seguro de cerrar la calculadora y la cierra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que quiere cerrar la calculadora?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero binario = new Numero();
            if (!string.IsNullOrEmpty(this.lblResultado.Text))
                this.lblResultado.Text = binario.DecimalBinario(this.lblResultado.Text);
            else
                this.lblResultado.Text = "Valor invalido";
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero nDecimal = new Numero();
            if (!string.IsNullOrEmpty(this.lblResultado.Text) )
                this.lblResultado.Text = nDecimal.BinarioDecimal(this.lblResultado.Text);
            else
                this.lblResultado.Text = "Valor invalido";
        }
    }
}
