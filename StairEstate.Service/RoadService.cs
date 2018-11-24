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
    public class RoadService : Service<proj_road>, IRoadService
    {
        public RoadService(IRepository<proj_road> repository) : base(repository)
        {
        }
    }
}
