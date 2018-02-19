using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeBiblioteca.Data.Entidades
{
    public class Cliente
    {
        [Key]
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
    }
}
