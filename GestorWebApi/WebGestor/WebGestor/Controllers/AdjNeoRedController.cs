using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WebGestor.Codigo;
using WebGestor.Consulta;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;
using WsGestor.LN.Find;
using WsGestor.LN.Resultados;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace WebGestor.Controllers
{
    public class AdjNeoRedController : ApiController
    {
        // POST: AdjNeoRed
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public Object Adjudicados([FromBody] AdjNeoRedEN GenericoEN)//Cambiar En Diferente a clase Especifica
        {
            ParametrosEN ObjParametros = new ParametrosEN();
            ObjParametros.token = GenericoEN.token;

            ParametrosLN ObjValidacionLN = new ParametrosLN();

            if (ObjValidacionLN.ValidarTokenLN(ObjParametros) == "Si")
            {
                string Satelite = "AdjuNeoRedSI";
                string Programa = "AdjuNeoRed";
                InterfazGestor ImplementacionGestor = new AdjNeoRedLN();//Se debe cambiar de acuerdo al resultado esperado

                InterfazFind FindGenerico = new AdjNeoRedFindLN(); //Cambiar Find Diferente Clase Especifica
                InterfazCodigo Codigo = new PeticionCompuesta(); //Cambia si es simple o compuesta

                DataSet DTNeoRed = new DataSet();
                String DsNeoRed = new WsConsultas().ConsultaGenericaSateliteGestor(ImplementacionGestor, Satelite, Programa, FindGenerico, GenericoEN, Codigo);
                System.IO.StringReader xmlNeoRed = new System.IO.StringReader(DsNeoRed);
                DTNeoRed.ReadXml(xmlNeoRed);
                return DTNeoRed;
            }
            else
            {
                DataTable DtEerror = new WsConsultas().AgregarTabla("Autenticacion", "Autenticacion Invalida");
                DataSet DTNeoRed = new DataSet();
                DTNeoRed.Tables.Add(DtEerror);

                String DsNeoRed = DTNeoRed.GetXml();
                DataSet DsError = new DataSet();

                System.IO.StringReader xmlNeoRed = new System.IO.StringReader(DsNeoRed);
                DsError.ReadXml(xmlNeoRed);
                return DsError;
            }
        }
    }
}