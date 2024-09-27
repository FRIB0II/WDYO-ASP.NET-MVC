using System.ComponentModel.DataAnnotations;

namespace WhatDoYouOwn_ASPNET.Models
{
    public class UserModel
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
