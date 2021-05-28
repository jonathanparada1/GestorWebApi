using System;
using WsGestor.EN.Tablas;

namespace WsGestor.LN.Consultas
{
    public class ConsultaFindGenericoLN : InterfazFind
    {
        public override Object FindGenerico(string Programa, object obj)
        {
 
            ClassGenericaSateliteEN objparm_inputFind = new ClassGenericaSateliteEN(); //ClaseEN

            objparm_inputFind.l_PROGRAMA = Programa;

            return objparm_inputFind;
        }

    }
}
