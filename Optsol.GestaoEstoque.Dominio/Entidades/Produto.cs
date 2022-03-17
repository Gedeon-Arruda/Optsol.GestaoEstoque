using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public Deposito Deposito { get; set; }
        public int? DepositoId { get; set; }
        public ICollection<VendaProduto> Vendas { get; set; }

        public Produto()
        {
            Vendas = new List<VendaProduto>();
        }

        public Produto(string nome, int preco) : this()
        {
            Nome = nome;
            Preco = preco;
        }

        public Produto(string nome, int preco, Deposito deposito) : this()
        {
            Nome = nome;
            Preco = preco;
            Deposito = deposito;
            DepositoId = deposito.Id;
        }

        public void AlterarDeposito(Deposito deposito)
        {
            Deposito = deposito;
            DepositoId = Deposito.Id;
        }
    }
}