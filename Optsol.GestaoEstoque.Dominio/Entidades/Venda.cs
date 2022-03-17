using System;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Entidades
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Comprador { get; set; }
        public ICollection<VendaProduto> Produtos { get; set; }

        public Venda()
        {
            Produtos = new List<VendaProduto>();
            Data = DateTime.Now;
        }

        public Venda(string comprador) : this()
        {
            Comprador = comprador;
        }
    }
}