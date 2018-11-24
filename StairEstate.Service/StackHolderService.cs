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
    public class StackHolderService : Service<sales_stack_holder>, IStackHolderService
    {
        public StackHolderService(IRepository<sales_stack_holder> repository) : base(repository)
        {
        }
    }
}
