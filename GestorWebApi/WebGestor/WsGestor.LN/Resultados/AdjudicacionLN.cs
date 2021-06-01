using System.Data;
using WebGestor.EN.Conversiones;

namespace WsGestor.LN.Consultas
{
    public class AdjudicacionLN : InterfazGestor
    {
        public override DataTable DataTableGenerico(DataSet DsResultado)
        {
            DataTable DTConsultaGenerico = new DataTable();

            // 1. Agregar nombre de la tabla
            DTConsultaGenerico.TableName = "Adjudicacion";

            // 2. Agregar nombre de los campos
            DTConsultaGenerico.Columns.Add("Cupo");
            DTConsultaGenerico.Columns.Add("Contrato");
            DTConsultaGenerico.Columns.Add("Usuario_Cargue");
            DTConsultaGenerico.Columns.Add("Fecha_Cargue");
            DTConsultaGenerico.Columns.Add("Fecha_Adjudicacion");
            DTConsultaGenerico.Columns.Add("Fecha_Movimiento");
            DTConsultaGenerico.Columns.Add("Valor_Adjudicacion");
            DTConsultaGenerico.Columns.Add("Tipo_Adjudicacion");
            DTConsultaGenerico.Columns.Add("Nombre_Plan");
            DTConsultaGenerico.Columns.Add("Cuota_Oferta");
            DTConsultaGenerico.Columns.Add("Valor_Oferta");
            DTConsultaGenerico.Columns.Add("Oferta_Pendiente_Pago");
            DTConsultaGenerico.Columns.Add("Concesionario");
            DTConsultaGenerico.Columns.Add("Sede");
            DTConsultaGenerico.Columns.Add("Cuota_Mora");
            DTConsultaGenerico.Columns.Add("Valor_Mora");
            DTConsultaGenerico.Columns.Add("Tipo_Resolucion");
            DTConsultaGenerico.Columns.Add("Fuerza_Venta");
            DTConsultaGenerico.Columns.Add("Estado_Afiliado");
            DTConsultaGenerico.Columns.Add("Tipo_Afiliado");
            DTConsultaGenerico.Columns.Add("Observacion");
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
            DTConsultaGenerico.Columns.Add("Num_Cuotas_Pagas");
            DTConsultaGenerico.Columns.Add("Valor_Cuo_Pagas");
            DTConsultaGenerico.Columns.Add("Plazo");
            DTConsultaGenerico.Columns.Add("Valor_Cuota");
            DTConsultaGenerico.Columns.Add("Altura_Adjudicacion");
            DTConsultaGenerico.Columns.Add("Cambio_Bien");
            DTConsultaGenerico.Columns.Add("Porcentaje_Adju");
            DTConsultaGenerico.Columns.Add("Debito_Automatico");
            DTConsultaGenerico.Columns.Add("Codigo_Adjudicacion");
            DTConsultaGenerico.Columns.Add("Plan_Mantenimiento");

            //3. Agregar la información
            for (int i = 0; i < DsResultado.Tables["Resultado"].Rows.Count; i++)
            {
                DTConsultaGenerico.Rows.Add(
                DsResultado.Tables["Resultado"].Rows[i]["ID-LLAVE"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CONTRATO"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["USUARIO"].ToString().Trim()
                , FormateoCampos.ConvertFechaGestor(DsResultado.Tables["Resultado"].Rows[i]["FECHA-CARGUE"].ToString().Trim())
                , FormateoCampos.ConvertFechaGestor(DsResultado.Tables["Resultado"].Rows[i]["FEC-ADJ-ASAM"].ToString().Trim())
                , FormateoCampos.ConvertFechaGestor(DsResultado.Tables["Resultado"].Rows[i]["FEC-ADJ-MOV"].ToString().Trim())
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-ADJ"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["TIPO-ADJ"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["NOM-PLAN"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CUO-OFERTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-OFERTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-OFE-PEN-PAGO"].ToString().Trim()
                , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["NOM-CONCE"].ToString().Trim())
                , FormateoCampos.FormatoHTML(DsResultado.Tables["Resultado"].Rows[i]["SEDE-ENTREGA"].ToString().Trim())
                , DsResultado.Tables["Resultado"].Rows[i]["CUO-MORA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-MORA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["TIP-RESOLU"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["FUERZA-VENTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["ESTADO-AFIL"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["TIPO-AFIL"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["PRORROGA"].ToString().Trim()
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
                , DsResultado.Tables["Resultado"].Rows[i]["CELT2"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["NUM-CUO-PAG"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VAL-CUO-PAG"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["PLAZO"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["VLR-CUOTA"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["ALT-ADJU"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["CAMBIO-FEC-BIEN"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["PORC-ADM"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["DEBITO-AUTO"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["COD-ADJ"].ToString().Trim()
                , DsResultado.Tables["Resultado"].Rows[i]["PLAN-MTO"].ToString().Trim());
            }
            return DTConsultaGenerico;
        }
    }
}