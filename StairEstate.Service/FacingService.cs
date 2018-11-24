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
    public class FacingService : Service<proj_facing>, IFacingService
    {
        public FacingService(IRepository<proj_facing> repository) : base(repository)
        {
        }
    }
}
