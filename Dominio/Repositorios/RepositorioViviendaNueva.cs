using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public class RepositorioViviendaNueva : InterfacesRepositorios.IRepositorioViviendaNueva
    {

        public bool Add(ViviendaNueva viviendaNueva)
        {
            return viviendaNueva != null && viviendaNueva.Insertar();
        }

        public bool Delete(ViviendaNueva viviendaNueva)
        {
            return viviendaNueva != null && viviendaNueva.Eliminar();
        }

        public ViviendaNueva FindById(int idVivienda)
        {
            ViviendaNueva unaViv = null;
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            string consulta = @"SELECT * 
                                FROM vivienda v
                                WHERE v.idVivienda = @idVivienda";
            //Preparar el comando
            SqlCommand cmd =
                new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@idVivienda", idVivienda));

            try
            {
                Utilidades.Utilidades.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                //Leer el reader y cargar los objetos en la lista de retorno
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        unaViv = CargarDesdeRecord(dr);
                    }
                }
                return unaViv;
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

        private ViviendaNueva CargarDesdeRecord(IDataRecord fila)
        {
            return new ViviendaNueva
            {
                IdVivienda = Convert.ToInt32(fila["idVivienda"]),
                Calle = fila["calle"].ToString(),
                NumPuerta = Convert.ToInt32(fila["numPuerta"]),
                NombreBarrio = fila["nombreBarrio"].ToString(),
                Nueva = Convert.ToInt32(fila["nueva"]),
                MetrajeTotal = Convert.ToInt32(fila["metrajeTotal"]),
                PrecioMetro = Convert.ToDouble(fila["precioMetro"]),
                CotizacionUI = Convert.ToDouble(fila["cotizacion"]),
                TopeMetraje = Convert.ToInt32(fila["topeMetraje"]),
                FechaConstruccion = fila["fechaConstruccion"].ToString(),
                PrecioTotal = Convert.ToDouble(fila["precioTotal"])
            };
        }

        public bool Update(ViviendaNueva unaViv)
        {
            return unaViv != null && unaViv.Validar() && unaViv.Modificar();
        }

        public IEnumerable<ViviendaNueva> FindAll()
        {
            List<ViviendaNueva> lista = new List<ViviendaNueva>();
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            string consulta = @"SELECT * FROM vivienda v WHERE v.nueva = 1";

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
            finally
            {
                Utilidades.Utilidades.CerrarConexion(cn);
            }
        }
    }



}

