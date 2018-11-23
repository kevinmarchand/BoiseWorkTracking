using BoiseWorkTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BoiseWorkTracking.Models.ViewModels
{
    public class LogViewModel
    {
        [ScaffoldColumn(false)]
        public int LogID { get; set; }
        public string Description { get; set; }
        [UIHint("GridForeignKey")]
        public int DepartmentID { get; set; }
        [UIHint("GridForeignKey")]
        public int EquipmentID { get; set; }
        //public Equipment Equipment { get; set; }
        [UIHint("GridForeignKey")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}