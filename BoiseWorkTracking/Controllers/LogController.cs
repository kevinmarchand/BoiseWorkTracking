﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using BoiseWorkTracking.Models;
using BoiseWorkTracking.Data;
using BoiseWorkTracking.Models.ViewModels;

namespace BoiseWorkTracking.Controllers
{
    public class LogController : Controller
    {
        private WorkTrackingContext db = new WorkTrackingContext();

        public JsonResult Cascading_Get_Departments()
        {
            var departments = db.Departments.AsQueryable();
            return Json(departments.Select(d => new { DepartmentID = d.DepartmentId, Name = d.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cascading_Get_Users()
        {
            var users = db.Users.AsQueryable();
            return Json(users.Select(u => new { UserID = u.UserID, Name = u.Name }), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Cascading_Get_Equipments(int? department)
        {
            var equipments = db.Equipments.AsQueryable();

            if (department != null)
            {
                equipments = db.Equipments.Where(e => e.DepartmentId == department);
            }

            var result = equipments.Select(e => new { EquipmentID = e.EquipmentID, Name = e.Name });

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Logs_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Log> logs = db.Logs.Include(e => e.Equipment);
            DataSourceResult result = logs.ToDataSourceResult(request, c => new LogViewModel 
            {
                LogID = c.LogID,
                Description = c.Description,
                DepartmentID = c.Equipment.DepartmentId,
                EquipmentID = c.EquipmentID,
                UserID = c.UserID,
                User = c.User
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Logs_Create([DataSourceRequest]DataSourceRequest request, LogViewModel log)
        {
            if (ModelState.IsValid)
            {
                var entity = new Log
                {
                    Description = log.Description,
                    EquipmentID = log.EquipmentID,
                    UserID = log.UserID
                };

                db.Logs.Add(entity);
                db.SaveChanges();
                log.LogID = entity.LogID;
            }

            return Json(new[] { log }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Logs_Update([DataSourceRequest]DataSourceRequest request, LogViewModel log)
        {
            if (ModelState.IsValid)
            {
                var entity = new Log
                {
                    LogID = log.LogID,
                    Description = log.Description,
                    EquipmentID = log.EquipmentID,
                    UserID = log.UserID
                };

                db.Logs.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { log }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Logs_Destroy([DataSourceRequest]DataSourceRequest request, LogViewModel log)
        {
            if (ModelState.IsValid)
            {
                var entity = new Log
                {
                    LogID = log.LogID,
                    Description = log.Description,
                    EquipmentID = log.EquipmentID,
                    UserID = log.UserID
                };

                db.Logs.Attach(entity);
                db.Logs.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { log }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
