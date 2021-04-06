using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGestor.EN.Conversiones;

namespace WsGestor.LN.Consultas
{
    public class AplicacionCesionLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "AplicacionCesion";

            // 2. Agregar nombre de los campos
            DTConsultaGenerico.Columns.Add("Cupo");
            DTConsultaGenerico.Columns.Add("Contrato");
            DTConsultaGenerico.Columns.Add("Usuario_Cargue");
            DTConsultaGenerico.Columns.Add("Fecha_Cargue");
            DTConsultaGenerico.Columns.Add("Nombres_Titular");
            DTConsultaGenerico.Columns.Add("Apellidos_Titular");
            DTConsultaGenerico.Columns.Add("Tip_Doc_Titular");
            DTConsultaGenerico.Columns.Add("Doc_Titular");
            DTConsultaGenerico.Columns.Add("Fec_Nac");
            DTConsultaGenerico.Columns.Add("Correo_Titular");
            DTConsultaGenerico.Columns.Add("Ciudad_Titular");
            DTConsultaGenerico.Columns.Add("Direct_Titular");
            DTConsultaGenerico.Columns.Add("Tel_Titular");
            DTConsultaGenerico.Columns.Add("Cel_Titular");
            DTConsultaGenerico.Columns.Add("Nombre_SegTitular");
            DTConsultaGenerico.Columns.Add("Apellido_SegTitular");
            DTConsultaGenerico.Columns.Add("Tip_Doc_SegTitular");
            DTConsultaGenerico.Columns.Add("Doc_SegTitular");
            DTConsultaGenerico.Columns.Add("Fec_Nac_SegTitular");
            DTConsultaGenerico.Columns.Add("Correo_SegTitular");
            DTConsultaGenerico.Columns.Add("Ciudad_SegTitular");
            DTConsultaGenerico.Columns.Add("Direct_SegTitular");
            DTConsultaGenerico.Columns.Add("Tel_SegTitular");
            DTConsultaGenerico.Columns.Add("Cel_SegTitular");

            //3. Agregar la información
            for (int i = 0; i < DsResultado.Tables["Resultado"].Rows.Count; i++)
            {
                DTConsultaGenerico.Rows.Add(

                DsResultado.Tables["Resultado"].Rows[i]["ID-LLAVE"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CONTRATO"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["USUARIO"].ToString().Trim()
                , FormateoCampos.ConvertFechaGestor(DsResultado.Tables["Resultado"].Rows[i]["FECHA-CARGUE"].ToString().Trim())
                , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["PSNOMBRET1"].ToString().Trim())
                , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["PSAPELLIDOT1"].ToString().Trim())
                , DsResultado.Tables["Resultado"].Rows[i]["TIP-DOCT1"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["NUM-IDENT1"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["FEC-NACIT1"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CORREOT1"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CIUDADT1"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["DIRECT1"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["TELT1"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CELT1"].ToString().Trim()
                , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["PSNOMBRET2"].ToString().Trim())
                , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["PSAPELLIDOT2"].ToString().Trim())
                , DsResultado.Tables["Resultado"].Rows[i]["TIP-DOCT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["NUM-IDENT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["FEC-NACIT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CORREOT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CIUDADT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["DIRECT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["TELT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CELT2"].ToString().Trim());

            }
            return DTConsultaGenerico;
        }
    }
}
