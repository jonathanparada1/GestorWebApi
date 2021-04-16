using System.Data;
using WsGestor.LN.Consultas;

namespace WsGestor.LN.Resultados
{
    public class ResultadoGenericoLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "Final";
            
            // 2. Agregar nombre de los campos
            DTConsultaGenerico.Columns.Add("Registro");

            //3. Agregar la información
            for (int i = 0; i < DsResultado.Tables["Resultado"].Rows.Count; i++)
            {
                DTConsultaGenerico.Rows.Add(

                 DsResultado.Tables["Resultado"].Rows[i]["Registro"].ToString().Trim());
            }
            return DTConsultaGenerico;

        }
    }
}
