using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCore2MvcApplication.WebUI.Entity;

namespace FirstNetCore2MvcApplication.WebUI.DataAccess.FakeRepository
{
    public class FakeBrandRepository : IBrandRepository
    {
        private static List<Brand> _context = new List<Brand>()
        {
           new Brand (){BrandId=1,BrandName="BMW"} ,
           new Brand (){BrandId=2,BrandName="Mercedes"} ,
           new Brand (){BrandId=3,BrandName="Honda"} ,
           new Brand (){BrandId=4,BrandName="Volvo"} ,
           new Brand (){BrandId=5,BrandName="Citroen"}
        };
        public IQueryable<Brand> GetAll()
        {
            return _context.AsQueryable();
        }
    }
}
