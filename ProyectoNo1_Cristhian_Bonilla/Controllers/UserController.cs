using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoNo1_Cristhian_Bonilla.Interfaces;
using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.Utils;
using ProyectoNo1_Cristhian_Bonilla.ViewModel;
using System.Text.RegularExpressions;

namespace ProyectoNo1_Cristhian_Bonilla.Controllers
{

    public class UserController : Controller
    {

        private readonly IUsersService _userService;

        string regexPattern = @"^(?=.*[!@#$%^&*(),.?\"":{}|<>-_;+])(?=.*\d).{8,}$";


        public UserController(IUsersService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UsersView user)
        {
            try
            {
                var login = await _userService.GetUser(user.Email, user.Password, HttpContext);
                if (login != null)
                {
                    //await _emailSender.SendEmailLogin("Inicio de sesión", login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Message"] = "Usuario o contraseña incorrectos";
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "Usuario o contraseña incorrectos." + ex.InnerException?.Message;
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        public async Task<IActionResult> AddUser(UsersView user)
        {
            HashData hashData = new HashData();
            try
            {
             
                if (user.Password != user.PasswordCheck)
                {
                    ViewData["Message"] = "Las contraseñas no coinciden";
                    return View(user);
                }
                else if (!Regex.IsMatch(user.Password, regexPattern))
                {
                    ViewData["Message"] = "La contraseña debe tener al menos 8 caracteres, un carácter especial y un número";
                    return View(user);
                }
                else
                {
                    //guarda el usuario
                    Users userToSave = new Users
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        Password = hashData.HashPassword(user.Password),
                        IsAdmin = user.IsAdmin
                    };
                    await _userService.Register(userToSave);
                    if (userToSave == null)
                    {
                        ViewData["Message"] = "No se pudo guardar el usuario";
                        return View(user);
                    }
                    return RedirectToAction("LogIn", "User");
                }

            }
            catch (Exception ex)
            {

                ViewData["Message"] = ex.InnerException?.Message;
                return View(user);
            }

        }
        public async Task<IActionResult> LogOut()
        {
            // Clear all session data
            HttpContext.Session.Clear();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the Login view
            return RedirectToAction("LogIn");
        }
    }
}
