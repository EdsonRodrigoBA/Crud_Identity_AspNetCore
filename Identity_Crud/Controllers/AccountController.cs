using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity_Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Crud.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        private readonly UserManager<AplicationUser> userManager;
        private readonly SignInManager<AplicationUser> signInManager;
        public AccountController(UserManager<AplicationUser> userManager,
            SignInManager<AplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
     
    
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copia os dados do RegisterViewModel para o IdentityUser
                var user = new AplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                // Armazena os dados do usuário na tabela AspNetUsers
                var result = await userManager.CreateAsync(user, model.Password);
                // Se o usuário foi criado com sucesso, faz o login do usuário
                // usando o serviço SignInManager e redireciona para o Método Action Index
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }
                // Se houver erros então inclui no ModelState
                // que será exibido pela tag helper summary na validação
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, String returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                   
                }
                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"O Email {email} já está sendo usado.");
            }
        }
    }
}
