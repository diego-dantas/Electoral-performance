using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DTO
{
    class CandidatoDTO
    {
        private double cpf;
        private string nome;
        private int zona;
        private int votos;

        public double Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Zona { get => zona; set => zona = value; }
        public int Votos { get => votos; set => votos = value; }
    }
}
