using System;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Entidades
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Comprador { get; set; }
        public ICollection<Produto> Produtos { get; set; }       

        public Venda()
        {
            Produtos = new List<Produto>();
        }

        public Venda(DateTime data, string comprador) : this()
        {
            Data = data;
            Comprador = comprador;
        }
    }
}