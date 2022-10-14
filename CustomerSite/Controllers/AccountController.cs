using CommonModel.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace CustomerSite.Controllers
{
	public class AccountController : Controller
	{
		private IHttpClientFactory clientFactory;

		public AccountController(IHttpClientFactory clientFactory)
		{
			this.clientFactory = clientFactory;
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
				var client = clientFactory.CreateClient();

				var jsonInString = Json(model).ToString();
				
				var response = await client.PostAsync("Auth/signin", new StringContent(jsonInString, Encoding.UTF8, "application/json"));

				if (response.IsSuccessStatusCode)
				{
					return View();
				}
				
				var contents = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<SigninRequestDto>(contents);

				if (data != null)
				{
					Request.HttpContext.Session.SetString("Email", data.Email);
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