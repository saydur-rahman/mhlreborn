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
    public class PlotSalesDetailsService : Service<sales_plot_sales_details>, IPlotSalesDetailsService
    {
        public PlotSalesDetailsService(IRepository<sales_plot_sales_details> repository) : base(repository)
        {
        }
    }
}
