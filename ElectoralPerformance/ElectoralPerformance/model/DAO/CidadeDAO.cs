using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DAO
{
    class CidadeDAO
    {
        Connection connection = new Connection();
        DataTable dataTable = new DataTable();

        public DataTable selectCidade(string codEstado)
        {
            string qry = "select * from cidades c where c.idEstado = " + codEstado + " order by c.municipio";
            dataTable.Load(connection.select(qry));
            return dataTable;
        }
    }
}
