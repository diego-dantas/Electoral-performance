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
        MySqlDataReader dataReader;
        DataTable dataTable = new DataTable();
        List<EleicoesDTO> eleicaoDTO;
        EleicoesDTO eleicoes = new EleicoesDTO();

        public DataTable select()
         {
            string query = "select id, descricao from eleicoes limit 1";
            dataReader = conn.select(query);
            dataTable.Load(dataReader);
            return dataTable;           
         }

    }


}
