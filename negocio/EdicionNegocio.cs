using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EdicionNegocio
    {
        public List<TipoEdicion> listar()
        {
			List<TipoEdicion> lista = new List<TipoEdicion>();
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearConsulta("select Id, Descripcion from TIPOSEDICION");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					TipoEdicion aux = new TipoEdicion();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}				
				
				return lista;
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
