using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NegocioAntiguedades
{
    public partial class FormVentas : Form
    {
        #region Atributos
        private SqlConnection cn;
        private SqlDataAdapter da;
        private DataTable dt;
        private DataTable dtCarrito;

        private AccesoDatos pedro = new AccesoDatos();
        #endregion

        /// <summary>
        /// Creo un datatable para los productos y otro para el carrito
        /// Le agrego las columnas a la tabla de carrito
        /// La tabla de productos la saco de la base de datos
        /// le asigno las tablas a las grillas
        /// </summary>
        public FormVentas()
        {
            InitializeComponent();
            this.dt = new DataTable("productos");
            this.dtCarrito = new DataTable("carrito");

            this.dtCarrito.Columns.Add("codigo");
            this.dtCarrito.Columns.Add("precio");
            this.dtCarrito.Columns.Add("anio");
            this.dtCarrito.Columns.Add("tipo");
            this.dtCarrito.Columns.Add("almohadones");
            this.dtCarrito.Columns.Add("cajones");
            this.dtCarrito.Columns.Add("puertas");
            this.dtCarrito.Columns.Add("patas");
            this.dtCarrito.Columns.Add("capacidad");

            this.dgvProuctos.MultiSelect = false;
            this.dgvProuctos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProuctos.AllowUserToAddRows = false;

            try
            {
                string stringConnection = "Data Source= localhost\\SQLEXPRESS;Initial Catalog = tp4Productos; Integrated Security = True ";
                this.cn = new SqlConnection(stringConnection);

                this.da = new SqlDataAdapter("Select * FROM productos", this.cn);

                this.da.Fill(this.dt);
                
                this.dgvProuctos.DataSource = this.dt;
                this.dgvCarrito.DataSource = this.dtCarrito;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Cuando cargo el formulario configuro las grillas
        /// inicio el hilo y asigno el evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVentas_Load(object sender, EventArgs e)
        {
            this.ConfigurarGrilla();
            this.ConfigurarGrilla2();

            this.hilo = new Thread(Actualizar);
            this.Evento += ActualizarHora;
            this.hilo.Start();
        }

        /// <summary>
        /// Formclosing para cerrar el hilo cuando salgo del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.hilo.IsAlive)
            {
                this.hilo.Abort();
            }
        }

        #region Configurar Grillas
        private void ConfigurarGrilla()
        {
            // Coloco color de fondo para las filas
            this.dgvCarrito.RowsDefaultCellStyle.BackColor = Color.Wheat;

            // Alterno colores
            this.dgvCarrito.AlternatingRowsDefaultCellStyle.BackColor = Color.BurlyWood;

            // Pongo color de fondo a la grilla
            this.dgvCarrito.BackgroundColor = Color.Beige;

            // Defino fuente para el encabezado y alineación del encabezado
            this.dgvCarrito.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCarrito.Font, FontStyle.Bold);
            this.dgvCarrito.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Defino el color de las lineas de separación
            this.dgvCarrito.GridColor = Color.HotPink;

            // La grilla será de sólo lectura
            this.dgvCarrito.ReadOnly = true;

            // No permito la multiselección
            this.dgvCarrito.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            //this.dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Indico el color de la fila seleccionada
            this.dgvCarrito.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOliveGreen;
            this.dgvCarrito.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            // No permito modificar desde la grilla
            this.dgvCarrito.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dgvCarrito.RowHeadersVisible = false;

        }
        private void ConfigurarGrilla2()
        {
            // Coloco color de fondo para las filas
            this.dgvProuctos.RowsDefaultCellStyle.BackColor = Color.Wheat;

            // Alterno colores
            this.dgvProuctos.AlternatingRowsDefaultCellStyle.BackColor = Color.BurlyWood;

            // Pongo color de fondo a la grilla
            this.dgvProuctos.BackgroundColor = Color.Beige;

            // Defino fuente para el encabezado y alineación del encabezado
            this.dgvProuctos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProuctos.Font, FontStyle.Bold);
            this.dgvProuctos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Defino el color de las lineas de separación
            this.dgvProuctos.GridColor = Color.HotPink;

            // La grilla será de sólo lectura
            this.dgvProuctos.ReadOnly = true;

            // No permito la multiselección
            this.dgvProuctos.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dgvProuctos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            //this.dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Indico el color de la fila seleccionada
            this.dgvProuctos.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOliveGreen;
            this.dgvProuctos.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            // No permito modificar desde la grilla
            this.dgvProuctos.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dgvProuctos.RowHeadersVisible = false;

        }
        #endregion

        #region Botones
        /// <summary>
        /// Ejecuta la compra de los productos del carrito
        /// Toma los datos de todos los productos en el carrito y imprime el ticket
        /// Elimina el producto de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                foreach (DataGridViewRow data in this.dgvCarrito.Rows)
                {
                    sb.AppendLine("Codigo: " + data.Cells[0].Value.ToString());
                    sb.AppendLine("Precio: " + data.Cells[1].Value.ToString());
                    sb.AppendLine("Año: " + data.Cells[2].Value.ToString());
                    sb.AppendLine("Tipo: " + data.Cells[3].Value.ToString());
                    sb.AppendLine("");

                    pedro.EliminarProducto(int.Parse(data.Cells[0].Value.ToString()));

                }
            }
            catch (NullReferenceException)
            {
                //No hago nada, xq siempre me toma la ultima fila nula.Con esto la ignoro
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (Ticketadora.ImprimirTicket(sb.ToString()))
            {
                MessageBox.Show("Ticket impreso correctamente", "Compra confirmada");
            }

            //Asigno un formclosing para que no quede el hilo abierto
            this.FormVentas_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Pasa un producto de la fila de productos al carrito
        /// Compruebo si hay lugar disponible en el carrito
        /// busco la fila seleccionada en la grilla de productos y copio sus valores en una nueva fila en la grilla de carrito
        /// elimino el producto de la fila de productos
        /// Calculo el precio nuevo del carrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarrito.Rows.Count > 5)
                {
                    throw new CarritoLlenoException();
                }

                foreach (DataGridViewRow fila in this.dgvProuctos.Rows)
                {
                    if (fila.Selected == true)
                    {
                        this.dtCarrito.Rows.Add(fila.Cells[0].Value, fila.Cells[1].Value, fila.Cells[2].Value, fila.Cells[3].Value, fila.Cells[4].Value, fila.Cells[5].Value, fila.Cells[6].Value, fila.Cells[7].Value, fila.Cells[8].Value);
                        CalcularSubtotal();
                        this.dt.Rows.RemoveAt(dgvProuctos.CurrentRow.Index);
                        break;
                    }
                }
            }
            catch (CarritoLlenoException ex)
            {
                MessageBox.Show(ex.InformarError());
            }
        }

        /// <summary>
        /// Hago un formclosing para terminar el hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormClosingEventArgs fclosing = new FormClosingEventArgs(CloseReason.UserClosing, false);
            this.FormVentas_FormClosing(sender, fclosing);
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Quita un producto del carrito y lo devuelve a la grilla de productos
        /// copia los datos del producto seleccionado en la grilla de carrito en una nueva fila en la grilla de productos
        /// elimina el producto de la grilla de carrito
        /// calcula el precio nuevo del carrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow fila in dgvCarrito.Rows)
                {
                    if (fila.Selected == true)
                    {
                        if (dgvCarrito.CurrentRow == null)
                        {
                            throw new Exception("No hay productos para sacar del carrito");
                        }

                        this.dt.Rows.Add(fila.Cells[0].Value, fila.Cells[1].Value, fila.Cells[2].Value, fila.Cells[3].Value, fila.Cells[4].Value, fila.Cells[5].Value, fila.Cells[6].Value, fila.Cells[7].Value, fila.Cells[8].Value);
                        this.dtCarrito.Rows.RemoveAt(dgvCarrito.CurrentRow.Index);
                        CalcularSubtotal();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Funcion para calcular el valor del textbox "Subtotal"
        /// Sumo los valores de la columna precio de todas las filas en la tabla carrito y lo pongo en el textbox
        /// </summary>
        private void CalcularSubtotal()
        {
            double suma = 0;
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    suma += double.Parse(row.Cells[1].Value.ToString());
                }
            }
            this.txtSubtotal.Text = suma.ToString();
        }
        #endregion

        #region Hilos y Delegados
        /// <summary>
        /// Declaro el hilo, el delegado y el evento
        /// </summary>
        Thread hilo;
        public delegate void DelegadoHora();
        public event DelegadoHora Evento;

        /// <summary>
        /// Invoca al delegado para que actualice el label de la fecha y hora
        /// </summary>
        public void ActualizarHora()
        {
            if (this.lblHora.InvokeRequired)
            {
                DelegadoHora dh = new DelegadoHora(ActualizarHora);
                this.Invoke(dh);
            }
            else
            {
                this.lblHora.Text = DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// Hace que el evento se actualice cada 200ms
        /// </summary>
        public void Actualizar()
        {
            do
            {
                Thread.Sleep(200);
                this.Evento();
            } while (true);
        }

        #endregion


        
    }
}
