using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ElectoralPerformance.model.DAO
{
    class CargosDAO
    {
        Connection connection = new Connection();
        DataTable dataTable = new DataTable();
        public DataTable select()
        {
            string qry = "select * from cargos";
            dataTable.Load(connection.select(qry));
            return dataTable;
        }
    }
}
