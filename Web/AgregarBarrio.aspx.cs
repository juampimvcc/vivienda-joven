using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class AgregarBarrio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAgregarBarrio_Click(object sender, EventArgs e)
        {
            string nombre = TxtNombreBarrio.Text;
            string descripcion = TxtNombreBarrio.Text;

            DTOBarrio barrio = new DTOBarrio() { Nombre = nombre, Descripcion = descripcion };

            //ServicioClient cliente = ServicioClient();
            //cliente.Open();

            //if (cliente.AltaBarrio(barrio))
            //{
            //    LblBarrioAgregado.Text = "Se agrego el barrio correctamente";
            //}
            //else
            //{
            //    LblBarrioAgregado.Text = "No se pudo agregar el barrio";
            //}

        }
    }
}