using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kwikemart_API.Models
{
    public class ProductsDto
    {
        public string ProductId { get; set; }
        public string ProductDescription { get; set; }
        public bool ProductState { get; set; }
    }
}
