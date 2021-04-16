using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGestor.EN.Conversiones;


namespace WsGestor.LN.Consultas
{
    public class CambioConcesionarioLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "CambioConcesionario";

            // 2. Agregar nombre de los campos
            DTConsultaGenerico.Columns.Add("Cupo");
            DTConsultaGenerico.Columns.Add("Contrato");
            DTConsultaGenerico.Columns.Add("Usuario_Cargue");
            DTConsultaGenerico.Columns.Add("Fecha_Cargue");
            DTConsultaGenerico.Columns.Add("Concesionario");
            DTConsultaGenerico.Columns.Add("Sede");

            //3. Agregar la información
            for (int i = 0; i < DsResultado.Tables["Resultado"].Rows.Count; i++)
            {
                DTConsultaGenerico.Rows.Add(

                 DsResultado.Tables["Resultado"].Rows[i]["ID-LLAVE"].ToString().Trim()
                 , DsResultado.Tables["Resultado"].Rows[i]["CONTRATO"].ToString().Trim()
                 , DsResultado.Tables["Resultado"].Rows[i]["USUARIO"].ToString().Trim()
                 , FormateoCampos.ConvertFechaGestor(DsResultado.Tables["Resultado"].Rows[i]["FECHA-CARGUE"].ToString().Trim())
                 , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["CONCESIONARIO"].ToString().Trim())
                 , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["SEDE-ENTREGA"].ToString().Trim()));
            }
            return DTConsultaGenerico;
        }
    }
}
