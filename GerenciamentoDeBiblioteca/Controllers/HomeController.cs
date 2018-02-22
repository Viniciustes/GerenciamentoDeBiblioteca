using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeBiblioteca.Data.Interfaces;
using GerenciamentoDeBiblioteca.ViewModels;
using System;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioLivro _repositorioLivro;
        private readonly IRepositorioAutor _repositorioAutor;
        private readonly IRepositorioCliente _repositorioCliente;

        public HomeController(IRepositorioLivro repositorioLivro, IRepositorioAutor repositorioAutor, IRepositorioCliente repositorioCliente)
        {
            _repositorioLivro = repositorioLivro;
            _repositorioAutor = repositorioAutor;
            _repositorioCliente = repositorioCliente;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                QuantidadeDeLivros = _repositorioLivro.Contar(x => true),
                QuantidadeDeAutores = _repositorioAutor.Contar(x => true),
                QuantidadeDeClientes = _repositorioCliente.Contar(x => true),
                QuantidadeDeEmprestimos = _repositorioLivro.Contar(x => x.ClienteId != Guid.Empty)
            };
            return View(homeViewModel);
        }
    }
}