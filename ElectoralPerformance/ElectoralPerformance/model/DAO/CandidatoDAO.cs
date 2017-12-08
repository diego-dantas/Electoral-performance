using ElectoralPerformance.model.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DAO
{
    class CandidatoDAO
    {
        Connection connection = new Connection();
        DataTable dataTable = new DataTable();
        

        //metodo para buscar os nomes dos candidatos por cargo e cidade
        public DataTable selectCandidato(string eleicao, string codMunicipio, string idCargo)
        {
            string sql = "select 		ca.cpf, ca.nome " +
                         "from 			dados_eleicao de " +
                         "inner join 	candidato_sequencia cs on cs.sequencia = de.sequenciaCandidato " +
                         "inner join 	candidatos ca on ca.cpf = cs.cpf " +
                         "where			de.idEleicao = "+ eleicao + 
                         " and			de.codMunicipio = " + codMunicipio +
                         " and 			de.idCargo = " + idCargo;
           dataTable.Load(connection.select(sql));
            return dataTable;
        }

        
        //metodos por zona eleitoral para os candidatos a prefeito de araçatuba
        public MySqlDataReader selectVotoZona()
        {
            List<CandidatoDTO> candidato = new List<CandidatoDTO>();
            CandidatoDTO candidatoDTO = new CandidatoDTO();
            string sql = "select 		ca.cpf, ca.nome, vz.zona, vz.qtdVotos " +
                         "from 			dados_eleicao de " +
                         " inner join 	candidato_sequencia cs on cs.sequencia = de.sequenciaCandidato " +
                         " inner join 	candidatos ca on ca.cpf = cs.cpf " +
                         " inner join 	votacao_zona vz on vz.sequenciaCandidato = de.sequenciaCandidato " +
                         " where			de.idEleicao = 1 " +
                         " and			de.codMunicipio = 61557 " +
                         " and 			de.idCargo = 11  order by vz.qtdVotos desc";
            MySqlDataReader dataReader = connection.select(sql);
            return dataReader;
          
        }

        //Metodo para contar quantas zonas eleitoral o candidato teve votos
        public int countZonaCandidato(string codMun, string idEleicao, string cpf, string idCargo)
        {
            int qtd = 0;
            string sql = "select 		count(distinct(vz.zona)) qtdZona " +
                         "from 			dados_eleicao de " +
                         " inner join 	candidato_sequencia cs on cs.sequencia = de.sequenciaCandidato " +
                         " inner join 	candidatos ca on ca.cpf = cs.cpf " +
                         " inner join 	votacao_zona vz on vz.sequenciaCandidato = de.sequenciaCandidato " +
                         " where			de.idEleicao = " + idEleicao +
                         " and			de.codMunicipio =  " + codMun +
                         " and 			ca.cpf = " + cpf +
                         " and 			de.idCargo = " + idCargo +
                         " order by vz.qtdVotos desc";
            MySqlDataReader dataReader = connection.select(sql);
            if (dataReader.HasRows)
                dataReader.Read();
                    qtd = Convert.ToInt32(dataReader["qtdZona"]);

            return qtd;
        }

        public int getNumberCandidato(string codMun, string idEleicao, string cpf, string idCargo)
        {
            int qtd = 0;
            string sql = "select 		 	de.numeroCandidato numero " +
                         "from 			dados_eleicao de " +
                         " inner join 	candidato_sequencia cs on cs.sequencia = de.sequenciaCandidato " +
                         " inner join 	candidatos ca on ca.cpf = cs.cpf " +
                         " where			de.idEleicao = " + idEleicao +
                         " and			de.codMunicipio =  " + codMun +
                         " and 			ca.cpf = " + cpf +
                         " and 			de.idCargo = " + idCargo;
                         
            MySqlDataReader dataReader = connection.select(sql);
            if (dataReader.HasRows)
                dataReader.Read();
            qtd = Convert.ToInt32(dataReader["numero"]);

            return qtd;
        }

        //Metodos para buscar a qtd de votos por seção do candidato
        public MySqlDataReader selectVotoZonaCandidato(string codMun, string idEleicao, string cpf, string idCargo)
        {
            string sql = "select 		ca.cpf, ca.nome, vz.zona, vz.qtdVotos " +
                         "from 			dados_eleicao de " +
                         " inner join 	candidato_sequencia cs on cs.sequencia = de.sequenciaCandidato " +
                         " inner join 	candidatos ca on ca.cpf = cs.cpf " +
                         " inner join 	votacao_zona vz on vz.sequenciaCandidato = de.sequenciaCandidato " +
                         " where			de.idEleicao = " + idEleicao +
                         " and			de.codMunicipio =  " + codMun +
                         " and 			ca.cpf = " + cpf  +
                         " and 			de.idCargo = " + idCargo +
                         " order by vz.qtdVotos desc";
            MySqlDataReader dataReader = connection.select(sql);
            return dataReader;

        }

        //metodo para buscar a qtd de votos dos candidatos a prefeito de araçatuba 
        public MySqlDataReader selectVotoEleicao()
        {
            string sql = "select 		ca.cpf, ca.nome, sum(vz.qtdVotos) votos " +
                            "from 			dados_eleicao de " +
                            " inner join 	candidato_sequencia cs on cs.sequencia = de.sequenciaCandidato " +
                            " inner join 	candidatos ca on ca.cpf = cs.cpf " +
                            " inner join 	votacao_zona vz on vz.sequenciaCandidato = de.sequenciaCandidato " +
                            " where			de.idEleicao = 1 " +
                            " and			de.codMunicipio = 61557 " +
                            " and 			de.idCargo = 11  " +
                            " group by ca.cpf, ca.nome order by votos desc";
            MySqlDataReader dataReader = connection.select(sql);
            return dataReader;
        }


        //buscar os votos por seção do dilador 
        public DataTable selectVotoSecao()
        {
            string sql = "select c.idZona as ZONA, c.idSecao AS 'SECAO', sum(c.qtdVotos) AS VOTOS " +
                         "from voto_secao c " +
                         "where c.codMunicipio = 61557 " +
                         " and c.idCargo = 11 " +
                         " and c.numCandidato = 45 " +
                         " group by c.numCandidato, c.idZona, c.idSecao " +
                         " order by sum(c.qtdVotos) desc ";
            dataTable.Load(connection.select(sql));
            return dataTable;
        }


        //buscar os votos por seção do dilador 
        public MySqlDataReader selectVotoSecaoPorCandidato(string codMu, string codCargo, string numCand)
        {
            string sql = "select c.idZona as ZONA, c.idSecao AS secao, sum(c.qtdVotos) AS VOTOS " +
                         "from voto_secao c " +
                         "where c.codMunicipio = " + codMu + 
                         " and c.idCargo = " + codCargo + 
                         " and c.numCandidato = " + numCand +
                         " group by c.numCandidato, c.idZona, c.idSecao " +
                         " order by sum(c.qtdVotos) desc limit 0, 100";
           MySqlDataReader dataReader =  connection.select(sql);
           return dataReader;
        }




    }
}
