using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommonModel.Auth;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    public class AuthController : _APIController
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> signin(SigninRequestDto signin)
        {
            var result = await signInManager.PasswordSignInAsync(signin.Email, signin.Password, isPersistent: false, lockoutOnFailure: true);
            
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var user = await userManager.FindByNameAsync(signin.Email);
            return Json(new SigninResponseDto
            {
                Email= user.Email,
                Username = user.UserName,
            });
        }

        [HttpPost("signup")]
        public async Task<IActionResult> signup(SignupRequestDto signup)
        {
            var user = new IdentityUser
            {
                //Id = Guid.NewGuid().ToString(),
                UserName = signup.Email,
                Email = signup.Email,
            };

            var createUserResult = await userManager.CreateAsync(user, signup.Password);

            if (! createUserResult.Succeeded)
            {
                return BadRequest(createUserResult.Errors);
            }

            return Ok();
        }
    }
}
