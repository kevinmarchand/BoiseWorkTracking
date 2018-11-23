using BoiseWorkTracking.Data;
using BoiseWorkTracking.Models;
using BoiseWorkTracking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoiseWorkTracking.Controllers
{
    public class HomeController : Controller
    {
        private WorkTrackingContext db = new WorkTrackingContext();

        public ActionResult Index()
        {
            PopulateDepartments();
            PopulateEquipments();
            PopulateUsers();
            return View();
        }

        public ActionResult Configuration()
        {
            PopulateDepartments();
            return View();
        }

        private void PopulateDepartments()
        {
            IEnumerable<DepartmentViewModel> departments = db.Departments.Select(d => new DepartmentViewModel
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name
            });
            ViewData["departments"] = departments;
        }

        private void PopulateEquipments()
        {
            IEnumerable<EquipmentViewModel> equipments = db.Equipments.Select(d => new EquipmentViewModel
            {
                EquipmentID = d.EquipmentID,
                Name = d.Name,
                DepartmentId = -1,
                Department = null
            });
            ViewData["equipments"] = equipments;
        }

        private void PopulateUsers()
        {
            IEnumerable<UserViewModel> users = db.Users.Select(d => new UserViewModel
            {
                UserID = d.UserID,
                Name = d.Name
            });
            ViewData["users"] = users;
        }
    }
}
