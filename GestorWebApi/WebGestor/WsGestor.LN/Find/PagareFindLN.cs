using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Find
{
    public class PagareFindLN : InterfazFind
    {
        public override object FindGenerico(string Programa, object obj)
        {
            PagareEN objparm_inputFind = new PagareEN();
            PagareEN ObjCast = (PagareEN)obj;

            objparm_inputFind.l_PROGRAMA = Programa;
            objparm_inputFind.l_CUPO_L = ObjCast.l_CUPO_L;
            objparm_inputFind.l_FECHA_MOV = ObjCast.l_FECHA_MOV;
            objparm_inputFind.l_FECHA_RAD = ObjCast.l_FECHA_RAD;
            objparm_inputFind.l_PAS_EJECUTADO = ObjCast.l_PAS_EJECUTADO;
            objparm_inputFind.l_PAGARE = ObjCast.l_PAGARE;
            objparm_inputFind.l_CODIGO_1 = ObjCast.l_CODIGO_1;
            objparm_inputFind.l_CODIGO_2 = ObjCast.l_CODIGO_2;
            objparm_inputFind.l_OBS_1 = ObjCast.l_OBS_1;
            objparm_inputFind.l_OBS_2 = ObjCast.l_OBS_2;
            objparm_inputFind.l_OBS_3 = ObjCast.l_OBS_3;
            objparm_inputFind.l_CLAVE = ObjCast.l_CLAVE;
            objparm_inputFind.l_CODIGO = ObjCast.l_CODIGO;

            return objparm_inputFind;
        }
    }
}

