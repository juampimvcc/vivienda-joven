using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.InterfacesRepositorios;
using Dominio.Repositorios;

namespace Consola
{
    class Program
    {
        static RepositorioViviendaNueva repoViviendaNueva = new RepositorioViviendaNueva();
        static RepositorioViviendaUsada repoViviendaUsada = new RepositorioViviendaUsada();
        static RepositorioBarrio repoBarrio = new RepositorioBarrio();

        static void Main(string[] args)
        {
            int opcion = -1;
            do
            {
                //if (Login())
                //{
                    DibujarMenu();
                    opcion = LeerOpcion();
                    if (opcion != 0)
                        ProcesarMenu(opcion);
                //} else
                //{
                //    Console.WriteLine("Usuario o contraseña incorrecto");
                //    Console.ReadKey();
                //}
                
            } while (opcion != 0);
            {
                Console.WriteLine("Fin del programa.");
                PararPantalla();
            }

        }

        private static bool Login()
        {
            AgregarUsuarios();
            bool bandera = false;
            Console.Clear();
            Console.WriteLine("LOGIN");
            Console.WriteLine("Ingrese email");
            string email = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña");
            string contra = Console.ReadLine();

            List<Usuarios> listaUsu = AgregarUsuarios();
            foreach (var item in listaUsu)
            {
                if (item.Email == email && item.Contrasenia == contra)
                {
                    bandera = true;
                }
            }
            return bandera;
        }

        private static void DibujarMenu()
        {
            Console.Clear();
            Console.WriteLine("Menú de opciones");
            Console.WriteLine("=================");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("1 - Registrar Vivienda");
            Console.WriteLine("2 - Eliminar Vivienda");
            Console.WriteLine("3 - Modificar Vivienda");
            Console.WriteLine("4 - Registrar Barrio");
            Console.WriteLine("5 - Eliminar Barrio");
            Console.WriteLine("6 - Modificar Barrio");
            Console.WriteLine("7 - Listar Barrios");
            Console.WriteLine("8 - Exportar Vivienda");
            Console.WriteLine("9 - Listar Viviendas");

            Console.WriteLine("");
            Console.WriteLine("Ingrese una opción - 0 para salir");
        }

        private static int LeerOpcion()
        {
            int tope = 12;
            int opcion = -1;
            bool esNumero = false;
            char caracter;
            do
            {
                caracter = Console.ReadKey().KeyChar;
                esNumero = int.TryParse(caracter.ToString(), out opcion);
                if (!esNumero || opcion < 0 || opcion > tope)
                    Console.WriteLine("Ingrese nuevamente, la opción debe estar entre 0 y {0}", tope);
            } while (!esNumero || opcion < 0 || opcion > tope);
            return opcion;
        }

        private static void ProcesarMenu(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    AgregarVivienda();
                    break;
                case 2:
                    EliminarVivienda();
                    break;
                case 3:
                    ModificarVivienda();
                    break;
                case 4:
                    AgregarBarrio();
                    break;
                case 5:
                    EliminarBarrio();
                    break;
                case 6:
                    ModificarBarrio();
                    break;
                case 7:
                    ListarBarrios();
                    break;
                case 8:
                    ExportarVivienda();
                    break;
                case 9:
                    ListarViviendas();
                    break;
                default:
                    break;
            }
        }

        private static void PararPantalla()
        {
            Console.WriteLine("Presionar tecla");
            Console.ReadKey();
        }

