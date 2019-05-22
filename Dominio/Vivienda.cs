using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Vivienda
    {
        public int IdVivienda { get; set; }
        public string Calle { get; set; }
        public int NumPuerta { get; set; }
        public string NombreBarrio { get; set; }
        public int MetrajeTotal { get; set; }
        public int Nueva { get; set; }
        public double PrecioMetro { get; set; }

        public override string ToString()
        {
            return "#Calle: " + this.Calle + "#Descripcion: " + this.NumPuerta + "#Barrio: " + this.NombreBarrio + "#Metraje Total: " + this.MetrajeTotal + "#Nueva: " + this.Nueva + "#Precio Metro: " + this.PrecioMetro;
        }
    }


}
