using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public class RepositorioViviendaUsada
    {
        public bool Add(ViviendaUsada viviendaUsada)
        {
            return viviendaUsada != null && viviendaUsada.Insertar();
        }
        public bool Delete(ViviendaUsada viviendaUsada)
        {
            throw new NotImplementedException();
        }

        public bool Update(ViviendaUsada viviendaUsada)
        {
            return viviendaUsada != null && viviendaUsada.Validar() && viviendaUsada.Modificar();
        }
        public ViviendaUsada FindById(int idVivienda)
        {
            ViviendaUsada unaViv = null;
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
        private ViviendaUsada CargarDesdeRecord(IDataRecord fila)
        {
            return new ViviendaUsada
            {
                // cambiar por datos de vivienda usada
                IdVivienda = Convert.ToInt32(fila["idVivienda"]),
                Calle = fila["calle"].ToString(),
                NumPuerta = Convert.ToInt32(fila["numPuerta"]),
                NombreBarrio = fila["nombreBarrio"].ToString(),
                Nueva = Convert.ToInt32(fila["nueva"]),
                MetrajeTotal = Convert.ToInt32(fila["metrajeTotal"]),
                PrecioMetro = Convert.ToDouble(fila["precioMetro"]),
                PrecioTotal = Convert.ToDouble(fila["precioTotal"])
            };
        }

        public IEnumerable<ViviendaUsada> FindAll()
        {
            List<ViviendaUsada> lista = new List<ViviendaUsada>();
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            string consulta = @"SELECT * FROM vivienda v WHERE v.nueva = 0";

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

