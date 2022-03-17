namespace Optsol.GestaoEstoque.Dominio.Entidades
{
    public class VendaProduto
    {
        public int Id { get; set; }
        public int QuantidadeVendida { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public VendaProduto()
        {
        }

        public VendaProduto(int vendaId, int produtoId, int quantidadeVendida) : this()
        {
            VendaId = vendaId;
            ProdutoId = produtoId;
            QuantidadeVendida = quantidadeVendida;
        }
    }
}