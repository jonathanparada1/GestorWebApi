using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebGestor.EN.Conversiones
{
    public class FormateoCampos
    {
        public static string ConvertFechaMov(String date)
        {
            if (string.IsNullOrEmpty(date) || Convert.ToInt32(date) == 0)
                return "";
            else
            {
                String Año = String.Empty;
                if (Convert.ToInt32(date.Substring(0, 2)) >= 90)
                    Año = "19";
                else
                    Año = "20";

                date = date.Substring(4, 2).PadLeft(2, '0') + "/" + date.Substring(2, 2).PadLeft(2, '0') + "/" + (Año + date.Substring(0, 2)).PadLeft(4, '0');
                return date;
            }
        }
        public static string ConvertFechaGestor(String date)
        {
            string fechaSalidaGestor = string.Empty;

            if (string.IsNullOrEmpty(date) || Convert.ToInt32(date) == 0)
                return "";
            else
            {
                int año = Convert.ToInt32(date.Substring(0, 2)) + 2000;
                int mes = Convert.ToInt32(date.Substring(2, 2));
                int dia = Convert.ToInt32(date.Substring(4, 2));
                int hora = Convert.ToInt32(date.Substring(6, 2));
                int min = Convert.ToInt32(date.Substring(8, 2));

                DateTime fechaGestor = new DateTime(año, mes, dia, hora, min, 0);

                fechaSalidaGestor = fechaGestor.ToString("dd/MM/yyyy HH:mm");
            }

            return fechaSalidaGestor;
        }

        public static string ConvertFechaEstructura(String date)
        {
            if (string.IsNullOrEmpty(date))
                return "";
            else
            {
                String Año = String.Empty;
                if (Convert.ToInt32(date.Substring(0, 2)) >= 90)
                    Año = "19";
                else
                    Año = "20";

                date = date.Substring(6, 2).PadLeft(2, '0') + "/" + date.Substring(3, 2).PadLeft(2, '0') + "/" + (Año + date.Substring(0, 2)).PadLeft(4, '0');
                return date;
            }
        }

        public static string AgregarPorcentaje(String Campo)
        {
            if (string.IsNullOrEmpty(Campo))
                return "";
            else
            {
                Campo = Campo + "%";
                return Campo;
            }

        }

        public static string ConvertFechaCliente(String date)
        {
            if (string.IsNullOrEmpty(date) || Convert.ToInt32(date) == 0)
                return "";
            else
            {
                String Año = String.Empty;
                if (Convert.ToInt32(date.Substring(0, 2)) >= 45)
                    Año = "19";
                else
                    Año = "20";

                date = date.Substring(4, 2).PadLeft(2, '0') + "-" + date.Substring(2, 2).PadLeft(2, '0') + "-" + (Año + date.Substring(0, 2)).PadLeft(4, '0');
                return date;
            }
        }

        public static string ConvertFechaCentrales(String date)
        {
            if (string.IsNullOrEmpty(date))
                return "";
            else
            {
                String Año = String.Empty;
                if (Convert.ToInt32(date.Substring(3, 2)) >= 90)
                    Año = "19";
                else
                    Año = "20";

                date = date.Substring(0, 2).PadLeft(2, '0') + "/" + (Año + date.Substring(3, 2)).PadLeft(4, '0');
                return date;
            }
        }

        public static string FormatoHTML(String Palabra)
        {
            if (string.IsNullOrEmpty(Palabra))
                return "";
            else
            {
                Palabra = Palabra.Replace("á", "&aacute;");
                Palabra = Palabra.Replace("Á", "&Aacute;");
                Palabra = Palabra.Replace("é", "&eacute;");
                Palabra = Palabra.Replace("É", "&Eacute;");
                Palabra = Palabra.Replace("í", "&iacute;");
                Palabra = Palabra.Replace("Í", "&Iacute;");
                Palabra = Palabra.Replace("ñ", "&ntilde;");
                Palabra = Palabra.Replace("Ñ", "&Ntilde;");
                Palabra = Palabra.Replace("ó", "&oacute;");
                Palabra = Palabra.Replace("Ó", "&Oacute;");
                Palabra = Palabra.Replace("ú", "&uacute;");
                Palabra = Palabra.Replace("Ú", "&Uacute;");
                Palabra = Palabra.Replace("ü", "&uuml;");
                Palabra = Palabra.Replace("Ü", "&Uuml;");
                Palabra = Palabra.Replace("¿", "&iquest;");
                Palabra = Palabra.Replace("¡", "&iexcl;");

                Palabra = Palabra.Replace("Ä", "&Auml;");
                Palabra = Palabra.Replace("ä", "&auml;");
                Palabra = Palabra.Replace("Ö", "&Ouml;");
                Palabra = Palabra.Replace("ö", "&ouml;");
                Palabra = Palabra.Replace("ß", "&szlig;");

                Palabra = Palabra.Replace("â", "&acirc;;");
                Palabra = Palabra.Replace("ê", "&ecirc;;");
                Palabra = Palabra.Replace("ô", "&ocirc;;");


                Palabra = Palabra.Replace("Ã¡", "&aacute;"); //á
                Palabra = Palabra.Replace("Ã©", "&eacute"); //é
                Palabra = Palabra.Replace("Ã­", "&iacute");  //í
                Palabra = Palabra.Replace("Ã³", "&oacute"); //ó
                Palabra = Palabra.Replace("Ãº", "&uacute"); //ú

                Palabra = Palabra.Replace("Ã", "&Aacute;"); //Á
                Palabra = Palabra.Replace("Ã‰", "&Eacute;"); //É
                Palabra = Palabra.Replace("Ã", "&Iacute;"); //Í
                Palabra = Palabra.Replace("Ã“", "&Oacute;"); //Ó
                Palabra = Palabra.Replace("Ãš", "&Uacute;"); //Ú

                Palabra = Palabra.Replace("Ã‘", "&Ntilde;"); //Ñ
                Palabra = Palabra.Replace("Ã±", "&ntilde;"); //ñ


            }
            return Palabra;
        }
    }
}