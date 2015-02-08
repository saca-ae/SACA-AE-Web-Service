using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SACAAE_WCFService
{
    [DataContract]
    public class GetProfessorsByProjectID
    {
        [DataMember]
        public string Nombre { get; set; }

    }
}