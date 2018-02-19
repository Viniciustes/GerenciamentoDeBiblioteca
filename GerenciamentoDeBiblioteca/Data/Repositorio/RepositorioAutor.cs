using GerenciamentoDeBiblioteca.Data.Contexto;
using GerenciamentoDeBiblioteca.Data.Entidades;
using GerenciamentoDeBiblioteca.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoDeBiblioteca.Data.Repositorio
{
    public class RepositorioAutor : Repositorio<Autor>, IRepositorioAutor
    {
        public RepositorioAutor(DbBibliotecaContexto db) : base(db) { }

        public Autor BuscarComLivrosPorId(Guid id) => _db.Autores.Where(v => v.AutorId == id).Include(v => v.Livros).FirstOrDefault();

        public IEnumerable<Autor> BuscarTodosComLivros() => _db.Autores.Include(v => v.Livros);
    }
}
