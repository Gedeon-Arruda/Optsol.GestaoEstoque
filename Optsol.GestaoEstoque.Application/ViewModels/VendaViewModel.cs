using System;
using System.Collections.Generic;

namespace Optsol.GestaoEstoque.Application.ViewModels
{
    public class VendaViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Comprador { get; set; }
    }
}