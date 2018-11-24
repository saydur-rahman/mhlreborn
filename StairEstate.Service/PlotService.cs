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
    public class PlotService : Service<proj_plot>, IPlotService
    {
        public PlotService(IRepository<proj_plot> repository) : base(repository)
        {
        }
    }
}
