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
    public class UserController : Controller
    {
        private WorkTrackingContext db = new WorkTrackingContext();

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<User> users = db.Users;
            DataSourceResult result = users.ToDataSourceResult(request, c => new UserViewModel 
            {
                UserID = c.UserID,
                Name = c.Name
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Create([DataSourceRequest]DataSourceRequest request, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    Name = user.Name
                };

                db.Users.Add(entity);
                db.SaveChanges();
                user.UserID = entity.UserID;
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    UserID = user.UserID,
                    Name = user.Name
                };

                db.Users.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    UserID = user.UserID,
                    Name = user.Name
                };

                db.Users.Attach(entity);
                db.Users.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
