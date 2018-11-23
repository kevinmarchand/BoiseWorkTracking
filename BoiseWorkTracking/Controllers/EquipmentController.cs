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
    public class EquipmentController : Controller
    {
        private WorkTrackingContext db = new WorkTrackingContext();

        public ActionResult Equipments_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Equipment> equipments = db.Equipments;
            DataSourceResult result = equipments.ToDataSourceResult(request, c => new EquipmentViewModel 
            {
                EquipmentID = c.EquipmentID,
                Name = c.Name,
                DepartmentId = c.DepartmentId,
                Department = c.Department
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Equipments_Create([DataSourceRequest]DataSourceRequest request, EquipmentViewModel equipment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Equipment
                {
                    Name = equipment.Name,
                    DepartmentId = equipment.DepartmentId                   
                };

                db.Equipments.Add(entity);
                db.SaveChanges();
                equipment.EquipmentID = entity.EquipmentID;
            }

            return Json(new[] { equipment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Equipments_Update([DataSourceRequest]DataSourceRequest request, EquipmentViewModel equipment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Equipment
                {
                    EquipmentID = equipment.EquipmentID,
                    Name = equipment.Name,
                    Department = equipment.Department
                };

                db.Equipments.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { equipment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Equipments_Destroy([DataSourceRequest]DataSourceRequest request, EquipmentViewModel equipment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Equipment
                {
                    EquipmentID = equipment.EquipmentID,
                    Name = equipment.Name,
                    Department = equipment.Department
                };

                db.Equipments.Attach(entity);
                db.Equipments.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { equipment }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
