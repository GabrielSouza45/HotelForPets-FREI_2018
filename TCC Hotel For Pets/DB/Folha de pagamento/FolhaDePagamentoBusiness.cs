using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Folha_de_pagamento
{
    class FolhaDePagamentoBusiness
    {
        public int Salvar(FolhaDePagamentoDTO dto)
        {
            FolhaDePagamentoDatabase db = new FolhaDePagamentoDatabase();
            return db.Salvar(dto);
        }

        public List<FolhadePagamentoView> Consultar(string nome)
        {
            FolhaDePagamentoDatabase db = new FolhaDePagamentoDatabase();
            return db.Consultar(nome);
        }

        public List<FolhadePagamentoView> Listar()
        {
            FolhaDePagamentoDatabase db = new FolhaDePagamentoDatabase();
            return db.Listar();
        }

        public void Remover(int id)
        {
            FolhaDePagamentoDatabase db = new FolhaDePagamentoDatabase();
            db.Remover(id);
        }
    }
}
