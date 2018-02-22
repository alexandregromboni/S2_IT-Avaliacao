using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S2Games.Web.Models
{
    public class UsuarioViewModel
    {
        public int Id_Usuario { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("EmailExists", "Account", HttpMethod = "POST", ErrorMessage = "E-mail ja foi cadastrado.")]
        public string Email { get; set; }

        [DisplayName("Nome")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "O Nome deve conter apenas letras e números")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Password is Required")]
        public string Senha { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Senha é obrigatória")]
        public string ConfirmaSenha { get; set; }

        [DisplayName("Confirmar Senha")]
        [Required(ErrorMessage = "Confirmar Senha é obrigatória")]
        [System.Web.Mvc.Compare("Senha ",  ErrorMessage = "As senhas não são iguais")]
        public DateTime Data_Criacao { get; set; }

        [DisplayName("Perfil")]
        [Required(ErrorMessage = "Perfil é obrigatório")]
        public int Perfil { get; set; }

        [DisplayName("Ativo")]
        [Required(ErrorMessage = "Ativo é obrigatório")]
        public bool IsAtivo { get; set; }
    }
}