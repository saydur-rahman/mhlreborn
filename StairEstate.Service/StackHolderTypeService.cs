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
    public class StackHolderTypeService : Service<sales_stack_holder_type>, IStackHolderTypeService
    {
        public StackHolderTypeService(IRepository<sales_stack_holder_type> repository) : base(repository)
        {
        }
    }
}
