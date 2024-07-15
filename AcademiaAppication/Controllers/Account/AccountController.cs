using Academia.Domain.Entities.Account;
using AcademiaAppication.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AcademiaAppication.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> _signInManager;

        private readonly IUserClaimsPrincipalFactory<Users> _userClaimsPrincipalFactory;

        public UserManager<Users> _userManager;

        public AccountController(SignInManager<Users> signInManager, 
            IUserClaimsPrincipalFactory<Users> userClaimsPrincipalFactory, UserManager<Users>userManager)
        {
            _signInManager = signInManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    //buscamos o usuario pelo nome.
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    //verifica se o usuario é diferente de null e se não esta bloqueado por algum motivo
                    if (user != null && !await _userManager.IsLockedOutAsync(user) ) 
                    {
                        //aqui verificamos se a senha é valida
                        if (await _userManager.CheckPasswordAsync(user, model.Password))
                        {
                            //verifica se o email é diferente de confirmado
                            if (!await _userManager.IsEmailConfirmedAsync(user))
                            {
                                ModelState.AddModelError(string.Empty, "Conta esta em processo de validação");
                                return View();
                            }
                            //aqui resetamos o contador de tentativas de acesso
                            await _userManager.ResetAccessFailedCountAsync(user);
                            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
                            //aqui estsamos fazendo efetivamente o login na aplicação
                            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                                new System.Security.Claims.ClaimsPrincipal(principal));
                            return RedirectToAction("BemVindo", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Senha Inválida");

                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Conta está bloqueada");
                    }

                }


            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        [HttpPost]       
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public  IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var usuario = await _userManager.FindByEmailAsync(model.Email);                    
                    if (usuario != null) 
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                        var resetUrl = Url.Action("ResetPassword", "Account", new { token = token, email = model.Email },
                            Request.Scheme );
                       // System.IO.File.WriteAllText("ResetLinkNewPass", resetUrl);
                        return RedirectToAction(nameof(ResetPassword), new {resetUrl});
                    }

                }

            }
            catch (Exception ex)
            {

                throw  new Exception(ex.Message);
            }
            return View();
        }


        public  IActionResult ResetPassword( string token, string email)
        {
            return View( new ResetPasswordViewModel { Token = token , Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var result = await _userManager.ResetPasswordAsync(user, model.Token , model.Password);
                        if (result.Succeeded) 
                        {
                            foreach (var erro in result.Errors)
                            {
                                ModelState.AddModelError("", erro.Description);
                                
                            }
                            return View();
                        }
                        return View("ConfirmePasswordSucesso");

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro()/* => PartialView("_MenuHomePartialView");*/
        {

           return View(); 
        }
        [HttpPost]
        public async Task< ActionResult> Cadastro(UserViewModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    user = new Users 
                    {
                        Id = Guid.NewGuid().ToString(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.UserName,
                        PasswordHash = model.Password                          
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    var confirmarEmail = string.Empty;
                    if (result.Succeeded) 
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                       System.IO.File.WriteAllText("ConfirmarEmail.txt", confirmarEmail);
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        foreach (var erro in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, erro.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário já existe");
                }


            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }




    }
}
