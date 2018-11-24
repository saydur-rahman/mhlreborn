using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class BrandService : Service<prod_brand>, IBrandService
    {
        public BrandService(IRepository<prod_brand> repository) : base(repository)
        {
        }
    }
}
