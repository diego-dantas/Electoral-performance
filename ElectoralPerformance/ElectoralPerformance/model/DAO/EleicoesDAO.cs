using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectoralPerformance.model.DAO;
using ElectoralPerformance.model.DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace ElectoralPerformance.model.DAO
{
    public class EleicoesDAO
    {
        Connection conn = new Connection();
        DataTable dataTable = new DataTable();

        public DataTable select()
         {
            string query = "select id, descricao from eleicoes";
            dataTable.Load(conn.select(query));
            return dataTable;           
         }

    }


}
