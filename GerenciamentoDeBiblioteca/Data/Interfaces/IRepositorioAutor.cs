using GerenciamentoDeBiblioteca.Data.Entidades;
using System;
using System.Collections.Generic;

namespace GerenciamentoDeBiblioteca.Data.Interfaces
{
    public interface IRepositorioAutor : IRepositorio<Autor>
    {
        IEnumerable<Autor> BuscarTodosComLivros();
        Autor BuscarComLivrosPorId(Guid id);
    }
}
