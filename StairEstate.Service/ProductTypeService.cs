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
    public class ProductTypeService : Service<Prod_type>, IProductTypeService
    {
        public ProductTypeService(IRepository<Prod_type> repository) : base(repository)
        {
        }
    }
}
