using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class Orders : Controller
    {
        [Key]
        public int id { get; set; }
        public int id_customer { get; set; }
        public int id_orders { get; set; }

    }
}
