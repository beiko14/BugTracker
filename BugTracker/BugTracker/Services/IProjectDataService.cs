using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public interface IProjectDataService
    {
        List<ProjectModel> GetAllProjects();
        List<UserModel> GetAllWorkingOnProject(int id);
        List<TicketModel> GetAllTicketsByProject(int id);
        ProjectModel GetProjectById(int id);
        int Insert(ProjectModel project);
        bool Delete(ProjectModel project);
        int Update(ProjectModel project);
    }
}
