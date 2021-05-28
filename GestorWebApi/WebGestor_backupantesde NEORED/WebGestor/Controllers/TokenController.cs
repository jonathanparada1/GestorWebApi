using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebGestor.Codigo;
using WebGestor.Consulta;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;
using System.Collections.Generic;
using WsGestor.LN.Codigo;

namespace WebGestor.Controllers
{
    public class TokenController : ApiController
    {
        // POST: Token
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public Object Token([FromBody] ParametrosEN ObjParametros)
        {
            ParametrosEN ObjParametro2 = new ParametrosEN();
            ObjParametro2.token = ObjParametros.token;//Objeto de entrada del metodo

            ParametrosLN ObjValidacionLN = new ParametrosLN();

            String tokenEncriptado = ObjValidacionLN.EncriptarLN(ObjParametros);

            DataTable DtResultado = new WsConsultas().AgregarTabla("token", tokenEncriptado);
            DataSet DTGestor = new DataSet();
            DTGestor.Tables.Add(DtResultado);

            String DsGestor = DTGestor.GetXml();
            DataSet DsResultado = new DataSet();

            System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
            DsResultado.ReadXml(xmlGestor);
            return DsResultado;
                       
        }
    }
}