using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Utilidades;

namespace Dominio.Repositorios
{
    public class RepositorioBarrio : InterfacesRepositorios.IRepositorioBarrio
    {
        public bool Add(Barrio unBarrio)
        {
            return unBarrio != null && unBarrio.Validar() && unBarrio.Insertar();
        }

        public bool Delete(Barrio unBarrio)
        {
            return unBarrio != null && unBarrio.Eliminar();
        }

        public bool Update(Barrio unBarrio)
        {
            return unBarrio != null && unBarrio.Validar() && unBarrio.Modificar();
        }

        public IEnumerable<Barrio> FindAll()
        {
            List<Barrio> lista = new List<Barrio>();
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            string consulta = @"SELECT b.nombre, b.descripcion FROM barrio b";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Utilidades.Utilidades.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lista.Add(CargarDesdeRecord(dr));
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, ex.Message);
                return null;
            }
            finally{
                Utilidades.Utilidades.CerrarConexion(cn);
            }
        }

        public Barrio FindByName(string nombre)
        {
            Barrio unBarrio = null;
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            string consulta = @"SELECT b.nombre, b.descripcion 
                                FROM barrio b
                                WHERE b.nombre = @nombre";
            //Preparar el comando
            SqlCommand cmd =
                new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));

            try
            {
                Utilidades.Utilidades.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                //Leer el reader y cargar los objetos en la lista de retorno
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        unBarrio = CargarDesdeRecord(dr);
                    }
                }
                return unBarrio;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Utilidades.Utilidades.CerrarConexion(cn);
            }

        }

        public bool existe(string nombre)
        {
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            string consulta = @"SELECT count(*)
                                FROM barrio b
                                WHERE b.nombre = @nombre";

            SqlCommand cmd =
                new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));

           
            Utilidades.Utilidades.AbrirConexion(cn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Barrio CargarDesdeRecord(IDataRecord fila)
        {
            return new Barrio
            {
                Nombre = fila["nombre"].ToString(),
                Descripcion = fila["descripcion"].ToString()
            };
        }
    }
}
