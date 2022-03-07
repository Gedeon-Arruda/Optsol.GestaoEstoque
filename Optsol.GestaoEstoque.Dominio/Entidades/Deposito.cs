using System;
using System.Collections.Generic;
using System.Linq;

namespace Optsol.GestaoEstoque.Dominio.Entidades
{
    public class Deposito
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }     

        public ICollection<Produto> Produtos { get; private set; }

        public Deposito()
        {
            Produtos = new List<Produto>();
        }

        public Deposito(string nome, string localizacao) : this()
        {
            Nome = nome;
            Localizacao = localizacao;
        }

        public void RemoverProdutoPorId(int produtoId)
        {
            var produto = Produtos.First(x => x.Id == produtoId);
            Produtos.Remove(produto);
        }
    }
}