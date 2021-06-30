using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class ProjectController : BaseController
    {
        // use dependency injection. See startup.cs to see the data source for repository
        // ProjectDAO repository;
        public IProjectDataService repository { get; set; }

        public ProjectController(IProjectDataService dataService)
        {
            repository = dataService;
            // repository = new ProjectDAO();
        }

        [Authorize]
        public IActionResult Index()
        {
            UsersDAO user = new UsersDAO();
            string userRole = user.GetUserRole(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);

            if (userRole.Equals("Admin"))
            {
                return View("Index", repository.GetAllProjects());
            }
            else if (userRole.Equals("Developer"))
            {
                return View("IndexDev", repository.GetAllProjects());
            }
            return View("404");
        }

        [Authorize]
        public IActionResult ShowDetails(int id)
        {
            // ProjectDAO project = new ProjectDAO();
            // ProjectModel foundProject = project.GetProjectById(id);
            // return View(foundProject);

            dynamic myModel = new ExpandoObject();
            myModel.foundProject = repository.GetProjectById(id);
            myModel.foundData = repository.GetAllWorkingOnProject(id);
            myModel.foundTickets = repository.GetAllTicketsByProject(id);

            UsersDAO user = new UsersDAO();
            string userRole = user.GetUserRole(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);

            if (userRole.Equals("Admin"))
            {
                return View("ShowDetails", myModel);
            }
            else if (userRole.Equals("Developer"))
            {
                return View("ShowDetailsDev", myModel);
            }
            return View("404");

            /*ProjectModel foundProject = repository.GetProjectById(id);
            return View(foundProject);*/
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public IActionResult ProcessCreate(ProjectModel project)
        {
            // save it to the Database
            dynamic myModel = new ExpandoObject();
            int projectId = repository.Insert(project);
            myModel.foundProject = repository.GetProjectById(projectId);
            myModel.foundData = repository.GetAllWorkingOnProject(projectId);
            myModel.foundTickets = repository.GetAllTicketsByProject(projectId);
            return View("ShowDetails", myModel);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            ProjectModel foundProject = repository.GetProjectById(id);
            return View("ShowEdit", foundProject);
        }

        [Authorize]
        public IActionResult ProcessEdit(ProjectModel project)
        {
            repository.Update(project);
            return View("Index", repository.GetAllProjects());
        }

        [Authorize]
        public IActionResult Delete(int Id)
        {
            ProjectModel project = repository.GetProjectById(Id);
            repository.Delete(project);
            return View("Index", repository.GetAllProjects());
        }

    }
}
