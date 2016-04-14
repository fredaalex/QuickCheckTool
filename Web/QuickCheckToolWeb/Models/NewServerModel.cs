using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickCheckToolWeb.Models
{
    public class NewServerModel
    {
        public String IP { get; set; }
        public String Username { get; set; }
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public double HDPercentualThreshold { get; set; }
        public double MemoryPercentualThreshold { get; set; }
        public double ProcessPercentualThreshold { get; set; }
    }
}