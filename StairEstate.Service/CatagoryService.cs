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
    public class CatagoryService : Service<prod_catagory>, ICatagoryService
    {
        public CatagoryService(IRepository<prod_catagory> repository) : base(repository)
        {
        }
    }
}
