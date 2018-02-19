using System;
using System.Collections.Generic;

namespace GerenciamentoDeBiblioteca.Data.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> BuscarTodos();
        IEnumerable<T> Procurar(Func<T, bool> expressao);
        T BuscarPorId(Guid id);
        void Cadastrar(T entidade);
        void Atualizar(T entidade);
        void Apagar(T entidade);
        int Contar(Func<T, bool> expressao);
    }
}
