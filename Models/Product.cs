using System;
using System.Collections.Generic;

namespace GrpcService.Models
{
    public partial class Product
    {

        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }

    }
}
