using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ViviendaUsada : Vivienda
    {
        public double PrecioTotal { get; set; }

        public bool Insertar()
        {
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;
            try
            {
                string cadenaCmd = @"INSERT INTO vivienda(calle, numPuerta, nombreBarrio, nueva, metrajeTotal, precioMetro, precioTotal) VALUES(
                    @calle, 
                    @numPuerta, 
                    @nombreBarrio, 
                    @nueva, 
                    @metrajeTotal,
                    @precioMetro,
                    @precioTotal
                )";
                SqlCommand cmd = new SqlCommand(cadenaCmd, cn);
                cmd.Parameters.Add(new SqlParameter("@calle", this.Calle));
                cmd.Parameters.AddWithValue("@numPuerta", this.NumPuerta);
                cmd.Parameters.AddWithValue("@nombreBarrio", this.NombreBarrio);
                cmd.Parameters.AddWithValue("@nueva", this.Nueva);
                cmd.Parameters.AddWithValue("@metrajeTotal", this.MetrajeTotal);
                cmd.Parameters.AddWithValue("@precioMetro", this.PrecioMetro);
                cmd.Parameters.AddWithValue("@precioTotal", this.PrecioTotal);
                Console.WriteLine("apriete un boton para abrir conexion");
                Console.ReadKey();
                Utilidades.Utilidades.AbrirConexion(cn);
                Console.WriteLine("conexion abierta");
                Console.ReadKey();

                trn = cn.BeginTransaction();
                cmd.Transaction = trn;

                cmd.ExecuteNonQuery();
                trn.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                trn.Rollback();
                return false;
            }
            finally
            {
                Console.WriteLine("apriete un boton para cerrar conexion");
                Console.ReadKey();
                Utilidades.Utilidades.CerrarConexion(cn);
            }
        }

        public double Precio()
        {
            return PrecioMetro * MetrajeTotal;
        }
        public bool Validar()
        {
            return true;
        }

        public bool Modificar()
        {
            SqlConnection cn =
               Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;

            //Preparar el comando
            string cadenaCmd = @"UPDATE vivienda SET calle=@calle, numPuerta=@numPuerta, nombreBarrio=@nombreBarrio, nueva=@nueva, metrajeTotal=@metrajeTotal, precioMetro=@precioMetro, precioTotal=@precioTotal WHERE idVivienda=@idVivienda";
            SqlCommand cmd = new SqlCommand(cadenaCmd, cn);

            cmd.Parameters.Add(new SqlParameter("@idVivienda", this.IdVivienda));
            cmd.Parameters.AddWithValue("@calle", this.Calle);
            cmd.Parameters.AddWithValue("@numPuerta", this.NumPuerta);
            cmd.Parameters.AddWithValue("@nombreBarrio", this.NombreBarrio);
            cmd.Parameters.AddWithValue("@nueva", this.Nueva);
            cmd.Parameters.AddWithValue("@metrajeTotal", this.MetrajeTotal);
            cmd.Parameters.AddWithValue("@precioMetro", this.PrecioMetro);
            cmd.Parameters.AddWithValue("@precioTotal", this.PrecioTotal);
            try
            {
                Utilidades.Utilidades.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();
                trn.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                return false;
            }
            finally
            {
                Utilidades.Utilidades.CerrarConexion(cn);
            }
        }
    }
}
