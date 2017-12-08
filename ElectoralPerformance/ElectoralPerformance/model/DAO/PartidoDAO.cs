using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DAO
{
    class PartidoDAO
    {
        Connection connection = new Connection();


        public MySqlDataReader selectRankPartido(string idEle, string codMun)
        {
            string sql = "select p.sigla, p.nomePartido, p.numeroPartido, sum(vz.qtdVotos) votos " +
                        "from dados_eleicao de " +
                        "inner join partidos p on p.numeroPartido = de.codPartido " +
                        "inner join votacao_zona vz on vz.sequenciaCandidato = de.sequenciaCandidato " +
                        " where de.codMunicipio = " + codMun +
                        " and de.idEleicao = " + idEle +
                        " group by p.sigla, p.nomePartido " +
                        " order by sum(vz.qtdVotos) desc ";
            MySqlDataReader dataReader = connection.select(sql);
            return dataReader;
        }

        public MySqlDataReader selectRankCargo(string idEle, string codMun, string idCargo)
        {
            string sql = "select p.sigla, p.nomePartido, p.numeroPartido, sum(vz.qtdVotos) votos " +
                        "from dados_eleicao de " +
                        "inner join partidos p on p.numeroPartido = de.codPartido " +
                        "inner join votacao_zona vz on vz.sequenciaCandidato = de.sequenciaCandidato " +
                        " where de.codMunicipio = " + codMun +
                        " and de.idEleicao = " + idEle +
                        " and de.idCargo = " + idCargo +
                        " group by p.sigla, p.nomePartido " +
                        " order by sum(vz.qtdVotos) desc ";
            MySqlDataReader dataReader = connection.select(sql);
            return dataReader;
        }
    }
}
