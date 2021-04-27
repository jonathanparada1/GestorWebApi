using System;
using System.Data;
using WebGestor.EN.Conversiones;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Resultados
{
    public class PropenswLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "ResultadoPropensw";

            // 2. Agregar nombre de los campos
            //DTConsultaGenerico.Columns.Add("Cupo");
            //DTConsultaGenerico.Columns.Add("FechaMovimiento");
            //DTConsultaGenerico.Columns.Add("FechaRadicacion");
            //DTConsultaGenerico.Columns.Add("Observacion 1");
            //DTConsultaGenerico.Columns.Add("Observacion 2");
            //DTConsultaGenerico.Columns.Add("Observacion 3");
            //DTConsultaGenerico.Columns.Add("NroCons");
            //DTConsultaGenerico.Columns.Add("Paso Ejecutado");
            //DTConsultaGenerico.Columns.Add("Comite");
            //DTConsultaGenerico.Columns.Add("Usuario");

            if (DsResultado.Tables[0].Columns.Contains("Mensaje"))
            {
                DTConsultaGenerico.Columns.Add("Mensaje");
            }
            else if (DsResultado.Tables[0].Columns.Contains("Error"))
            {
                DTConsultaGenerico.Columns.Add("Error");
            }

            //3. Agregar la información
            for (int i = 0; i < DsResultado.Tables["Resultado"].Rows.Count; i++)
            {
                DTConsultaGenerico.Rows.Add(

                 DTConsultaGenerico.Columns.Contains("Mensaje") ? DsResultado.Tables["Resultado"].Rows[i]["Mensaje"].ToString().Trim() :
                                                                  DsResultado.Tables["Resultado"].Rows[i]["Error"].ToString().Trim()
                 //, FormateoCampos.fechaJulianaToGregoriana(Convert.ToInt64(DsResultado.Tables["Resultado"].Rows[i]["FechaMovimiento"].ToString().Trim()))
                 //, FormateoCampos.fechaJulianaToGregoriana(Convert.ToInt64(DsResultado.Tables["Resultado"].Rows[i]["FechaRadicacion"].ToString().Trim()))
                 //, DsResultado.Tables["Resultado"].Rows[i]["Observacion 1"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Observacion 2"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Observacion 3"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["NroCons"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Paso Ejecutado"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Comite"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Usuario"].ToString().Trim()
                 );
            }
            return DTConsultaGenerico;
        }
    }
}