using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public interface ICurrentStockDetailsService: IService<prod_current_stock_details>
    {
        IQueryable<prod_current_stock_details> search();
    }
}
