using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SACAAE_WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       
        /*Funcion para obtener la informacion de los proyectos de la Escuela*/
        public List<SACAAE_WCFService.Project.wsProject> GetAllProjects()
        {
            SACAAEdbDataContext sacaaeDataContext = new SACAAEdbDataContext();
            List<SACAAE_WCFService.Project.wsProject> results = new List<SACAAE_WCFService.Project.wsProject>();
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            foreach (Proyecto project in sacaaeDataContext.Proyectos)
            {
                results.Add(new SACAAE_WCFService.Project.wsProject()
                {
                    ID= project.ID,
                    Nombre = project.Nombre,
                    Inicio = (project.Inicio == null) ? "" : project.Inicio.Value.ToString("d", ci),
                    Fin = (project.Fin == null) ? "" : project.Fin.Value.ToString("d", ci),
                    Estado = project.Estado,
                    Link= project.Link
                });
            }

            return results;
        }

        /*Funcion para obtener los profesores de un proyecto*/
        public List<GetProfessorsByProjectID> GetProjectProfessors(String projectID)
        {
            List<SACAAE_WCFService.GetProfessorsByProjectID> results = new List<SACAAE_WCFService.GetProfessorsByProjectID>();
            SACAAEdbDataContext sacaaeDataContext = new SACAAEdbDataContext();

            foreach (SACAAE_WCFService.GetProfessorsByProjectIDResult vProfessor in sacaaeDataContext.GetProfessorsByProjectID(Int16.Parse(projectID)))
            {
                results.Add(new SACAAE_WCFService.GetProfessorsByProjectID()
                {
                    Nombre = vProfessor.Nombre,
                });
            }

            return results;
        }

        /*Funcion para obtener la informacion de las comisiones de la Escuela*/
        public List<SACAAE_WCFService.Comision.wsComision> GetAllComision()
        {
            SACAAEdbDataContext sacaaeDataContext = new SACAAEdbDataContext();
            List<SACAAE_WCFService.Comision.wsComision> results = new List<SACAAE_WCFService.Comision.wsComision>();
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            foreach (Comisione comision in sacaaeDataContext.Comisiones)
            {
                results.Add(new SACAAE_WCFService.Comision.wsComision()
                {
                    ID = comision.ID,
                    Nombre = comision.Nombre,
                    Inicio = (comision.Inicio == null) ? "" : comision.Inicio.ToString("d", ci),
                    Fin = (comision.Fin == null) ? "" : comision.Fin.ToString("d", ci),
                    Estado = comision.Estado
                });
            }

            return results;
        }

        /*Funcion para obtener los profesores de una comision*/
        public List<GetProfessorsByComisionID> GetComisionProfessors(String comisionID)
        {
            List<SACAAE_WCFService.GetProfessorsByComisionID> results = new List<SACAAE_WCFService.GetProfessorsByComisionID>();
            SACAAEdbDataContext sacaaeDataContext = new SACAAEdbDataContext();

            foreach (SACAAE_WCFService.GetProfessorsByComisionIDResult vProfessor in sacaaeDataContext.GetProfessorsByComisionID(Int16.Parse(comisionID)))
            {
                results.Add(new SACAAE_WCFService.GetProfessorsByComisionID()
                {
                    Nombre = vProfessor.Nombre,
                });
            }

            return results;
        }


        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
