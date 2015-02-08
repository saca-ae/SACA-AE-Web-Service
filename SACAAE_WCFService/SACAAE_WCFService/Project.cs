using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SACAAE_WCFService
{
    public class Project
    {
        [DataContract]
        public class wsProject
        {
            [DataMember]
            public int ID { get; set; }

            [DataMember]
            public string Nombre { get; set; }

            [DataMember]
            public string Inicio { get; set; }

            [DataMember]
            public string Fin { get; set; }

            [DataMember]
            public int Estado { get; set; }

            [DataMember]
            public string Link { get; set; }
        }
    }
}