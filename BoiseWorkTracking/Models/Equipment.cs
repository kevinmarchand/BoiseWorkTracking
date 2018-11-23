using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoiseWorkTracking.Models
{
    public class Equipment
    {
        public Equipment()
        {
            Logs = new HashSet<Log>();
        }

        [ScaffoldColumn(false)]
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}