using System;
using System.Configuration;
using System.Data;
using WsGestor.EN.Tablas;
using WsGestor.LN.Consultas;
using WebGestor.Codigo;

namespace WebGestor.Consulta
{
    public class WsConsultas
    {
        public string ConsultaGenericaSateliteGestor(InterfazGestor I, String Satelite, String Programa, InterfazFind IF, Object entradas, InterfazCodigo Codigo)
        {
            //ClientesConPrin
            string programa = String.Empty;
            string random = String.Empty;
            DataSet DsResultado = new DataSet();
            DataSet DsConsultaGenericoRead = new DataSet();
            DataSet DsConsultaGenericoFind = new DataSet();
            DataTable DtEerror = new DataTable();
            DataSet DsConsultaGenerico = new DataSet();

            try
            {
                string URL = ConfigurationManager.AppSettings["Url"].ToString();

                string UrlFind = URL + Satelite + "/1.0/Find";

                InterfazFind consultasFind = IF;

                DsConsultaGenericoFind = new ClassGenericaSatelitesLN().Consulta(consultasFind.FindGenerico(programa, entradas), UrlFind); //ClaseLN

                if (DsConsultaGenericoFind.Tables["parm_output"].Rows.Count > 0)
                {
                    string[] array = Codigo.ObtenerRandom(DsConsultaGenericoFind);

                    programa = array[0];
                    random = array[1];

                    string UrlRead = URL + Satelite + "/1.0/Read";

                    ClassGenericaSateliteEN objparm_inputRead = new ClassGenericaSateliteEN();

                    objparm_inputRead.l_PROGRAMA = programa;
                    objparm_inputRead.l_RANDOMX = random;

                    DsConsultaGenericoRead = new ClassGenericaSatelitesLN().Consulta(objparm_inputRead, UrlRead);

                    if (DsConsultaGenericoRead.Tables["l_recordSet2"].Rows.Count > 0)
                    {
                        char[] delimiterChars = { '|' };

                        DsResultado = Codigo.Resultado(DsConsultaGenericoRead, delimiterChars);

                        if (DsResultado.Tables["Resultado"].Rows.Count > 0)
                        {
                            DsConsultaGenerico.Tables.Add(I.DataTableGenerico(DsResultado));
                        }

                        return DsConsultaGenerico.GetXml();
                    }
                    else
                    {
                        return DsConsultaGenerico.GetXml();
                    }
                }
                else
                {
                    return DsConsultaGenerico.GetXml();
                }
            }
            catch (Exception ex)
            {
                DtEerror = AgregarTabla(ex.Message, "0");
                DsConsultaGenerico.Tables.Add(DtEerror);
                return DsConsultaGenerico.GetXml();
            }
        }

        /// <summary>
        /// Agregar tabla al DataSet
        /// </summary>
        /// <param name="Valor"></param>
        /// <param name="Validacion"></param>
        /// <returns></returns>
        public DataTable AgregarTabla(String Valor, String Validacion)
        {
            DataTable dtImage = new DataTable();
            dtImage.TableName = "Resultado";
            dtImage.Columns.Add("Mensaje");
            dtImage.Columns.Add("Validacion");
            dtImage.Rows.Add(Valor, Validacion);
            return dtImage;
        }

    }
}