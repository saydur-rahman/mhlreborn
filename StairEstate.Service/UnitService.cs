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
    public class UnitService : Service<prop_unit>, IUnitService

    {
        public UnitService(IRepository<prop_unit> repository) : base(repository)
        {
        }
    }
}
