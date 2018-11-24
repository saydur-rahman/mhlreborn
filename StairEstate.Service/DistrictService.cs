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
    public class DistrictService : Service<sys_district>, IDistrictService
    {
        public DistrictService(IRepository<sys_district> repository) : base(repository)
        {
        }
    }
}
