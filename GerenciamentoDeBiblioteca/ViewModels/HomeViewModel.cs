namespace GerenciamentoDeBiblioteca.ViewModels
{
    public class HomeViewModel
    {
        public int QuantidadeDeClientes { get; set; }
        public int QuantidadeDeAutores { get; set; }
        public int QuantidadeDeLivros { get; set; }
        public int QuantidadeDeEmprestimos { get; set; }
        public int QuantidadeDeLivrosDisponiveis => QuantidadeDeLivros - QuantidadeDeEmprestimos;
    }
}