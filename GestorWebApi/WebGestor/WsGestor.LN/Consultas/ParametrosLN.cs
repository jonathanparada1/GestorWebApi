using System;
using System.Collections.Generic;
using WsGestor.EN.Tablas;
using WsGestor.AD.Consultas;
using WsGestor.LN.Codigo;

namespace WsGestor.LN.Consultas
{
    public class ParametrosLN
    {
        private String ProcedimientoConsultaParametros = "GES_Consulta_Parametros";

        public IList<ParametrosEN> ConsultarParametrosLN(ParametrosEN preEn)
        {
            IList<ParametrosEN> lista = new ParametrosAD().ConsultaParametrosAD(ProcedimientoConsultaParametros, preEn);
            return lista;
        }

        public String ValidarTokenLN(ParametrosEN ObjParametros)
        {
            string validacion;

            ParametrosLN ObjparamLN = new ParametrosLN();

            ParametrosEN ObjparamllaveEN = new ParametrosEN();
            ObjparamllaveEN.idParametro = 1;
            IList<ParametrosEN> listParametrosEN = ObjparamLN.ConsultarParametrosLN(ObjparamllaveEN);//Obtener llave DB

            Encriptador ObjEncriptar = new Encriptador();
            ObjParametros.tokenDesencriptado = ObjEncriptar.desencriptar(ObjParametros.token, listParametrosEN[0].parametro);//Desencriptar llave DB

            ParametrosEN ObjParamToken = new ParametrosEN();
            ObjParamToken.idParametro = 2;
            IList<ParametrosEN> listParamTokenEN = ObjparamLN.ConsultarParametrosLN(ObjParamToken);//Obtener Token DB

            if (listParamTokenEN[0].parametro == ObjParametros.tokenDesencriptado)
            {
                validacion = "Si";
            }
            else
            {
                validacion = "No";
            }
            return validacion;
        }

        public String EncriptarLN(ParametrosEN ObjParametros)
        {
            ParametrosLN ObjparamLN = new ParametrosLN();

            ParametrosEN ObjparamllaveEN = new ParametrosEN();
            ObjparamllaveEN.idParametro = 1;
            IList<ParametrosEN> listParametrosEN = ObjparamLN.ConsultarParametrosLN(ObjparamllaveEN);//Obtener llave DB

            Encriptador ObjEncriptar = new Encriptador();
            ObjParametros.tokenDesencriptado = ObjEncriptar.encriptar(ObjParametros.token, listParametrosEN[0].parametro);//Desencriptar llave DB

            return ObjParametros.tokenDesencriptado;
        }

    }
}
