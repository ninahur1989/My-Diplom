using DishBurger.Data;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.Static;
using DishBurger.Data.ViewModels;
using DishBurger.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DishBurger.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IAuthorizeService _authorizeService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, IAuthorizeService authorizeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _authorizeService = authorizeService;
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        var response = await _authorizeService.GetTokenAsync();
                        var content = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(content);
                        foreach (var item in json)
                        {
                            if (item.Key == "access_token")
                            {
                                JwtToken.SetToken(item.Value.ToString());
                                break;
                            }
                        }
                        return RedirectToAction("Index", "Dishes");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            var response = await _authorizeService.GetTokenAsync();
            var content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            foreach (var item in json)
            {
                if (item.Key == "access_token")
                {
                    JwtToken.SetToken(item.Value.ToString());
                    break;
                }
            }

            return View("RegisterCompleted");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Logout()
        {
            JwtToken.EndSession();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Dishes");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
