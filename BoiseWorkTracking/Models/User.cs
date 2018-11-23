using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoiseWorkTracking.Models
{
    public class User
    {
        public User()
        {
            Logs = new HashSet<Log>();
        }
        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        public string Name { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}