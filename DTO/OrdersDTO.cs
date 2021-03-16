using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.DTO
{
    public class OrdersDTO
    {
        public int id_customer { get; set; }
        public string firstname { get; set; }
        public string adress { get; set; }
        public int age { get; set; }
        public string lastname { get; set; }
        public string nameproduct { get; set; }
        public int price { get; set; }
        public bool isafood { get; set; }
        public bool isadrink { get; set; }

        public List <int> id_products { get; set; }
    }
}
