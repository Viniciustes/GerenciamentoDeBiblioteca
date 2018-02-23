using GerenciamentoDeBiblioteca.Data.Interfaces;
using GerenciamentoDeBiblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IRepositorioLivro _repositorioLivro;
        private readonly IRepositorioCliente _repositorioCliente;

        public EmprestimoController(IRepositorioLivro repositorioLivro, IRepositorioCliente repositorioCliente)
        {
            _repositorioLivro = repositorioLivro;
            _repositorioCliente = repositorioCliente;
        }

        [Route("Emprestimo")]
        public IActionResult Listar()
        {
            // Leitura de todos os livros disponíveis
            var livrosDisponiveis = _repositorioLivro.ProcurarComAutor(v => v.ClienteId == Guid.Empty);

            if (livrosDisponiveis.Count() == 0)
                return View("Vazio");
            else
                return View(livrosDisponiveis);
        }

        public IActionResult EmprestarLivro(Guid livroId)
        {
            var emprestimoViewModel = new EmprestimoViewModel()
            {
                Livro = _repositorioLivro.BuscarPorId(livroId),
                Clientes = _repositorioCliente.BuscarTodos()
            };
            return View(emprestimoViewModel);
        }

        [HttpPost]
        public IActionResult EmprestarLivro(EmprestimoViewModel emprestimoViewModel)
        {
            var livro = _repositorioLivro.BuscarPorId(emprestimoViewModel.Livro.LivroId);
            var cliente = _repositorioCliente.BuscarPorId(emprestimoViewModel.Livro.ClienteId);

            livro.Cliente = cliente;

            _repositorioLivro.Atualizar(livro);

            return RedirectToAction("Listar");
        }
    }
}