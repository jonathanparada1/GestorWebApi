using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGestor.Consulta;
using WsGestor.LN.Consultas;

namespace WebGestor.Controllers
{
    public class CambioBienController : ApiController
    {
        // GET: CambioBien
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]

        public Object Get()
        {
            string Satelite = "CambioBienSI";
            string Programa = "CambioBien";
            InterfazGestor ImplementacionGestor = new CambioBienLN();

            DataSet DTGestor = new DataSet();
            String DsGestor = new WsConsultas().ConsultaGenericaSateliteGestor(ImplementacionGestor, Satelite, Programa);
            System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
            DTGestor.ReadXml(xmlGestor);
            return DTGestor;
        }
    }
}