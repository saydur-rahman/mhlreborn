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
    public class MouzaService : Service<sys_mouza>, IMouzaService
    {
        public MouzaService(IRepository<sys_mouza> repository) : base(repository)
        {
        }
    }
}
