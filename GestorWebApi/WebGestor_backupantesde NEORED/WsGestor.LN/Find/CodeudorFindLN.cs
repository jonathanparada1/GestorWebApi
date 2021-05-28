using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Find
{
    public class CodeudorFindLN : InterfazFind

    {
        public override object FindGenerico(string Programa, object obj)
        {
            CodeudorEN objparm_inputFind = new CodeudorEN();
            CodeudorEN ObjCast = (CodeudorEN)obj;

            objparm_inputFind.l_PROGRAMA = Programa;
            objparm_inputFind.l_CUPO_L = ObjCast.l_CUPO_L;
            objparm_inputFind.l_FECHA_MOV = ObjCast.l_FECHA_MOV;
            objparm_inputFind.l_FECHA_RAD = ObjCast.l_FECHA_RAD;
            objparm_inputFind.l_PAS_EJECUTADO = ObjCast.l_PAS_EJECUTADO;
            objparm_inputFind.l_IDE_CLASE = ObjCast.l_IDE_CLASE;
            objparm_inputFind.l_IDE_NRO = ObjCast.l_IDE_NRO;
            objparm_inputFind.l_APELLIDO1 = ObjCast.l_APELLIDO1;
            objparm_inputFind.l_APELLIDO2 = ObjCast.l_APELLIDO2;
            objparm_inputFind.l_NOMBRE1 = ObjCast.l_NOMBRE1;
            objparm_inputFind.l_NOMBRE2 = ObjCast.l_NOMBRE2;
            objparm_inputFind.l_NOM_EMP = ObjCast.l_NOM_EMP;
            objparm_inputFind.l_VLR_ING = ObjCast.l_VLR_ING;
            objparm_inputFind.l_COD_CARGO = ObjCast.l_COD_CARGO;
            objparm_inputFind.l_RES_DIR = ObjCast.l_RES_DIR;
            objparm_inputFind.l_RES_DIR2 = ObjCast.l_RES_DIR2;
            objparm_inputFind.l_RES_TEL = ObjCast.l_RES_TEL;
            objparm_inputFind.l_RES_CIU = ObjCast.l_RES_CIU;
            objparm_inputFind.l_OFI_DIR = ObjCast.l_OFI_DIR;
            objparm_inputFind.l_OFI_DIR2 = ObjCast.l_OFI_DIR2;
            objparm_inputFind.l_OFI_TEL = ObjCast.l_OFI_TEL;
            objparm_inputFind.l_OFI_CIU = ObjCast.l_OFI_CIU;
            objparm_inputFind.l_EMAIL_01 = ObjCast.l_EMAIL_01;
            objparm_inputFind.l_BIEN_RAIZ = ObjCast.l_BIEN_RAIZ;
            objparm_inputFind.l_BIEN_ESC = ObjCast.l_BIEN_ESC;
            objparm_inputFind.l_BIEN_NOT = ObjCast.l_BIEN_NOT;
            objparm_inputFind.l_BIEN_DIR = ObjCast.l_BIEN_DIR;
            objparm_inputFind.l_BIEN_VLR = ObjCast.l_BIEN_VLR;
            objparm_inputFind.l_BIEN_CIU = ObjCast.l_BIEN_CIU;
            objparm_inputFind.l_BIEN_FEC = ObjCast.l_BIEN_FEC;
            objparm_inputFind.l_VEHICULO = ObjCast.l_VEHICULO;
            objparm_inputFind.l_VEH_MAR = ObjCast.l_VEH_MAR;
            objparm_inputFind.l_VEH_MOD = ObjCast.l_VEH_MOD;
            objparm_inputFind.l_VEH_PLAC = ObjCast.l_VEH_PLAC;
            objparm_inputFind.l_VEH_VLR = ObjCast.l_VEH_VLR;
            objparm_inputFind.l_VEH_RES = ObjCast.l_VEH_RES;
            objparm_inputFind.l_COD_RES = ObjCast.l_COD_RES;
            objparm_inputFind.l_E_RES_PAPELES = ObjCast.l_E_RES_PAPELES;
            objparm_inputFind.l_OBS_1 = ObjCast.l_OBS_1;
            objparm_inputFind.l_OBS_2 = ObjCast.l_OBS_2;
            objparm_inputFind.l_OBS_3 = ObjCast.l_OBS_3;
            objparm_inputFind.l_CLAVE = ObjCast.l_CLAVE;
            objparm_inputFind.l_CODIGO = ObjCast.l_CODIGO;

            return objparm_inputFind;
        }
    }
}
