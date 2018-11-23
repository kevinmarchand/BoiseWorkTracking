using BoiseWorkTracking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoiseWorkTracking.Models.ViewModels
{
    public class EquipmentViewModel
    {
        [ScaffoldColumn(false)]
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        [UIHint("GridForeignKey")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}