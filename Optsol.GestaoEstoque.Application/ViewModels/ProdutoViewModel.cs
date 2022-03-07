using Optsol.GestaoEstoque.Dominio.Entidades;

namespace Optsol.GestaoEstoque.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public string Comprador { get; set; }
        public string CodigoVenda { get; set; }
        public DepositoViewModel Deposito { get; set; }
    }
}