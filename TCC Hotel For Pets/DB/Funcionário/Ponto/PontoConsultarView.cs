using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Funcionário.Ponto
{
    class PontoConsultarView
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan IdaAlmoco { get; set; }
        public TimeSpan VoltaAlmoco { get; set; }
        public TimeSpan Saida { get; set; }
        public int HorasTrabalhadasDia { get; set; }
    }
}
