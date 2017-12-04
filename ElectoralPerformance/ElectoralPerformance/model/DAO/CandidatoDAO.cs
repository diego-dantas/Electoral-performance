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
                         " and 			de.idCargo = 11  ";
            MySqlDataReader dataReader = connection.select(sql);
            return dataReader;
           /* if (dataReader.HasRows)
            {


                while (dataReader.Read())
                {
                    candidatoDTO.Cpf = Convert.ToDouble(dataReader["cpf"]);
                    candidatoDTO.Nome = Convert.ToString(dataReader["nome"]);
                    candidatoDTO.Zona = Convert.ToInt32(dataReader["zona"]);
                    candidatoDTO.Votos = Convert.ToInt32(dataReader["qtdVotos"]);
                    candidato.Add(candidatoDTO);
                }
                    
                
             
            }*/
        }
         

    }
}
