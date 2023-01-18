using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Funcionário.Ponto
{
    class PontoDTO
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public DateTime Data { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime IdaAlmoco { get; set; }
        public DateTime VoltaAlmoco { get; set; }
        public DateTime Saida { get; set; }
        public int HorasTrabalhadasDia { get; set; }
    }
}
