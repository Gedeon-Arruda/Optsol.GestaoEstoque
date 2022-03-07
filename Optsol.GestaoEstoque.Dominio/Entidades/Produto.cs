namespace Optsol.GestaoEstoque.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public string Comprador { get; set; }
        public string CodigoVenda { get; set; }
        public Deposito Deposito { get; set; }
        public int? DepositoId { get; set; }
        public Venda Venda { get; set; }
        public int? VendaId { get; set; }    

        public Produto() 
        {
        }

        public Produto(string nome, int preco, string comprador, string codigoVenda) : this()
        {
            Nome = nome;
            Preco = preco;
            Comprador = comprador;
            CodigoVenda = codigoVenda;
        }

        public Produto(string nome, int preco, string comprador, string codigoVenda, Deposito deposito) : this()
        {
            Nome = nome;
            Preco = preco;
            Comprador = comprador;
            CodigoVenda = codigoVenda;
            Deposito = deposito;
            DepositoId = deposito.Id;
        }
    }
}