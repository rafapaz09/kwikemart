using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kwikemart_API.Models
{
    public class PricesDto
    {
        [Required]
        [Range(0,double.MaxValue,ErrorMessage ="Price should be positive")]
        public double ProductPrice { get; set; }
        [Required]
        public string PriceCreationUser { get; set; }
    }
}
