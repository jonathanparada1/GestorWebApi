using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WsGestor.LN.Codigo
{
    public class Encriptador
    {
        /// <summary>
        /// Encripta un texto plano
        /// </summary>
        /// <param name="texto">Texto a encriptar</param>
        /// <returns>Texto encriptado</returns>
        /// 

        String texto { get; set; }
        String claveBase { get; set; }
        String valorRelleno = "mr#ts&jn";
        String algoritmoHash = "MD5";
        int iteraciones = 1;
        String vectorInicial = "@17HgR(78!jAQMN;";
        int tamanioClave = 256;

        /// <summary>
        /// Método para encriptar un texto plano
        /// </summary>
        /// <returns>Texto Encriptado</returns>
        public String encriptar(String texto, String claveBase)
        {
            byte[] vectorInicialBytes = Encoding.ASCII.GetBytes(vectorInicial);
            byte[] valorRellenoBytes = Encoding.ASCII.GetBytes(valorRelleno);
            byte[] textoBytes = Encoding.UTF8.GetBytes(texto);

            PasswordDeriveBytes clave = new PasswordDeriveBytes(claveBase, valorRellenoBytes, algoritmoHash, iteraciones);
            byte[] claveBytes = clave.GetBytes(tamanioClave / 8);

            RijndaelManaged claveSimetrica = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };

            ICryptoTransform encriptador = claveSimetrica.CreateEncryptor(claveBytes, vectorInicialBytes);
            MemoryStream objMemoryStream = new MemoryStream();
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, encriptador, CryptoStreamMode.Write);

            objCryptoStream.Write(textoBytes, 0, textoBytes.Length);
            objCryptoStream.FlushFinalBlock();
            byte[] textoCifradoBytes = objMemoryStream.ToArray();

            objMemoryStream.Close();
            objCryptoStream.Close();
            String cifradoTexto = Convert.ToBase64String(textoCifradoBytes);
            return cifradoTexto;
        }

        /// <summary> 
        /// Método para desencriptar un texto encriptado
        /// </summary>
        /// <returns>Texto desencriptado</returns> 
        public String desencriptar(String textoEncriptado, String claveBase)
        {

            try
            {
                byte[] vectorInicialBytes = Encoding.ASCII.GetBytes(vectorInicial);
                byte[] valorRellenoBytes = Encoding.ASCII.GetBytes(valorRelleno);
                byte[] textoCifradoBytes = Convert.FromBase64String(textoEncriptado);

                PasswordDeriveBytes clave = new PasswordDeriveBytes(claveBase, valorRellenoBytes, algoritmoHash, iteraciones);
                byte[] claveBytes = clave.GetBytes(tamanioClave / 8);

                RijndaelManaged claveSimetrica = new RijndaelManaged()
                {
                    Mode = CipherMode.CBC
                };

                ICryptoTransform desencriptador = claveSimetrica.CreateDecryptor(claveBytes, vectorInicialBytes);
                MemoryStream objMemoryStream = new MemoryStream(textoCifradoBytes);
                CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, desencriptador, CryptoStreamMode.Read);

                byte[] textoBytes = new byte[textoCifradoBytes.Length];
                int decryptedByteCount = objCryptoStream.Read(textoBytes, 0, textoBytes.Length);

                objMemoryStream.Close();
                objCryptoStream.Close();

                String textoOriginal = Encoding.UTF8.GetString(textoBytes, 0, decryptedByteCount);
                return textoOriginal;
            }
            catch (Exception)
            {

                return "Token Incorrecto";
            }
            
        }
    }
}
