using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPerformance.model.DTO
{
    class EstadosDTO
    {
        private int id;
        private string uf;
        private string estado;

        public int Id { get => id; set => id = value; }
        public string Uf { get => uf; set => uf = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
