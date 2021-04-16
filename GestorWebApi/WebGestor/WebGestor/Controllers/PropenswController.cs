﻿using System;
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
    public class PropenswController : ApiController
    {
        // POST: Propensw
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]

        public Object Codeudor([FromBody] PropenswEN GenericoEN)//Cambiar En Diferente a clase Especifica
        {
            string Satelite = "ProprenswSI";
            string Programa = "Proprensw";
            InterfazGestor ImplementacionGestor = new PropenswLN();//Se debe cambiar de acuerdo al resultado esperado

            InterfazFind FindGenerico = new PropenswFindLN(); //Cambiar Find Diferente Clase Especifica
            InterfazCodigo Codigo = new Peticion(); //Cambia si es simple o compuesta

            DataSet DTGestor = new DataSet();
            String DsGestor = new WsConsultas().ConsultaGenericaSateliteGestor(ImplementacionGestor, Satelite, Programa, FindGenerico, GenericoEN, Codigo);
            System.IO.StringReader xmlGestor = new System.IO.StringReader(DsGestor);
            DTGestor.ReadXml(xmlGestor);
            return DTGestor;
        }
    }
}