using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kwikemart_API.Models
{
    public class ProductsDto
    {
        public string ProductDescription { get; set; }
        public bool   ProductEnabled { get; set; }
        public string ProductCreationUser { get; set; }
        public int ProductStock { get; set; }
    }
}
