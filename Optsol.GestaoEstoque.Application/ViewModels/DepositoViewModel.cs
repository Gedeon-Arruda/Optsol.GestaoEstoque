using Optsol.GestaoEstoque.Dominio.Entidades;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.ViewModels
{
    public class DepositoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
    }
}