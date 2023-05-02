using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using negocio;

namespace negocio
{
    public class EstiloNegocio
    {
      public List<Estilo> listar()
        {
            List<Estilo> estilos = new List<Estilo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion from ESTILOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilo aux = new Estilo();
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Id = (int)datos.Lector["Id"];

                    estilos.Add(aux);
                }

                return estilos;
                

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
