using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DAO
{
    class EstadosDAO
    {
        Connection conn = new Connection();
        DataTable dataTable = new DataTable();

        public DataTable select()
        {
            string qry = "select * from estados";
            dataTable.Load(conn.select(qry));
            return dataTable;
        }
    }
}
