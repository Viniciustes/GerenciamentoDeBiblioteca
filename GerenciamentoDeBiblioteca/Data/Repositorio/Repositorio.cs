using GerenciamentoDeBiblioteca.Data.Contexto;
using GerenciamentoDeBiblioteca.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoDeBiblioteca.Data.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly DbBibliotecaContexto _db;

        public Repositorio(DbBibliotecaContexto db)
        {
            _db = db;
        }

        public void Apagar(T entidade)
        {
            _db.Remove(entidade);
            Salvar();
        }

        public void Atualizar(T entidade)
        {
            _db.Entry(entidade).State = EntityState.Modified;
            Salvar();
        }

        public void Cadastrar(T entidade)
        {
            _db.Add(entidade);
            Salvar();
        }

        public T BuscarPorId(Guid id) => _db.Set<T>().Find(id);

        public IEnumerable<T> BuscarTodos() => _db.Set<T>();

        public int Contar(Func<T, bool> expressao) => _db.Set<T>().Where(expressao).Count();

        public IEnumerable<T> Procurar(Func<T, bool> expressao) => _db.Set<T>().Where(expressao);

        protected void Salvar() => _db.SaveChanges();
    }
}
