using System;
using System.Data;

namespace WebGestor.Codigo
{
    public class PeticionCompuesta : InterfazCodigo
    {
        public override DataSet Resultado(DataSet DsInformacion, char[] delimiterChars)
        {
            DataSet DsResultado = new DataSet();

            try
            {
                DataTable dtImage = new DataTable();
                dtImage.TableName = "Resultado";
                string columna = string.Empty;
                string dato = string.Empty;
                int creadas = 0;
                string[] forarreglo;
                string[] forarreglointerno;
                if (DsInformacion.Tables["l_recordSet2"].Rows.Count > 0)
                {
                    for (int i = 0; i < DsInformacion.Tables["l_recordSet2"].Rows.Count; i++)
                    {
                        if (DsInformacion.Tables["l_recordSet2"].Rows[i]["l_recordSet2_Text"].ToString() != String.Empty)
                        {
                            forarreglo = DsInformacion.Tables["l_recordSet2"].Rows[i]["l_recordSet2_Text"].ToString().Split(delimiterChars);

                            for (int l = 0; l < forarreglo.Length; l++)
                            {
                                if (forarreglo[l].ToString() != String.Empty)
                                {
                                    forarreglointerno = forarreglo[l].ToString().Split(':');

                                    columna = forarreglointerno[0].ToString().Replace("\"", "");
                                    dato = forarreglointerno[1].ToString().Replace("\"", "");

                                    if (creadas == 0)
                                        dtImage.Columns.Add(columna);

                                    if (l == 0)
                                        dtImage.Rows.Add("");

                                    dtImage.Rows[i][columna] = dato.Trim();
                                }
                                else
                                {
                                    creadas = 1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                DsResultado.Tables.Add(dtImage);
                return DsResultado;
            }
            catch (Exception ex)
            {

                return DsResultado;
            }
        }

        public override string[] ObtenerRandom(DataSet dsConsulta)
        {
            string[] array = new string[2];

            try
            {

                array[0] = dsConsulta.Tables["parm_output"].Rows[0]["l_PROGRAMA"].ToString();
                array[1] = dsConsulta.Tables["parm_output"].Rows[0]["l_RANDOMX"].ToString();

                return array;
            }
            catch (Exception)
            {
                return array;
            }
        }
    }
}