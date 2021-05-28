using System;
using WsGestor.EN.Tablas;
using System.Collections.Generic;
using WsGestor.AD.Utilidades;

namespace WsGestor.AD.Consultas
{
    public class ParametrosAD
    {
        WcfData wsc = new WcfData();

        public IList<ParametrosEN> ConsultaParametrosAD(string Procedimiento, ParametrosEN objParametros)
        {

            List<ParametrosEN> listAsesor = new List<ParametrosEN>();
            List<string[,]> lista = new List<string[,]>();

            try
            {
                string[,,] Param = new string[1, 3, 1]; // solo cuando el procedimiento almacenado tiene parametros
                Param[0, 0, 0] = objParametros.idParametro.ToString();
                Param[0, 1, 0] = "@id";
                Param[0, 2, 0] = "int";

                lista = wsc.LlenarLista(Param, Procedimiento, "CHEVYSAT", "SP", "Sql");
                string[,] Valida;

                if (lista.Count > 0)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        ParametrosEN objParametrosSalida = new ParametrosEN();
                        Valida = lista[i];

                        objParametrosSalida.parametro = (Valida[2, 1].ToString());
         
                        listAsesor.Add(objParametrosSalida);
                    }
                }

                return listAsesor;
            }
            catch (Exception)
            {
                return listAsesor;
            }
        }
    }
}
