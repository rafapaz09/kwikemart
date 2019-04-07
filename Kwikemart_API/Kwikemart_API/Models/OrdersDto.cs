using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kwikemart_API.Models
{
    public class OrdersDto
    {
        [Required]
        public string OrderUser { get; set; }
        [Required]
        public IEnumerable<OrdersDetailsDto> OrderDetails { get; set; }

    }
}
