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
    public class ProjectService : Service<proj_project>, IProjectService
    {
        public ProjectService(IRepository<proj_project> repository) : base(repository)
        {
        }
    }
}
