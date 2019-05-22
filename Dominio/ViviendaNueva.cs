using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ViviendaNueva : Vivienda, IEquatable<ViviendaNueva>, IActiveRecord
    {
        public double PrecioTotal { get; set; }
        public double CotizacionUI { get; set; }
        public int TopeMetraje { get; set; }
        public string FechaConstruccion { get; set; }
        public override string ToString()
        {
            return base.ToString() + "#Precio Total: " + this.PrecioTotal + "#Cotización: " + this.CotizacionUI + "#Tope Metraje: " + this.TopeMetraje + "#Fecha Construcción: " + this.FechaConstruccion + "\n";
        }

        public bool Equals(ViviendaNueva other)
        {
            throw new NotImplementedException();
        }

        public bool Insertar()
        {
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;
            try
            {
                string cadenaCmd = @"INSERT INTO vivienda VALUES(
                    @calle, 
                    @numPuerta, 
                    @nombreBarrio, 
                    @nueva, 
                    @metrajeTotal,
                    @precioMetro, 
                    @cotizacion,
                    @topeMetraje, 
                    @fechaConstruccion,
                    @precioTotal
                )";
                SqlCommand cmd = new SqlCommand(cadenaCmd, cn);
                cmd.Parameters.Add(new SqlParameter("@calle", this.Calle));
                cmd.Parameters.AddWithValue("@numPuerta", this.NumPuerta);
                cmd.Parameters.AddWithValue("@nombreBarrio", this.NombreBarrio);
                cmd.Parameters.AddWithValue("@nueva", this.Nueva);
                cmd.Parameters.AddWithValue("@metrajeTotal", this.MetrajeTotal);
                cmd.Parameters.AddWithValue("@precioMetro", this.PrecioMetro);
                cmd.Parameters.AddWithValue("@cotizacion", this.CotizacionUI);
                cmd.Parameters.AddWithValue("@topeMetraje", this.TopeMetraje);
                cmd.Parameters.AddWithValue("@fechaConstruccion", this.FechaConstruccion);
                cmd.Parameters.AddWithValue("@precioTotal", this.PrecioTotal);

                Utilidades.Utilidades.AbrirConexion(cn);
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
                Utilidades.Utilidades.CerrarConexion(cn);
            }
        }

        public bool Modificar()
        {
            SqlConnection cn =
               Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;

            //Preparar el comando
            string cadenaCmd = @"UPDATE vivienda SET calle=@calle, numPuerta=@numPuerta, nombreBarrio=@nombreBarrio, nueva=@nueva, metrajeTotal=@metrajeTotal, precioMetro=@precioMetro, cotizacion=@cotizacion,topeMetraje=@topeMetraje, fechaConstruccion=@fechaConstruccion, precioTotal=@precioTotal WHERE idVivienda=@idVivienda";
            SqlCommand cmd = new SqlCommand(cadenaCmd, cn);

            cmd.Parameters.Add(new SqlParameter("@idVivienda", this.IdVivienda));
            cmd.Parameters.AddWithValue("@calle", this.Calle);
            cmd.Parameters.AddWithValue("@numPuerta", this.NumPuerta);
            cmd.Parameters.AddWithValue("@nombreBarrio", this.NombreBarrio);
            cmd.Parameters.AddWithValue("@nueva", this.Nueva);
            cmd.Parameters.AddWithValue("@metrajeTotal", this.MetrajeTotal);
            cmd.Parameters.AddWithValue("@precioMetro", this.PrecioMetro);
            cmd.Parameters.AddWithValue("@cotizacion", this.CotizacionUI);
            cmd.Parameters.AddWithValue("@topeMetraje", this.TopeMetraje);
            cmd.Parameters.AddWithValue("@fechaConstruccion", this.FechaConstruccion);
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

        public bool Eliminar()
        {
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;

            string cadenaCmd = @"DELETE vivienda WHERE idVivienda = @idVivienda";
            SqlCommand cmd = new SqlCommand(cadenaCmd, cn);
            cmd.Parameters.Add(new SqlParameter("@idVivienda", this.IdVivienda));

            try
            {
                Console.WriteLine("apriete un boton para abrir conexion");
                Console.ReadKey();
                Utilidades.Utilidades.AbrirConexion(cn);
                Console.WriteLine("conexion abierta");
                Console.ReadKey();

                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                cmd.CommandText = cadenaCmd;

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
            return PrecioMetro * MetrajeTotal / 4.1688;
        }

        public bool Validar()
        {
            return true;
        }

    }
}
