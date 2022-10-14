using API.Controllers;
using CommonModel.Auth;
using FakeItEasy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ApiTest
{
    public class AuthControllerTest
    {
        [Fact]
        public async void LoginTest()
        {
            // Arrange
            var fakeEmail = "ngominhdat110115@gmail.com";
            var fakePassword = "Datngo@123";

            var fakeSigninResult = A.Dummy<SignInResult>();

            var signInManager = A.Fake<SignInManager<IdentityUser>>();
            var userManager = A.Fake<UserManager<IdentityUser>>();

            A.CallTo(() => signInManager.PasswordSignInAsync(fakeEmail, fakePassword, false, true))
                .Returns(Task.FromResult(fakeSigninResult));

            var controller = new AuthController(signInManager, userManager);

            // Act
            var dto =  new SigninRequestDto() { Email = fakeEmail, Password = fakePassword };
            var siginResult = await controller.signin(dto);

            // Assert
            Assert.NotNull(siginResult);
        }
    }
}