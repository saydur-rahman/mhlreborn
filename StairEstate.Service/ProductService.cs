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
    public class ProductService : Service<prod_product>, IProductService
    {
        public ProductService(IRepository<prod_product> repository) : base(repository)
        {
        }
    }
}
