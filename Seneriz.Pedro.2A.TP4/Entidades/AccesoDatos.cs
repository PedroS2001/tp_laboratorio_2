using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AccesoDatos
    {
        #region Atributos
        public SqlConnection conexion;
        private SqlCommand comando;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que asigna el path de conexion
        /// </summary>
        public AccesoDatos()
        {
            this.conexion = new SqlConnection("Data Source= localhost\\SQLEXPRESS;Initial Catalog =tp4Productos; Integrated Security = True ");
        }
        #endregion

        #region Insertar
        /// <summary>
        /// Inserta un armario en la base de datos
        /// Cambia los comandos del sql para insertar un armario con todos sus datos
        /// </summary>
        /// <param name="item">Armario que se va a agregar en la base de datos</param>
        /// <returns></returns>
        public bool InsertarArmario(Armario item)
        {
            bool todoOk = false;

            string sql = "INSERT INTO productos (precio, anio, tipo, cajones, puertas)";
            sql += "VALUES (@precio, @anio, @tipo, @cajones, @puertas)";

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@precio", item.precio);
                this.comando.Parameters.AddWithValue("@anio", item.anio);
                this.comando.Parameters.AddWithValue("@tipo", item.tipo);
                this.comando.Parameters.AddWithValue("@cajones", item.cajones);
                this.comando.Parameters.AddWithValue("@puertas", item.puertas);

                this.comando.CommandText = sql;

                this.conexion.Open();
                this.comando.ExecuteNonQuery();
                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }

        /// <summary>
        /// Inserta un sillon en la base de datos
        /// </summary>
        /// <param name="item">Sillon que se va a agregar</param>
        /// <returns></returns>
        public bool InsertarSillon(Sillon item)
        {
            bool todoOk = false;

            string sql = "INSERT INTO productos (precio, anio, tipo, almohadones)";
            sql += "VALUES (@precio, @anio, @tipo, @almohadones)";

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@precio", item.precio);
                this.comando.Parameters.AddWithValue("@anio", item.anio);
                this.comando.Parameters.AddWithValue("@tipo", "Sillon");
                this.comando.Parameters.AddWithValue("@almohadones", item.Almohadones);


                this.comando.CommandText = sql;

                this.conexion.Open();
                this.comando.ExecuteNonQuery();
                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }

        /// <summary>
        /// Inserta una mesa en la base de datos
        /// </summary>
        /// <param name="item">Mesa que se va a agregar</param>
        /// <returns></returns>
        public bool InsertarMesa(Mesa item)
        {
            bool todoOk = false;

            string sql = "INSERT INTO productos (precio, anio, tipo, patas, capacidad)";
            sql += "VALUES (@precio, @anio, @tipo, @patas, @capacidad)";

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@precio", item.precio);
                this.comando.Parameters.AddWithValue("@anio", item.anio);
                this.comando.Parameters.AddWithValue("@tipo", "Mesa");
                this.comando.Parameters.AddWithValue("@patas", item.Patas);
                this.comando.Parameters.AddWithValue("@capacidad", item.Capacidad);

                this.comando.CommandText = sql;

                this.conexion.Open();
                this.comando.ExecuteNonQuery();
                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }
        #endregion

        #region Eliminar
        /// <summary>
        /// Elimina un producto de la base de datos segun su codigo
        /// </summary>
        /// <param name="code">Codigo del producto que quiero eliminar</param>
        /// <returns></returns>
        public bool EliminarProducto(int code)
        {
            bool todoOk = false;

            string sql = "DELETE FROM productos WHERE codigo = @codigo";

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;

                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@codigo", code);

                this.comando.CommandText = sql;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return todoOk;
        }
        #endregion
    }
}
