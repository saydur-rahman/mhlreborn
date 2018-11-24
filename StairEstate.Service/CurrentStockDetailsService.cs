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
    public class CurrentStockDetailsService : Service<prod_current_stock_details>, ICurrentStockDetailsService
    {
        public CurrentStockDetailsService(IRepository<prod_current_stock_details> repository) : base(repository)
        {
        }

        public IQueryable<prod_current_stock_details> search()
        {
            return _repository.GetAll().AsQueryable();
        }
    }
}
