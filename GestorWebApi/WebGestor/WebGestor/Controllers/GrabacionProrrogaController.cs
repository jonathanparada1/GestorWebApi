﻿using System;
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
    public class GrabacionProrrogaController : ApiController
    {
        // GET: GrabacionProrroga
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]

        public Object Get()
        {
            string Satelite = "GrabacionProrrogaSI";
            string Programa = "GrabacionProrroga";
            InterfazGestor ImplementacionGestor = new GrabacionProrrogaLN();
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