using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorios
{
    public interface IRepositorioViviendaNueva
    {
        bool Add(ViviendaNueva viviendaNueva);
        bool Delete(ViviendaNueva viviendaNueva);
    }
}
