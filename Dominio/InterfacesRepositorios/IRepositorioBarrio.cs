using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorios
{
    interface IRepositorioBarrio
    {
        bool Add(Barrio unBarrio);
        bool Delete(Barrio unBarrio);
    }
}
