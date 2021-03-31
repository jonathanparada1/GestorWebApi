using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using WsGestor.EN.Tablas;

namespace WsGestor.LN.Consultas
{
    public class ClassGenericaSatelitesLN
    {

        public DataSet Consulta(ClassGenericaSateliteEN  Obj, string URL)
        {
            DataSet dsResultadoFind = new DataSet();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(URL.ToString());
                request.ContentType = "application/json";
                request.Method = "POST";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        parm_input = Obj
                    });

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                XmlDocument docxml = (XmlDocument)JsonConvert.DeserializeXmlNode(responseString, "root");
                StringReader xml = new StringReader(docxml.InnerXml.ToString());
                dsResultadoFind.ReadXml(xml);

                return dsResultadoFind;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return dsResultadoFind;
            }
        }
    }
}
