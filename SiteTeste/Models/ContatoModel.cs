using System;
using System.ComponentModel.DataAnnotations;

namespace SiteTeste.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o Nome do Contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do Contato")]
        [EmailAddress(ErrorMessage ="Email invalido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do Contato")]
        [Phone(ErrorMessage ="O telefone informado nao é valido!")]
        public string Celular { get; set; }

    }
}
