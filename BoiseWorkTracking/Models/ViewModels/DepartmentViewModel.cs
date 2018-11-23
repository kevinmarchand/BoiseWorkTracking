using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoiseWorkTracking.Models.ViewModels
{
    public class DepartmentViewModel
    {
        [ScaffoldColumn(false)]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}