        private static void AgregarVivienda()
        {

            Console.WriteLine("\n" + "Agregando nueva vivienda");
            Console.WriteLine("Ingrese calle: (string)");
            string calle = Console.ReadLine();
            Console.WriteLine("Ingrese numero de puerta: (int)");
            int numPuerta = int.Parse(Console.ReadLine());
            if (ValidarVivienda(calle, numPuerta))
            {
                Console.WriteLine("Esa vivienda ya fue ingresada");
            }
            else
            {
                Console.WriteLine("Ingrese barrio: (string)");
                string barrio = ValidarBarrio();
                if (barrio == null)
                {
                    barrio = ValidarBarrio();
                }
                Console.WriteLine("Ingrese metraje total de la vivienda: (int)");
                int metraje = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el precio del metro cuadrado: (double)");
                double precioMetro = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese 1 si es nueva o 0 si es usada: (int)");
                int nueva = int.Parse(Console.ReadLine());
                if (nueva != 1 && nueva != 0)
                {
                    Console.WriteLine("Estado no valido, ingrese 1 si es nueva o  0 si es usada");
                    nueva = int.Parse(Console.ReadLine());
                }
                if (nueva == 1)
                {
                    Console.WriteLine("Ingrese una cotizacion: (double)");
                    double cotizacion = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese tope metraje: (int)");
                    int topeMetraje = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese fecha entrega: (dd/mm/aaa) (string)");
                    string fechaConstruccion = Console.ReadLine();
                    ViviendaNueva nuevaVivienda = new ViviendaNueva();
                    nuevaVivienda.Calle = calle;
                    nuevaVivienda.NumPuerta = numPuerta;
                    nuevaVivienda.NombreBarrio = barrio;
                    nuevaVivienda.Nueva = nueva;
                    nuevaVivienda.MetrajeTotal = metraje;
                    nuevaVivienda.PrecioMetro = precioMetro;
                    nuevaVivienda.CotizacionUI = cotizacion;
                    nuevaVivienda.TopeMetraje = topeMetraje;
                    nuevaVivienda.FechaConstruccion = fechaConstruccion;
                    nuevaVivienda.PrecioTotal = nuevaVivienda.Precio();

                    Console.ReadKey();
                    repoViviendaNueva.Add(nuevaVivienda);
                }
                else if (nueva == 0)
                {
                    ViviendaUsada viviendaUsada = new ViviendaUsada();
                    viviendaUsada.Calle = calle;
                    viviendaUsada.NumPuerta = numPuerta;
                    viviendaUsada.NombreBarrio = barrio;
                    viviendaUsada.Nueva = nueva;
                    viviendaUsada.MetrajeTotal = metraje;
                    viviendaUsada.PrecioMetro = precioMetro;
                    viviendaUsada.PrecioTotal = viviendaUsada.Precio();
                    repoViviendaUsada.Add(viviendaUsada);
                }
            }
            PararPantalla();
        }

        private static bool ValidarVivienda(string calle, int numPuerta)
        {
            IEnumerable<ViviendaNueva> viv1 = ListarViviendasNuevas();
            IEnumerable<ViviendaUsada> viv2 = ListarViviendasUsadas();
            bool bandera = false;
            foreach (var item in viv1) { if (item.Calle == calle && item.NumPuerta == numPuerta) { bandera = true; } }
            foreach (var item1 in viv2) { if (item1.Calle == calle && item1.NumPuerta == numPuerta) { bandera = true; } }
            return bandera;
        }

