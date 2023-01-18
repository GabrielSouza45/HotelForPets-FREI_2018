using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Folha_de_pagamento
{
    class FolhadePagamentoView
    {
        public int IdFolha { get; set; }
        public string NomeFuncionario { get; set; }
        public decimal Salario { get; set; }
        public decimal ValeTransporte { get; set; }
        public decimal ValeRefeicao { get; set; }
        public decimal ValeAlimentacao { get; set; }
        public decimal Convenio { get; set; }
        public decimal HorasExtras { get; set; }
        public decimal FGTS { get; set; }
        public decimal IR { get; set; }
        public decimal INSS { get; set; }
        public decimal SalarioFamilia { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal SalarioLiquido { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
