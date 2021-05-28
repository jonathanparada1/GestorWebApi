using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Find
{
    public class GarantiaFindLN : InterfazFind
    {

        public override object FindGenerico(string Programa, object obj)
        {
            GarantiaEN objparm_inputFind = new GarantiaEN();
            GarantiaEN ObjCast = (GarantiaEN)obj;

            objparm_inputFind.l_PROGRAMA = Programa;
            objparm_inputFind.l_CUPO_L = ObjCast.l_CUPO_L;
            objparm_inputFind.l_FECHA_MOV = ObjCast.l_FECHA_MOV;
            objparm_inputFind.l_FECHA_RAD = ObjCast.l_FECHA_RAD;
            objparm_inputFind.l_PAS_EJECUTADO = ObjCast.l_PAS_EJECUTADO;
            objparm_inputFind.l_TIPO_GARA = ObjCast.l_TIPO_GARA;
            objparm_inputFind.l_PLACA = ObjCast.l_PLACA;
            objparm_inputFind.l_TIPO_SERV = ObjCast.l_TIPO_SERV;
            objparm_inputFind.l_MARCA = ObjCast.l_MARCA;
            objparm_inputFind.l_MODELO = ObjCast.l_MODELO;
            objparm_inputFind.l_MOTOR = ObjCast.l_MOTOR;
            objparm_inputFind.l_FEC_PRE = ObjCast.l_FEC_PRE;
            objparm_inputFind.l_SERIE = ObjCast.l_SERIE;
            objparm_inputFind.l_VALOR = ObjCast.l_VALOR;
            objparm_inputFind.l_COLOR = ObjCast.l_COLOR;
            objparm_inputFind.l_FASECOLDA = ObjCast.l_FASECOLDA;
            objparm_inputFind.l_TIP_VEH = ObjCast.l_TIP_VEH;
            objparm_inputFind.l_AVAL = ObjCast.l_AVAL;
            objparm_inputFind.l_OBS_1 = ObjCast.l_OBS_1;
            objparm_inputFind.l_OBS_2 = ObjCast.l_OBS_2;
            objparm_inputFind.l_OBS_3 = ObjCast.l_OBS_3;
            objparm_inputFind.l_CLAVE = ObjCast.l_CLAVE;
            objparm_inputFind.l_CODIGO = ObjCast.l_CODIGO;


            return objparm_inputFind;
        }
    }
}
