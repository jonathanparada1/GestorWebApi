using System.Data;
using WebGestor.EN.Conversiones;

namespace WsGestor.LN.Consultas
{
    public class CambioBienLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "CambioBien";

            // 2. Agregar nombre de los campos
            DTConsultaGenerico.Columns.Add("Cupo");
            DTConsultaGenerico.Columns.Add("Contrato");
            DTConsultaGenerico.Columns.Add("Usuario_Cargue");
            DTConsultaGenerico.Columns.Add("Fecha_Cargue");
            DTConsultaGenerico.Columns.Add("Valor_Adjudicacion");
            DTConsultaGenerico.Columns.Add("Nombre_Plan");
            DTConsultaGenerico.Columns.Add("Cuota_Oferta");
            DTConsultaGenerico.Columns.Add("Valor_Oferta");
            DTConsultaGenerico.Columns.Add("Oferta_Pendiente_Pago");
            DTConsultaGenerico.Columns.Add("Valor_Cuota");
            DTConsultaGenerico.Columns.Add("No_Cuota_Pagas");
            DTConsultaGenerico.Columns.Add("Fecha_Cambio_Bien");

            //3. Agregar la información
            for (int i = 0; i < DsResultado.Tables["Resultado"].Rows.Count; i++)
            {
                DTConsultaGenerico.Rows.Add(

                DsResultado.Tables["Resultado"].Rows[i]["ID-LLAVE"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CONTRATO"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["USUARIO"].ToString().Trim()
                , FormateoCampos.ConvertFechaGestor(DsResultado.Tables["Resultado"].Rows[i]["FECHA-CARGUE"].ToString().Trim())
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-ADJ"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["NOM-PLAN"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CUO-OFERTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-OFERTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-OFE-PEN-PAGO"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-CUOTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["NUM-CUO-PAG"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CAMBIO-FEC-BIEN"].ToString().Trim());

            }
            return DTConsultaGenerico;
        }
    }
}
