using StairEstate.Service.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;

namespace StairEstate.Service
{
    public class CurrentStockMasterService : Service<prod_current_stock_master>, ICurrentStockMasterService
    {
        public CurrentStockMasterService(IRepository<prod_current_stock_master> repository) : base(repository)
        {
        }
    }
}
