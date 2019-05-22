using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorios
{
    interface IRepositorioViviendaUsada
    {
        bool Add(ViviendaUsada viviendaUsada);
        bool Delete(ViviendaUsada viviendaUsada);
    }
}
