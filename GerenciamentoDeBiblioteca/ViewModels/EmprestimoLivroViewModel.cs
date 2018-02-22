using GerenciamentoDeBiblioteca.Data.Entidades;
using System.Collections.Generic;

namespace GerenciamentoDeBiblioteca.ViewModels
{
    public class EmprestimoLivroViewModel
    {
        public IEnumerable<Livro> Livros { get; set; }
    }
}
