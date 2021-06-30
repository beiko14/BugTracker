using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class AccountController : BaseController
    {
        // use dependency injection. See startup.cs to see the data source for repository
        // ProductsDAO repository;
        public IUserDataService repository { get; set; }

        public AccountController(IUserDataService dataService)
        {
            repository = dataService;
            // repository = new ProductsDAO();
        }

        public async Task Login(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be added to the
                // **Allowed Logout URLs** settings for the app.
                RedirectUri = Url.Action("Index", "Home")
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }


        [Authorize]
        public async Task<IActionResult> ProfileAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");

                // if you need to check the Access Token expiration time, use this value
                // provided on the authorization response and stored.
                // do not attempt to inspect/decode the access token
                DateTime accessTokenExpiresAt = DateTime.Parse(
                    await HttpContext.GetTokenAsync("expires_at"),
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind);

                string idToken = await HttpContext.GetTokenAsync("id_token");

                // Now you can use them. For more info on when and how to use the
                // Access Token and ID Token, see https://auth0.com/docs/tokens
            }

            UserModel foundUser = repository.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);

            return View(new UserModel()
            {
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                FirstName = foundUser.FirstName,
                LastName = foundUser.LastName,
                UserId = foundUser.UserId,
                PhoneNumber = foundUser.PhoneNumber,
                BirthDate = foundUser.BirthDate
            });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            UserModel foundUser = repository.GetUserById(id);
            return View("ShowEdit", foundUser);
        }

        [Authorize]
        public IActionResult ProcessEdit(UserModel user)
        {
            repository.Update(user);
            UserModel foundUser = repository.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);

            return View("Profile", new UserModel()
            {
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                FirstName = foundUser.FirstName,
                LastName = foundUser.LastName,
                UserId = foundUser.UserId,
                PhoneNumber = foundUser.PhoneNumber,
                BirthDate = foundUser.BirthDate
            });
        }


    }
}
