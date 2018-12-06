using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCore2MvcApplication.WebUI.Entity;

namespace FirstNetCore2MvcApplication.WebUI.DataAccess.FakeRepository
{
    public class FakeProductRepository : IProductRepository
    {
        private static List<Product> _context = new List<Product>(); 
        public void Add(Product product)
        { 
            product.Id = _context.Count() + 1;
            _context.Add(product);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.AsQueryable();
        }

       
    }
}
