using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class RoleController : BaseController
    {
        // use dependency injection. See startup.cs to see the data source for repository
        public IUserDataService repository { get; set; }

        public RoleController(IUserDataService dataService)
        {
            repository = dataService;
        }


        [Authorize]
        public IActionResult Index()
        {
            UserModel userModel = new UserModel();
            userModel.EmailList = repository.GetAllDevs();
            userModel.UserModelList = repository.GetAllUsers();

            string userRole = repository.GetUserRole(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);

            if (userRole.Equals("Admin"))
            {
                return View(userModel);
            }
            else if (userRole.Equals("Developer"))
            {
                return View("Denied");
                // only admins are allowed to see this section
            }
            return View("404");
        }

        [Authorize]
        public IActionResult ProcessEditUserRole(UserModel user)
        {
            repository.UpdateRole(user);

            UserModel userModel = new UserModel();
            userModel.EmailList = repository.GetAllDevs();
            userModel.UserModelList = repository.GetAllUsers();
            return View("Test", userModel);
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
            return View("Index", repository.GetAllUsers());
        }

        



    }
}
