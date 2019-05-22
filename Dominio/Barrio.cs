using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Utilidades;

namespace Dominio
{
    public class Barrio
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public bool Insertar()
        {
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;
            try
            {
                string cadenaCmd = @"INSERT INTO barrio VALUES(@nombre, @descripcion)";
                SqlCommand cmd = new SqlCommand(cadenaCmd, cn);
                cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));
                cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
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

        public bool Eliminar()
        {
            SqlConnection cn = Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;

            string cadenaCmd = @"DELETE barrio WHERE nombre = @nombre";
            SqlCommand cmd = new SqlCommand(cadenaCmd, cn);
            cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));

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

        public bool Modificar()
        {
            SqlConnection cn =
               Utilidades.Utilidades.CrearConexion();
            SqlTransaction trn = null;

            //Preparar el comando
            string cadenaCmd = @"UPDATE barrio SET nombre=@nombre,descripcion=@descripcion WHERE nombre=@nombre";
            SqlCommand cmd = new SqlCommand(cadenaCmd, cn);

            cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));
            cmd.Parameters.AddWithValue("@descripcion", this.Descripcion);
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

        public bool Validar()
        {
            return this.Nombre != "" && this.Descripcion != "";
        }

        public override string ToString()
        {
            return "Nombre: " + this.Nombre + " Descripcion: " + this.Descripcion;
        }

    }
}
