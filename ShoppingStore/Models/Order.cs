using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
    }
}
