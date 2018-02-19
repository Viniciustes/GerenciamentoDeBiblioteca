using GerenciamentoDeBiblioteca.Data.Contexto;
using GerenciamentoDeBiblioteca.Data.Entidades;
using GerenciamentoDeBiblioteca.Data.Interfaces;

namespace GerenciamentoDeBiblioteca.Data.Repositorio
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(DbBibliotecaContexto db) : base(db) { }
    }
}
