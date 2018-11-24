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
    public class ProjectTypeService : Service<proj_project_type>, IProjectTypeService
    {
        public ProjectTypeService(IRepository<proj_project_type> repository) : base(repository)
        {
        }
    }
}
