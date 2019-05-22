using Cliente.ServicioViviendaJovenClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.InterfacesRepositorios;
using Dominio.Repositorios;

namespace Cliente
{
    class Program
    {
        static RepositorioViviendaNueva repoViviendaNueva = new RepositorioViviendaNueva();
        static RepositorioViviendaUsada repoViviendaUsada = new RepositorioViviendaUsada();
        static RepositorioBarrio repoBarrio = new RepositorioBarrio();


        static void Main(string[] args)
        {
            Console.WriteLine("Ingresar nuevo barrio desde servicio:");
            Console.WriteLine("Ingrese un nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese una descripción:");
            string descripcion = Console.ReadLine();

            DTOBarrio b = new DTOBarrio() { Nombre = nombre, Descripcion = descripcion };

            ServicioViviendaJovenClient.ServicioViviendaJovenClient cliente = new ServicioViviendaJovenClient.ServicioViviendaJovenClient();
            cliente.Open();

            if (cliente.AltaBarrio(b))
            {
                Console.WriteLine("El barrio se dio de alta correctamente.");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al dar de alta el barrio.");
            }

        }
    }
}
