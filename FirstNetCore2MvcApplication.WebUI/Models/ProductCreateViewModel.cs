using FirstNetCore2MvcApplication.WebUI.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCore2MvcApplication.WebUI.Models
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
        public List<Brand> Brands { get; set; }
        public IFormFile File { get; set; }
        public string Brand { get; set; }
    }
}
