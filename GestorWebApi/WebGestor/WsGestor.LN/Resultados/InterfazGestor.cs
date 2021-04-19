using System.Data;

namespace WsGestor.LN.Consultas
{
    public abstract class InterfazGestor
    {
        public abstract DataTable DataTableGenerico(DataSet DsResultado);
    }
}
