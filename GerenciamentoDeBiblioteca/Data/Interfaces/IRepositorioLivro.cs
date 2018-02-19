using GerenciamentoDeBiblioteca.Data.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciamentoDeBiblioteca.Data.Interfaces 
{
    public interface IRepositorioLivro : IRepositorio<Livro>
    {
        IEnumerable<Livro> BuscarTodosComAutor();
        IEnumerable<Livro> ProcurarComAutor(Func<Livro, bool> funcao);
        IEnumerable<Livro> ProcurarComAutorELocator(Func<Livro, bool> funcao);
    }
}
