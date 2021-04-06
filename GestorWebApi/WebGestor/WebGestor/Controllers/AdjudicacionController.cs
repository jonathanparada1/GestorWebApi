using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGestor.Consulta;
using WsGestor.LN.Consultas;

namespace WebGestor.Controllers
{
    public class AdjudicacionController : ApiController
    {
        // GET: Adjudicacion
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]

        
        public Object Get()
        {
            string Satelite = "AdjudicacionSI";
            string Programa = "Adjudicacion";
            InterfazGestor ImplementacionGestor = new AdjudicacionLN();

            DataSet DTGestor = new DataSet();
            String DsGestor = new WsConsultas().ConsultaGenericaSateliteGestor(ImplementacionGestor, Satelite, Programa);
            System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
            DTGestor.ReadXml(xmlGestor);
            return DTGestor;
        
        }
    }
}