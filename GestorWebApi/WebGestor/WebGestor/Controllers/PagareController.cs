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
    public class PagareController : ApiController
    {
        // POST: Pagare
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]

        public Object Pagare([FromBody] PagareEN GenericoEN)//Cambiar En Diferente a clase Especifica
        {
            ParametrosEN ObjParametros = new ParametrosEN();
            ObjParametros.token = GenericoEN.token;

            ParametrosLN ObjValidacionLN = new ParametrosLN();

            if (ObjValidacionLN.ValidarTokenLN(ObjParametros) == "Si")
            {
            string Satelite = "PagareSI";
            string Programa = "Pagare";
            InterfazGestor ImplementacionGestor = new PagareLN();//Se debe cambiar de acuerdo al resultado esperado

            InterfazFind FindGenerico = new PagareFindLN(); //Cambiar Find Diferente Clase Especifica
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