using GerenciamentoDeBiblioteca.Data.Entidades;
using GerenciamentoDeBiblioteca.Data.Interfaces;
using GerenciamentoDeBiblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IRepositorioLivro _repositorioLivro;
        private readonly IRepositorioCliente _repositorioCliente;

        public ClienteController(IRepositorioCliente repositorioCliente, IRepositorioLivro repositorioLivro)
        {
            _repositorioLivro = repositorioLivro;
            _repositorioCliente = repositorioCliente;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            _repositorioCliente.Cadastrar(cliente);
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(Guid id)
        {
            var cliente = _repositorioCliente.BuscarPorId(id);
            if (cliente == null) return NotFound();

            return View(cliente); 
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            _repositorioCliente.Atualizar(cliente);
            return RedirectToAction("Listar");
        }

        public IActionResult Apagar(Guid id)
        {
            var cliente = _repositorioCliente.BuscarPorId(id);
            if (cliente == null) return NotFound();

            _repositorioCliente.Apagar(cliente);

            return RedirectToAction("Listar");
        }

        [Route("Cliente")]
        public IActionResult Listar()
        {
            var clientes = _repositorioCliente.BuscarTodos();

            if (clientes.Count() == 0) return View("Vazio");

            var clienteViewModel = new List<ClienteViewModel>();
            foreach (var cliente in clientes)
            {
                clienteViewModel.Add(new ClienteViewModel
                {
                    Cliente = cliente,
                    ContadorLivros = _repositorioLivro.Contar(v => v.ClienteId == cliente.ClienteId)
                });
            }
            return View(clienteViewModel);
        }
    }
}