using FirstNetCore2MvcApplication.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCore2MvcApplication.WebUI.DataAccess
{
    public interface IBrandRepository
    {
        IQueryable<Brand> GetAll();
    }
}
