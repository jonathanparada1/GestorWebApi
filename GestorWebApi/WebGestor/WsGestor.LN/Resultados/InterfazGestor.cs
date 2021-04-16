using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WsGestor.LN.Consultas
{
    public abstract class InterfazGestor
    {
        public abstract DataTable DataTableGenerico(DataSet DsResultado);
    }
}
