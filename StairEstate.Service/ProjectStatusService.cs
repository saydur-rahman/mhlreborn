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
    public class ProjectStatusService : Service<proj_project_status>, IProjectStatusService
    {
        public ProjectStatusService(IRepository<proj_project_status> repository) : base(repository)
        {
        }
    }
}
