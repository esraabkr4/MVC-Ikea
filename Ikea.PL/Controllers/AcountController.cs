using Ikea.DAL.Models.Identity;
using Ikea.PL.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ikea.PL.Controllers
{
    public class AcountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AcountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var User = new ApplicationUser()
            {
                Fname=model.Fname,
                Lname=model.Lname,
                UserName=model.UserName,
                Email=model.Email,
                IsAgree=model.IsAgree,
                Password=model.Password,
                ConfirmPassword=model.ConfirmPassword
            };
            if(User is { }){
                ModelState.AddModelError(nameof(SignUpVM.UserName), "This User Is Exist Before");
                   return View(model);
            }
            var result = await _userManager.CreateAsync(User, model.Password);
            if(result.Succeeded)
                return RedirectToAction(nameof(SignIn));
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
