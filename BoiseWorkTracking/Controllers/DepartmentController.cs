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
    public class DepartmentController : Controller
    {
        private WorkTrackingContext db = new WorkTrackingContext();


        public ActionResult Departments_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Department> departments = db.Departments;
            DataSourceResult result = departments.ToDataSourceResult(request, c => new DepartmentViewModel 
            {
                DepartmentId = c.DepartmentId,
                Name = c.Name
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Departments_Create([DataSourceRequest]DataSourceRequest request, DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var entity = new Department
                {
                    Name = department.Name
                };

                db.Departments.Add(entity);
                db.SaveChanges();
                department.DepartmentId = entity.DepartmentId;
            }

            return Json(new[] { department }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Departments_Update([DataSourceRequest]DataSourceRequest request, DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var entity = new Department
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name
                };

                db.Departments.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { department }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Departments_Destroy([DataSourceRequest]DataSourceRequest request, DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var entity = new Department
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name
                };

                db.Departments.Attach(entity);
                db.Departments.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { department }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
