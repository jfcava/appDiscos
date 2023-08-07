using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using dominio;



namespace negocio
{
    public class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database = DISCOS_DB; integrated security=true";
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion TipoEdicion, D.IdEstilo, D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo = E.Id And D.IdTipoEdicion = T.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];

                    // Validacion - Si NO ES dbnull, toma el valor, sino queda vacio
                    if (!(lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    
                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)lector["Estilo"];
                    aux.Estilo.Id = (int)lector["IdEstilo"];
                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Descripcion = (string)lector["TipoEdicion"];
                    aux.TipoEdicion.Id = (int)lector["IdTipoEdicion"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones,UrlImagenTapa,IdEstilo,IdTipoEdicion) values ('" + nuevo.Titulo + "','19870521',"+ nuevo.CantidadCanciones +",@UrlImagenTapa,@IdEstilo,@IdTipoEdicion)");
                datos.setearParametros("@IdEstilo", nuevo.Estilo.Id);
                datos.setearParametros("@IdTipoEdicion", nuevo.TipoEdicion.Id);
                datos.setearParametros("UrlImagenTapa", nuevo.UrlImagenTapa);
                datos.ejecutarEscritura();            
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
              

        }
        public void modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fechaLanza, CantidadCanciones = @cantCanciones, UrlImagenTapa = @urlImagen, IdEstilo=@idEstilo, IdTipoEdicion= @idEdicion where id=@id");
                datos.setearParametros("@titulo", disco.Titulo);
                datos.setearParametros("@fechaLanza", disco.FechaLanzamiento);
                datos.setearParametros("@cantCanciones", disco.CantidadCanciones);
                datos.setearParametros("@urlImagen", disco.UrlImagenTapa);
                datos.setearParametros("@idEstilo", disco.Estilo.Id);
                datos.setearParametros("@idEdicion", disco.TipoEdicion.Id);
                datos.setearParametros("@id", disco.Id);

                datos.ejecutarEscritura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from DISCOS where id=@id");
                datos.setearParametros("id", id);

                datos.ejecutarEscritura();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }        

    }
}
