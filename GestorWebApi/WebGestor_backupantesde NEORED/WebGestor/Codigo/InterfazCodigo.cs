using System.Data;

namespace WebGestor.Codigo
{
    public abstract class InterfazCodigo
    {
        public abstract DataSet Resultado(DataSet DsInformacion, char[] delimiterChars);

        public abstract string[] ObtenerRandom(DataSet dsConsulta);

    }
}