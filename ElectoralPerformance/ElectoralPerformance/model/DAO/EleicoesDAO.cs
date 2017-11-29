using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectoralPerformance.model.DAO;
using ElectoralPerformance.model.DTO;
using MySql.Data.MySqlClient;

namespace ElectoralPerformance.model.DAO
{
    public class EleicoesDAO
    {
        Connection conn = new Connection();
        MySqlDataReader dataReader;

        public List<EleicoesDTO>[] select()
        {
            string query = "select * from eleicoes";
            dataReader = conn.select(query);
            
            return List<EleicoesDTO>;
        }
       

    }


}
