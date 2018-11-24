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
    public class ThanaService : Service<sys_thana>, IThanaService
    {
        public ThanaService(IRepository<sys_thana> repository) : base(repository)
        {
        }
    }
}
