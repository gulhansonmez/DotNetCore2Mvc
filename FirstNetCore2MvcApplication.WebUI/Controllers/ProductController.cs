using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCore2MvcApplication.WebUI.DataAccess;
using FirstNetCore2MvcApplication.WebUI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstNetCore2MvcApplication.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private IBrandRepository _brandRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProductController(IProductRepository productRepository, IBrandRepository brandRepository, IHostingEnvironment hostingEnvironment )
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(string key)
        {
            var products = _productRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(key))
            {
                products = products.Where(f => f.Name.ToUpper().Contains(key.ToUpper()));
            }

            return View(products);
        }

        public IActionResult Create()
        {
            var model = new ProductCreateViewModel()
            {
                Brands = _brandRepository.GetAll().ToList() 
            };
            return View(model);
        }
        

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel productViewModel)
        {
            if (productViewModel.File.Length > 0)
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, @"images");
                var imagePath = Path.Combine(filePath, productViewModel.File.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    productViewModel.File.CopyToAsync(stream);
                    productViewModel.Product.ImageUrl = Path.Combine(@"images", productViewModel.File.FileName);
                }
            }
            _productRepository.Add(productViewModel.Product);

            return RedirectToAction("Index");
        }
    }
}