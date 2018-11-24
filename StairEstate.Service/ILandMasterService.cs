using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public interface ILandMasterService : IService<prop_Land_Contribution>
    {

        void EditWithEntity(prop_Land_Contribution model);
    }
}
