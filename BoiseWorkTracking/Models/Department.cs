using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoiseWorkTracking.Models
{
    public class Department
    {
        public Department()
        {
            Equipments = new HashSet<Equipment>();
        }

        [ScaffoldColumn(false)]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
    }
}