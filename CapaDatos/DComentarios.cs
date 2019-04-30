using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DComentarios
    {
        #region MENSAJE
        private void SqlCon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.Mensaje_respuesta = e.Message;
        }
        #endregion

        #region VARIABLES

        string _mensaje_respuesta;

        public string Mensaje_respuesta
        {
            get
            {
                return _mensaje_respuesta;
            }

            set
            {
                _mensaje_respuesta = value;
            }
        }
        #endregion

        #region METODO INSERTAR COMENTARIO
        public string InsertarComentario(out int id_comentario, int id_persona,
            int id_entrada, string descripcion)
        {
            id_comentario = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            //Capturador de errores
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Insertar_comentario",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_comentario = new SqlParameter
                {
                    ParameterName = "@Id_comentario",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_comentario);

                SqlParameter Id_persona = new SqlParameter
                {
                    ParameterName = "@Id_persona",
                    SqlDbType = SqlDbType.Int,
                    Value = id_persona
                };
                SqlCmd.Parameters.Add(Id_persona);

                SqlParameter Id_entrada = new SqlParameter
                {
                    ParameterName = "@Id_entrada",
                    SqlDbType = SqlDbType.Int,
                    Value = id_entrada
                };
                SqlCmd.Parameters.Add(Id_entrada);

                SqlParameter Descripcion = new SqlParameter
                {
                    ParameterName = "@Descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = descripcion
                };
                SqlCmd.Parameters.Add(Descripcion);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    id_comentario = Convert.ToInt32(SqlCmd.Parameters["@Id_comentario"].Value);
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }

        #endregion

        #region METODO EDITAR COMENTARIO
        public string EditarComentario(int id_comentario, int id_persona,
            int id_entrada, string descripcion)
        {
            id_comentario = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            //Capturador de errores
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Editar_comentario",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_comentario = new SqlParameter
                {
                    ParameterName = "@Id_comentario",
                    SqlDbType = SqlDbType.Int,
                    Value = id_comentario
                };
                SqlCmd.Parameters.Add(Id_comentario);

                SqlParameter Id_persona = new SqlParameter
                {
                    ParameterName = "@Id_persona",
                    SqlDbType = SqlDbType.Int,
                    Value = id_persona
                };
                SqlCmd.Parameters.Add(Id_persona);

                SqlParameter Id_entrada = new SqlParameter
                {
                    ParameterName = "@Id_entrada",
                    SqlDbType = SqlDbType.Int,
                    Value = id_entrada
                };
                SqlCmd.Parameters.Add(Id_entrada);

                SqlParameter Descripcion = new SqlParameter
                {
                    ParameterName = "@Descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = descripcion
                };
                SqlCmd.Parameters.Add(Descripcion);

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }

        #endregion

        #region METODO BUSCAR COMENTARIO

        public DataTable BuscarComentarios(string tipo_busqueda, string texto_busqueda,
            out string rpta)
        {
            rpta = "OK";
            DataTable DtResultado = new DataTable("Comentarios");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Buscar_comentarios",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Tipo_busqueda = new SqlParameter
                {
                    ParameterName = "@Tipo_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Tipo_busqueda);

                SqlParameter Texto_busqueda = new SqlParameter
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(Sqlcmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    DtResultado = null;
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            return DtResultado;
        }

        #endregion
    }
}
