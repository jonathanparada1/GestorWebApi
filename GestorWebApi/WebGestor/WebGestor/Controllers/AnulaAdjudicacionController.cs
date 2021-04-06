using System;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGestor.Consulta;
using WsGestor.LN.Consultas;

namespace WebGestor.Controllers
{
    public class AnulaAdjudicacionController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        //[Route("api/Gestor/AnulaAdjudicacion")]
        public Object Get()
        {
            string Satelite = "AnulaAdjudicacionSI";
            string Programa = "AnulaAdjudicacion";
            InterfazGestor ImplementacionGestor = new AnulaAdjudicacionLN();

            DataSet DTGestor = new DataSet();
            String DsGestor = new WsConsultas().ConsultaGenericaSateliteGestor(ImplementacionGestor, Satelite, Programa);
            System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
            DTGestor.ReadXml(xmlGestor);
            return DTGestor;
        }

    }
}