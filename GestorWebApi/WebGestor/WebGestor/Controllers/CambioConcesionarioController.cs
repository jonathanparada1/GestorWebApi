using System;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGestor.Codigo;
using WebGestor.Consulta;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;

namespace WebGestor.Controllers
{
    public class CambioConcesionarioController : ApiController
    {
        // POST: CambioConcesionario
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]

        public Object PostCambioConcesionario([FromBody] ParametrosEN ObjParametros)
        {
            ParametrosEN ObjParametro2 = new ParametrosEN();
            ObjParametro2.token = ObjParametros.token;//Objeto de entrada del metodo

            ParametrosLN ObjValidacionLN = new ParametrosLN();

            if (ObjValidacionLN.ValidarTokenLN(ObjParametro2) == "Si")
            {
                string Satelite = "CambioConcesionarioSI";
                string Programa = "CambioConcesionario";
                InterfazGestor ImplementacionGestor = new CambioConcesionarioLN();
                InterfazFind FindGenerico = new ConsultaFindGenericoLN(); //Cambiar Find Diferente
                ClassGenericaSateliteEN GenericoEN = new ClassGenericaSateliteEN(); // Cambiar 
                InterfazCodigo Codigo = new PeticionCompuesta();

                DataSet DTGestor = new DataSet();
                String DsGestor = new WsConsultas().ConsultaGenericaSateliteGestor(ImplementacionGestor, Satelite, Programa, FindGenerico, GenericoEN, Codigo);
                System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
                DTGestor.ReadXml(xmlGestor);
                return DTGestor;
            }
            else
            {
                DataTable DtEerror = new WsConsultas().AgregarTabla("Autenticacion", "Autenticacion Invalida");
                DataSet DTGestor = new DataSet();
                DTGestor.Tables.Add(DtEerror);

                String DsGestor = DTGestor.GetXml();
                DataSet DsError = new DataSet();

                System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
                DsError.ReadXml(xmlGestor);
                return DsError;
            }
        }
    }
}