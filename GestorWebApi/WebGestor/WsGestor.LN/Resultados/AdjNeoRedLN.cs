using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebGestor.EN.Conversiones;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Resultados
{
    public class AdjNeoRedLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "ResultAdjudica";

            // 2. Agregar nombre de los campos
            DTConsultaGenerico.Columns.Add("EmailAddress");
            DTConsultaGenerico.Columns.Add("SFTPa.Llave");
            DTConsultaGenerico.Columns.Add("SFTPa.Contrato");
            DTConsultaGenerico.Columns.Add("SFTPa.FechaAdjudicacionD");
            DTConsultaGenerico.Columns.Add("SFTPa.TipoAfiliado");
            DTConsultaGenerico.Columns.Add("SFTPa.TipoAdjudicacion");
            DTConsultaGenerico.Columns.Add("SFTPa.EstadoAfiliado");
            DTConsultaGenerico.Columns.Add("SFTPa.Nombre");
            DTConsultaGenerico.Columns.Add("SFTPa.CuotasOfertadas");
            DTConsultaGenerico.Columns.Add("SFTPa.ValorOferta");
            DTConsultaGenerico.Columns.Add("SFTPa.Valorplan");
            DTConsultaGenerico.Columns.Add("SFTPa.ValorAdjudicacion");
            //DTConsultaGenerico.Columns.Add("Paso Ejecutado");
            //DTConsultaGenerico.Columns.Add("Pagare");
            //DTConsultaGenerico.Columns.Add("Usuario");

            //3. Agregar la información
            for (int i = 0; i < DsResultado.Tables["Resultado"].Rows.Count; i++)
            {
                DTConsultaGenerico.Rows.Add(
                DsResultado.Tables["Resultado"].Rows[i]["EMAIL"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["ID-LLAVE"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CONTRATO"].ToString().Trim()
                , FormateoCampos.ConvertFechaGestor(DsResultado.Tables["Resultado"].Rows[i]["FEC-ADJUD"].ToString().Trim().Replace("/",""))
                , DsResultado.Tables["Resultado"].Rows[i]["TIPO-AFIL"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["TIPO-ADJ"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["ESTADO-AFIL"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["AFILIADO"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CUO-OFERTADAS"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VAL-OFERTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VAL-PLAN"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VAL-ADJU"].ToString().Trim()
                 //, FormateoCampos.fechaJulianaToGregoriana(Convert.ToInt64(DsResultado.Tables["Resultado"].Rows[i]["FechaRadicacion"].ToString().Trim()))
                 //, DsResultado.Tables["Resultado"].Rows[i]["Observacion 1"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Observacion 2"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Observacion 3"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["NroCons"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Paso Ejecutado"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Pagare"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Usuario"].ToString().Trim()
                 );
            }
            return DTConsultaGenerico;
        }
    }
}