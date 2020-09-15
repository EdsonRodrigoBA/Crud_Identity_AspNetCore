using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Crud.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
