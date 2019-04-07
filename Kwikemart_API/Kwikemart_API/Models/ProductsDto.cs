using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Kwikemart_API.Models
{
    public class ProductsDto
    {
        [StringLength(150,ErrorMessage = "Product Description too long")]
        public string ProductDescription { get; set; }
        public bool   ProductEnabled { get; set; }
        public string ProductCreationUser { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price should be positive")]
        public int ProductStock { get; set; }
    }
}
