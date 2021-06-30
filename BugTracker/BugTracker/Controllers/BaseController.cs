using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UsersDAO userDAO = new UsersDAO();
            ViewBag.NutzerRolle = userDAO.GetUserRole(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            base.OnActionExecuting(filterContext);
        }
    }
}
