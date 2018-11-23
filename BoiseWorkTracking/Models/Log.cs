using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoiseWorkTracking.Models
{
    public class Log
    {
        [ScaffoldColumn(false)]
        public int LogID { get; set; }
        public string Description { get; set; }
        public int EquipmentID { get; set; }
        public Equipment Equipment { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}