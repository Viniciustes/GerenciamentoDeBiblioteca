using GerenciamentoDeBiblioteca.Data.Contexto;
using GerenciamentoDeBiblioteca.Data.Entidades;
using GerenciamentoDeBiblioteca.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoDeBiblioteca.Data.Repositorio
{
    public class RepositorioLivro : Repositorio<Livro>, IRepositorioLivro
    {
        public RepositorioLivro(DbBibliotecaContexto db) : base(db) { }

        public IEnumerable<Livro> BuscarTodosComAutor() => _db.Livros.Include(v => v.Autor);

        public IEnumerable<Livro> ProcurarComAutor(Func<Livro, bool> expressao) => _db.Livros.Include(v => v.Autor).Where(expressao);

        public IEnumerable<Livro> ProcurarComAutorELocator(Func<Livro, bool> expressao) => _db.Livros.Include(v => v.Autor).Include(v => v.Cliente).Where(expressao);
    }
}
