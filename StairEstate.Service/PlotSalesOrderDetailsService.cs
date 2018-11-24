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
    public class PlotSalesOrderDetailsService : Service<sales_order_plot_details>, IPlotSalesOrderDetailsService
    {
        public PlotSalesOrderDetailsService(IRepository<sales_order_plot_details> repository) : base(repository)
        {
        }
    }
}
