using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Service.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Service
{
    public class PlotCustomerService : Service<sales_sales_order_customer>, IPlotCustomerService
    {
        public PlotCustomerService(IRepository<sales_sales_order_customer> repository) : base(repository)
        {
        }
    }
}
