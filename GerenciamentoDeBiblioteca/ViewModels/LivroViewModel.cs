using GerenciamentoDeBiblioteca.Data.Entidades;
using System.Collections.Generic;

namespace GerenciamentoDeBiblioteca.ViewModels
{
    public class LivroViewModel
    {
        public Livro Livro { get; set; }
        public IEnumerable<Autor> Autores { get; set; }
    }
}