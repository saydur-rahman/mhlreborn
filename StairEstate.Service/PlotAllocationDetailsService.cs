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
    public class PlotAllocationDetailsService : Service<proj_plot_allocation_details>, IPlotAllocationDetailsService
    {
        public PlotAllocationDetailsService(IRepository<proj_plot_allocation_details> repository) : base(repository)
        {
        }
    }
}
