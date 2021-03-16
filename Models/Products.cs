using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.DTO;

namespace TestApplication.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        public string nameproduct { get; set; }
        public int price { get; set; }
        public bool isafood { get; set; }
        public bool isadrink { get; set; }

    }
}
