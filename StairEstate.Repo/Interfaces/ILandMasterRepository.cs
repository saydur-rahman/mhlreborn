using StairEstate.Entity;
using StairEstate.Repo.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Repo.Interfaces
{
    public interface ILandMasterRepository: IRepository<prop_Land_Contribution>
    {
        void EditWithChild(prop_Land_Contribution landCon);
    }
}
