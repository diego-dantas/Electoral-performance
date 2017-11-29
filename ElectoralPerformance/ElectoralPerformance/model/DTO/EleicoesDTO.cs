using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DTO
{
    class EleicoesDTO
    {
        private int id;
        private int ano;
        private string descricao;

        public int Id { get => id; set => id = value; }
        public int Ano { get => ano; set => ano = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
