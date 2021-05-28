using System;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGestor.Codigo;
using WebGestor.Consulta;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;
using WsGestor.LN.Find;
using WsGestor.LN.Resultados;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace WebGestor.Controllers
{
    public class PasoCuatroController : ApiController
    {
        // POST: PasoCuatro
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]

        public Object InsertaPasoCuatro([FromBody] PasoCuatroEN GenericoEN)
        {

            ParametrosEN ObjParametros = new ParametrosEN();
            ObjParametros.token = GenericoEN.token;

            ParametrosLN ObjValidacionLN = new ParametrosLN();

            if (ObjValidacionLN.ValidarTokenLN(ObjParametros) == "Si")
            {
                string Satelite = "ProprenSI";
                string Programa = "Propren";
                InterfazGestor ImplementacionGestor = new PasoCuatroLN();

                InterfazFind FindGenerico = new PasoCuatroFindLN(); //Cambiar Find Diferente Clase Especifica
                InterfazCodigo Codigo = new Peticion(); //Cambia si es simple o compuesta

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