        private static void ModificarVivienda()
        {
            Console.WriteLine("La vivienda es nueva o usada? ('nueva' / 'usada')");
            string nuevaResp = Console.ReadLine();
            if (nuevaResp == "nueva")
            {
                ViviendaNueva unaViv = BuscarViviendaNueva();

                if (unaViv != null)
                {
                    Console.WriteLine(unaViv.ToString());
                    Console.WriteLine("Ingrese calle: (string)");
                    string calle = Console.ReadLine();
                    Console.WriteLine("Ingrese numero de puerta: (int)");
                    string numPuerta = Console.ReadLine();
                    Console.WriteLine("Ingrese barrio: (string)");
                    string barrio = ValidarBarrio();
                    if (barrio == null)
                    {
                        barrio = ValidarBarrio();
                    }
                    Console.WriteLine("Ingrese metraje total de la vivienda: (int)");
                    string metrajeTotal = Console.ReadLine();
                    Console.WriteLine("Ingrese el precio del metro cuadrado: (double)");
                    string precioMetro = Console.ReadLine();
                    Console.WriteLine("Ingrese una cotizacion: (double)");
                    string cotizacion = Console.ReadLine();
                    Console.WriteLine("Ingrese tope metraje: (int)");
                    string topeMetraje = Console.ReadLine();
                    Console.WriteLine("Ingrese fecha entrega: (dd/mm/aaa) (string)");
                    string fechaConstruccion = Console.ReadLine();

                    if (!string.IsNullOrEmpty(calle))
                        unaViv.Calle = calle;
                    if (!string.IsNullOrEmpty(numPuerta))
                        unaViv.NumPuerta = Convert.ToInt32(numPuerta);
                    if (!string.IsNullOrEmpty(barrio))
                        unaViv.NombreBarrio = barrio;
                    if (!string.IsNullOrEmpty(metrajeTotal))
                        unaViv.MetrajeTotal = Convert.ToInt32(metrajeTotal);
                    if (!string.IsNullOrEmpty(precioMetro))
                        unaViv.PrecioMetro = Convert.ToInt32(precioMetro);
                    if (!string.IsNullOrEmpty(cotizacion))
                        unaViv.CotizacionUI = Convert.ToInt32(cotizacion);
                    if (!string.IsNullOrEmpty(topeMetraje))
                        unaViv.TopeMetraje = Convert.ToInt32(topeMetraje);
                    if (!string.IsNullOrEmpty(fechaConstruccion))
                        unaViv.FechaConstruccion = fechaConstruccion;

                    // Calcula precio vivienda
                    unaViv.PrecioTotal = unaViv.Precio();

                    // Modifica
                    if (repoViviendaNueva.Update(unaViv))
                        Console.WriteLine("Los datos fueron modificados");
                    else
                        Console.WriteLine("No se pudo modificar");
                }
                else
                {
                    Console.WriteLine("No existe esa vivienda");
                }

            }
            else if (nuevaResp == "usada")
            {
                ViviendaUsada unaViv = BuscarViviendaUsada();
                if (unaViv != null)
                {
                    Console.WriteLine(unaViv.ToString());
                    Console.WriteLine("Ingrese calle: (string)");
                    string calle = Console.ReadLine();
                    Console.WriteLine("Ingrese numero de puerta: (int)");
                    string numPuerta = Console.ReadLine();
                    Console.WriteLine("Ingrese barrio: (string)");
                    string barrio = ValidarBarrio();
                    if (barrio == null)
                    {
                        barrio = ValidarBarrio();
                    }
                    Console.WriteLine("Ingrese metraje: (int)");
                    string metraje = Console.ReadLine();
                    Console.WriteLine("Ingrese precio metro: (double)");
                    string precioMetro = Console.ReadLine();

                    if (!string.IsNullOrEmpty(calle))
                        unaViv.Calle = calle;
                    if (!string.IsNullOrEmpty(numPuerta))
                        unaViv.NumPuerta = Convert.ToInt32(numPuerta);
                    if (!string.IsNullOrEmpty(barrio))
                        unaViv.NombreBarrio = barrio;
                    if (!string.IsNullOrEmpty(metraje))
                        unaViv.MetrajeTotal = Convert.ToInt32(metraje);
                    if (!string.IsNullOrEmpty(precioMetro))
                        unaViv.PrecioMetro = Convert.ToDouble(precioMetro);

                    unaViv.PrecioTotal = unaViv.Precio();

                    // Modifica
                    if (repoViviendaUsada.Update(unaViv))
                        Console.WriteLine("Los datos fueron modificados");
                    else
                        Console.WriteLine("No se pudo modificar");
                }
                else
                {
                    Console.WriteLine("No existe esa vivienda");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            PararPantalla();
        }

        private static void EliminarVivienda()
        {
            Console.WriteLine("La vivienda es nueva o usada? ('nueva' / 'usada')");
            string nuevaResp = Console.ReadLine();
            if (nuevaResp == "nueva")
            {
                ViviendaNueva unaViv = BuscarViviendaNueva();
                if (unaViv != null)
                {
                    Console.WriteLine(unaViv.ToString());
                    Console.WriteLine("Presione la tecla S para confirmar la eliminación, cualquier otra tecla para cancelar");
                    var resp = Console.ReadLine();
                    if (resp.ToUpper() == "S")
                    {
                        if (repoViviendaNueva.Delete(unaViv))

                            Console.WriteLine("Eliminado");

                        else
                            Console.WriteLine("No se pudo eliminar");
                    }
                }
                else
                    Console.WriteLine("No existe esa vivienda");
            }
            else if (nuevaResp == "usada")
            {
                ViviendaNueva unaViv = BuscarViviendaNueva();
                if (unaViv != null)
                {
                    Console.WriteLine(unaViv.ToString());
                    Console.WriteLine("Presione la tecla S para confirmar la eliminación, cualquier otra tecla para cancelar");
                    var resp = Console.ReadLine();
                    if (resp.ToUpper() == "S")
                    {
                        if (repoViviendaNueva.Delete(unaViv))

                            Console.WriteLine("Eliminado");

                        else
                            Console.WriteLine("No se pudo eliminar");
                    }
                }
                else
                    Console.WriteLine("No existe esa vivienda");
            }
            PararPantalla();
        }

        private static void AgregarBarrio()
        {
            Console.WriteLine("\n" + "Agregando nuevo barrio");
            Console.WriteLine("Ingresa un nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingresa una descripcion: ");
            string descripcion = Console.ReadLine();

            Barrio nuevoBarrio = new Barrio();
            nuevoBarrio.Nombre = nombre;
            nuevoBarrio.Descripcion = descripcion;

            Console.ReadKey();

            if (repoBarrio.Add(nuevoBarrio))
            {
                Console.WriteLine("Ingreso exitoso");
            }
            else
            {
                Console.WriteLine("Error en el ingreso");
            }

            PararPantalla();
        }

        private static void EliminarBarrio()
        {
            Console.WriteLine("\n" + "Eliminando nuevo barrio");
            Console.WriteLine("Ingreasa un nombre: ");
            string nombre = Console.ReadLine();
            Barrio nuevoBarrio = new Barrio();
            nuevoBarrio.Nombre = nombre;

            Console.ReadKey();
            repoBarrio.Delete(nuevoBarrio);

            PararPantalla();
        }

        private static void ModificarBarrio()
        {
            Barrio unBar = BuscarBarrio();

            if (unBar != null)
            {
                Console.WriteLine(unBar.ToString());
                Console.WriteLine("Ingrese un nuevo nombre. <Enter> para mantener el anterior");
                string nuevoNombre = Console.ReadLine();
                Console.WriteLine("Ingrese un nueva descripcion. <Enter> para mantener el anterior");
                string nuevoDescripcion = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                    unBar.Nombre = nuevoNombre;
                if (!string.IsNullOrEmpty(nuevoDescripcion))
                    unBar.Descripcion = nuevoDescripcion;
                if (repoBarrio.Update(unBar))
                    Console.WriteLine("Los datos fueron modificados");
                else
                    Console.WriteLine("No se pudo modificar");
            }
            else
                Console.WriteLine("No hay Barrios con ese nombre");
            PararPantalla();
        }

        private static void ListarBarrios()
        {
            Console.WriteLine("Lista de barrios");
            var lista = repoBarrio.FindAll();
            if (lista != null)
            {
                foreach (Barrio barrio in lista)
                {
                    Console.WriteLine(barrio.ToString());
                }
            }
            else
            {
                Console.WriteLine("No hay barrios registrados");
            }
            PararPantalla();

        }

        private static Barrio BuscarBarrio()
        {
            Console.WriteLine("Busque un barrio");
            Console.WriteLine("Ingrese un nombre");
            string nombre = Console.ReadLine();

            Barrio unBarrio = repoBarrio.FindByName(nombre);

            return unBarrio;
        }

        private static ViviendaNueva BuscarViviendaNueva()
        {
            Console.WriteLine("Busque una Vivienda");
            Console.WriteLine("Ingrese un Id");
            int idVivienda = Convert.ToInt32(Console.ReadLine());

            ViviendaNueva unaViv = repoViviendaNueva.FindById(idVivienda);

            return unaViv;
        }

        private static ViviendaUsada BuscarViviendaUsada()
        {
            Console.WriteLine("Busque una Vivienda");
            Console.WriteLine("Ingrese un Id");
            int idVivienda = Convert.ToInt32(Console.ReadLine());

            ViviendaUsada unaViv = repoViviendaUsada.FindById(idVivienda);

            return unaViv;
        }

        private static string ValidarBarrio()
        {
            Console.WriteLine("Ingrese un barrio");
            string nombre = Console.ReadLine();

            bool existe = repoBarrio.existe(nombre);

            if (existe)
            {
                return nombre;
            }
            else
            {
                Console.WriteLine("El barrio indicado no existe, vuelva a ingresar un barrio");
            }
            return null;
        }

        private static List<Usuarios> AgregarUsuarios()
        {
            Usuarios usu1 = new Usuarios()
            {
                Email = "usu1@mail.com",
                Contrasenia = "123"
            };
            Usuarios usu2 = new Usuarios()
            {
                Email = "usu2@mail.com",
                Contrasenia = "123"
            };

            List<Usuarios> lista = new List<Usuarios>();
            lista.Add(usu1);
            lista.Add(usu2);
            return lista;
        }

        private static void ExportarVivienda()
        {
            IEnumerable<ViviendaNueva> listaViviendas = ListarViviendasNuevas();
            IEnumerable<ViviendaUsada> listaViviendas1 = ListarViviendasUsadas();

            string texto = "";
            foreach (var item in listaViviendas)
            {
                texto += item.ToString() + "\n";
            }
            foreach (var item in listaViviendas1)
            {
                texto += item.ToString() + "\n";
            }

            Console.WriteLine(texto);

            StreamWriter File = new StreamWriter(@"\\Mac\Home\Library\Mobile Documents\com~apple~CloudDocs\Analista Programador\2019\P3\prueba1.txt");
            File.Write(texto);
            File.Close();
        }

        private static IEnumerable<ViviendaNueva> ListarViviendasNuevas()
        {
            //Console.WriteLine("Lista de viviendas nuevas");
            var lista = repoViviendaNueva.FindAll();
            if (lista != null)
            {
                foreach (ViviendaNueva viviendaNueva in lista)
                {
                    Console.WriteLine(viviendaNueva.ToString());
                }
            }
            else
            {
                Console.WriteLine("No hay viviendas registradas");
            }
            PararPantalla();
            return lista;
        }

        private static IEnumerable<ViviendaUsada> ListarViviendasUsadas()
        {
            //Console.WriteLine("Lista de viviendas usadas");
            var lista = repoViviendaUsada.FindAll();
            if (lista != null)
            {
                foreach (ViviendaUsada viviendaUsada in lista)
                {
                    Console.WriteLine(viviendaUsada.ToString());
                }
            }
            else
            {
                Console.WriteLine("No hay viviendas registradas");
            }
            PararPantalla();
            return lista;
        }

        private static void ListarViviendas()
        {
            Console.WriteLine(ListarViviendasNuevas().ToString());
            Console.WriteLine(ListarViviendasUsadas().ToString());
        }
    }
}
