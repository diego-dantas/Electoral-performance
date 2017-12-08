using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DAO
{
    class ZonaDAO
    {
        Connection connection = new Connection();
        DataTable dataTable = new DataTable();

        public DataTable selectZonaCidade(string codMun, string idEle)
        {
            string sql = "select distinct(numZona) zona from perfil_zona p where p.codMunicipio = " + codMun + " and p.idEleicao = " + idEle;
            dataTable.Load(connection.select(sql));
            return dataTable;
        }


        public DataTable selectPerfilEleitoral(string codMun, string idEle, string zona)
        {
            string sql = "select el.descricao as 'Eleicao', " +
                        "			 c.municipio as Cidade, " +
                        "			 p.numZona as Zona, " +
                        "			 case  " +
                        "			 	when p.sexo = 'F' then 'Feminino' " +
                        "			 	when p.sexo = 'M' then 'Masculuno' " +
                        "			 	else 'Não informado' " +
                        "			end as sexo, " +
                        "			p.faixa_etaria as 'Faixa de idade', " +
                        "			g.grauInstrucao as Escolaridade, " +
                        "			p.qtdEleitor 'Qtd de eleitor' " +
                        "	from perfil_zona p " +
                        "	inner join eleicoes el on el.id = p.idEleicao " +
                        "	inner join cidades c on c.codMunicipio = p.codMunicipio " +
                        "	inner join grau_instrucao g on g.id = p.idGraInst " +
                        "	where p.codMunicipio = " + codMun +
                        "	and p.idEleicao = " + idEle +
                        "   and p.numZona = " + zona +
                        "	order by p.qtdEleitor desc ";
            dataTable.Load(connection.select(sql));
            return dataTable;
        }
    }
}
