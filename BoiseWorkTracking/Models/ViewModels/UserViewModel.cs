using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BoiseWorkTracking.Models.ViewModels
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int UserID { get; set; }
        public string Name { get; set; }
    }
}