using System.Data;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Resultados
{
    public class PasoCuatroLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "ResultadoCodeudor";

            // 2. Agregar nombre de los campos
            //DTConsultaGenerico.Columns.Add("Cupo");
            //DTConsultaGenerico.Columns.Add("FechaMovimiento");
            //DTConsultaGenerico.Columns.Add("FechaRadicacion");
            //DTConsultaGenerico.Columns.Add("Codeudor");
            //DTConsultaGenerico.Columns.Add("Vehiculo");
            //DTConsultaGenerico.Columns.Add("NroCons");
            //DTConsultaGenerico.Columns.Add("Paso Ejecutado");
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
                 //DsResultado.Tables["Resultado"].Rows[i]["Cupo"].ToString().Trim()
                 //, FormateoCampos.fechaJulianaToGregoriana(Convert.ToInt64(DsResultado.Tables["Resultado"].Rows[i]["FechaMovimiento"].ToString().Trim()))
                 //, FormateoCampos.fechaJulianaToGregoriana(Convert.ToInt64(DsResultado.Tables["Resultado"].Rows[i]["FechaRadicacion"].ToString().Trim()))
                 //, DsResultado.Tables["Resultado"].Rows[i]["Codeudor"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Vehiculo"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["NroCons"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Paso Ejecutado"].ToString().Trim()
                 //, DsResultado.Tables["Resultado"].Rows[i]["Usuario"].ToString().Trim()
                 );
            }
            return DTConsultaGenerico;
        }
    }
}
