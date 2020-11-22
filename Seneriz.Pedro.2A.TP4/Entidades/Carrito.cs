using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carrito<T> where T : Antiguedades
    {
        #region Atributos
        protected int capacidad;
        protected List<T> elementos;
        #endregion
        
        #region Propiedades
        /// <summary>
        /// Devuelve la lista de elementos que hay en el carrito
        /// </summary>
        public List<T> Elementos
        {
            get
            {
                return this.elementos;
            }
        }

        /// <summary>
        /// Calcula el precio total de todos los elementos del carrito
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                double precioTotal = 0;
                foreach (T item in this.elementos)
                {
                    precioTotal += item.precio;
                }
                return precioTotal;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa la lista de elementos
        /// </summary>
        public Carrito()
        {
            this.elementos = new List<T>();
        }
        /// <summary>
        /// Constructor que permite elegir la capacidad maxima del carrito
        /// </summary>
        /// <param name="capacidad"></param>
        public Carrito(int capacidad)
            : this()
        {
            this.capacidad = capacidad;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace publicos los datos del carrito y sus elementos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Carrito de: " + typeof(T));
            sb.AppendLine("Capacidad: " + this.capacidad);
            sb.AppendLine("Cantidad actual de elementos: " + this.elementos.Count);
            sb.AppendLine("Precio total: " + this.PrecioTotal);
            sb.AppendLine("");
            foreach (T item in this.Elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Agrega un elemento al carrito comprobando que el carrito no este lleno
        /// y el elemento no se encuentre en el carrito
        /// </summary>
        /// <param name="carrito"></param>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public static Carrito<T> operator +(Carrito<T> carrito, T elemento)
        {
            if (carrito.capacidad > carrito.Elementos.Count)
            {
                foreach(Antiguedades item in carrito.Elementos)
                {
                    if(item == elemento)
                    {
                        throw new ElementoRepetidoException();
                    }
                }
                carrito.Elementos.Add(elemento);
            }
            else
            {
                throw new CarritoLlenoException();
            }

            return carrito;
        }
        #endregion


    }
}
