using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servicio
{
    
    [ServiceContract]
    public interface IServicioViviendaJoven
    {

        [OperationContract]
        bool AltaBarrio(DTOBarrio b);

        [OperationContract]
        bool ModificarBarrio(DTOBarrio b);

        [OperationContract]
        bool EliminarBarrio(string NomBarrio);

    }


    
    [DataContract]
    public class DTOBarrio
    {

        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
