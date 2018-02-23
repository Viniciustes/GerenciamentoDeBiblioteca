using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeBiblioteca.Data.Entidades
{
    public class Cliente
    {
        [Key]
        public Guid ClienteId { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Nome { get; set; }
    }
}
