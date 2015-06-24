using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using VETest.Models;
using VETest.Service;

namespace VETest.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }
               
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
			IRegisterService registerService = new RegisterService();

            DateTime time = registerService.GetTimeFromPassword(login.Password);
			
			if (time > DateTime.UtcNow.AddSeconds(-30)) 
			{
                TempData["username"] = login.UserId;
                return RedirectToAction("Welcome");
			}
			
			return RedirectToAction("Register");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel register)
        {
            // call Service
            IRegisterService registerService = new RegisterService();

            var datetime = DateTime.UtcNow;

            TempData["password"] = registerService.GeneratePassword(register.UserId, datetime);

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Welcome()
        {
            return View();
        }
    }
}