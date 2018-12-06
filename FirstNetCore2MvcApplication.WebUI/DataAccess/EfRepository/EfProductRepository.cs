using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCore2MvcApplication.WebUI.Entity;

namespace FirstNetCore2MvcApplication.WebUI.DataAccess.EfRepository
{
    public class EfProductRepository : IProductRepository
    {

        private AppDbContext _context;
        public EfProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAll() => _context.Products;

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
