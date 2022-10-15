using CommonModel.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using CustomerSite.Interfaces;

namespace CustomerSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(SigninRequestDto model)
        {
            if (ModelState.IsValid)
            {

                var result = await authService.SigninAsync(model.Email, model.Password);

                if (result != null)
                {
                    Request.HttpContext.Session.SetString("Email", result.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterRequestModel model)
        //{
        //	var client = clientFactory.CreateClient();

        //	var jsonInString = JsonConvert.SerializeObject(model);

        //	var response = await client.PostAsync("auth/register", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
        //	var contents = await response.Content.ReadAsStringAsync();
        //	var data = JsonConvert.DeserializeObject<RegisterResponseModel>(contents);

        //	if (data != null && data.StatusCode == System.Net.HttpStatusCode.OK)
        //	{
        //		return RedirectToAction("Index", "Home");
        //	}
        //	else
        //	{
        //		ModelState.AddModelError("", "Failed to register");
        //	}

        //	return View(model);
        //}
    }
}