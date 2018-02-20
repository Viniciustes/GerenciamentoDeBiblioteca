using GerenciamentoDeBiblioteca.Data.Entidades;

namespace GerenciamentoDeBiblioteca.ViewModels
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public int ContadorLivros { get; set; }
    }
}