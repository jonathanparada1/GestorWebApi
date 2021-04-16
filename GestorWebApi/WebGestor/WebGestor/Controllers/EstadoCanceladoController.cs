using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGestor.Codigo;
using WebGestor.Consulta;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;

namespace WebGestor.Controllers
{
    public class EstadoCanceladoController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        //[Route("api/Gestor/EstadoCancelado")]
        public Object Get()
        {
            string Satelite = "EstadoCanceladoSI";
            string Programa = "EstadoCancelado";
            InterfazGestor ImplementacionGestor = new EstadoCanceladoLN();
            InterfazFind FindGenerico = new ConsultaFindGenericoLN(); //Cambiar Find Diferente
            ClassGenericaSateliteEN GenericoEN = new ClassGenericaSateliteEN(); // Cambiar 
            InterfazCodigo Codigo = new PeticionCompuesta();

            DataSet DTGestor = new DataSet();
            String DsGestor = new WsConsultas().ConsultaGenericaSateliteGestor(ImplementacionGestor, Satelite, Programa, FindGenerico, GenericoEN, Codigo);
            System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
            DTGestor.ReadXml(xmlGestor);
            return DTGestor;
        }
    }
}