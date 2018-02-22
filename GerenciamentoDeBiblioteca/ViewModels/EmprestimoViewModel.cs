using GerenciamentoDeBiblioteca.Data.Entidades;
using System.Collections.Generic;

namespace GerenciamentoDeBiblioteca.ViewModels
{
    public class EmprestimoViewModel
    {
        public Livro Livro { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
    }
}