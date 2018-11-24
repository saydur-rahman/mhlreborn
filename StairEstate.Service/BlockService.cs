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
    public class BlockService : Service<proj_block>, IBlockService
    {
        public BlockService(IRepository<proj_block> repository) : base(repository)
        {
        }
    }
}
