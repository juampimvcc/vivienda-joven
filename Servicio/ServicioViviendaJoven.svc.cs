using Dominio;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioViviendaJoven" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioViviendaJoven.svc o ServicioViviendaJoven.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioViviendaJoven : IServicioViviendaJoven
    {
        RepositorioBarrio repoBarrio = new RepositorioBarrio();

        public bool AltaBarrio(DTOBarrio b)
        {
            return repoBarrio.Add(new Barrio { Nombre = b.Nombre, Descripcion = b.Descripcion });
        }

        public bool ModificarBarrio(DTOBarrio b)
        {
            Barrio barrio = repoBarrio.FindByName(b.Nombre);
            if (barrio.Nombre != null)
            {
                barrio.Descripcion = b.Descripcion;
                return repoBarrio.Update(barrio);
            }

            return false;
        }

        public bool EliminarBarrio(string nombreBarrio)
        {
            Barrio barrio = repoBarrio.FindByName(nombreBarrio);
            if (barrio.Nombre != null)
            {
                return repoBarrio.Delete(barrio);
            }

            return false;
        }
    }
}
