using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.DTO;

namespace TestApplication.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string firstname { get; set; }
        public string adress { get; set; }
        public int age { get; set; }
        public string lastname { get; set; }

        
    }
}
