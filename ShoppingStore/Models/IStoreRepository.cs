using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingStore.Models
{
    public class IStoreRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
