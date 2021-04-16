using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebGestor.Codigo
{
    public class Peticion : InterfazCodigo
    {
        public override DataSet Resultado(DataSet DsInformacion, char[] delimiterChars)
        {
            DataSet DsResultado = new DataSet();

            try
            {
                DataTable dtImage = new DataTable();
                dtImage.TableName = "Resultado";
                string[] forarreglo;

                if (DsInformacion.Tables["l_recordSet2"].Rows.Count > 0)
                {
                    for (int i = 0; i < DsInformacion.Tables["l_recordSet2"].Rows.Count; i++)
                    {
                        if (DsInformacion.Tables["l_recordSet2"].Rows[i]["l_recordSet2_Text"].ToString() != String.Empty)
                        {
                            forarreglo = DsInformacion.Tables["l_recordSet2"].Rows[i]["l_recordSet2_Text"].ToString().Split(delimiterChars);

                            string columa = forarreglo[0].ToString().Replace("\"", "");
                            string dato = forarreglo[1].ToString().Trim();

                            dtImage.Columns.Add(columa);

                            if (i == 0)
                            {
                                dtImage.Rows.Add("");
                            }

                            dtImage.Rows[0][columa] = dato.Trim();
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