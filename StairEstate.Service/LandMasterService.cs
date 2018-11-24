using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class LandMasterService : Service<prop_Land_Contribution>, ILandMasterService
    {
        public LandMasterService(ILandMasterRepository repository) : base(repository)
        {
            _repository = repository;
        }

        private readonly ILandMasterRepository _repository;

        public void EditWithEntity(prop_Land_Contribution model)
        {
            _repository.EditWithChild(model);
        }
    }
}
