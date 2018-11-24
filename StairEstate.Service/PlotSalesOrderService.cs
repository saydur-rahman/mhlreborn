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
    public class PlotSalesOrderService : Service<sales_order_plot>, IPlotSalesOrderService
    {
        public PlotSalesOrderService(IRepository<sales_order_plot> repository) : base(repository)
        {
        }
    }
}
