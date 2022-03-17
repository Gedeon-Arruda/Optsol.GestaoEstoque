namespace Optsol.GestaoEstoque.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public DepositoViewModel Deposito { get; set; }
    }
}