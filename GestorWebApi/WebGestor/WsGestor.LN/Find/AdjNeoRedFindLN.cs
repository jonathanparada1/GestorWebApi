using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Find
{
    public class AdjNeoRedFindLN : InterfazFind
    {
        public override object FindGenerico(string Programa, object obj)
        {
            AdjNeoRedEN objparm_inputFind = new AdjNeoRedEN();//ClaseENEspecifica
            AdjNeoRedEN ObjCast = (AdjNeoRedEN)obj;//Cast para el obj

            objparm_inputFind.l_PROGRAMA = Programa;
            objparm_inputFind.l_FEC_INICIAL = ObjCast.l_FEC_INICIAL;

            return objparm_inputFind;
        }
    }
}