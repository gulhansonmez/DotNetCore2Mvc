using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCore2MvcApplication.WebUI.Entity;

namespace FirstNetCore2MvcApplication.WebUI.DataAccess.EfRepository
{
    public class EfBrandRepository : IBrandRepository
    {
        private AppDbContext _context;
        public EfBrandRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Brand> GetAll()
        {
            return _context.Brands;
        }
    }
}
