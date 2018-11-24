using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Repo
{
    public class LandMasterRepository : Repository<prop_Land_Contribution>, ILandMasterRepository
    {
        public LandMasterRepository(MHLDB imhldb) : base(imhldb)
        {
        }

        public void EditWithChild(prop_Land_Contribution landCon)
        {
            var parent = Context.prop_Land_Contribution
                .Where(lm => lm.Land_Con_id == landCon.Land_Con_id)
                .Include(lm => lm.prop_Land)
                .SingleOrDefault();

            if(parent != null)
            {
                //foreach(var land in landCon.prop_Land)
                //{
                //    if (!landCon.prop_Land.Any(c => c.Land_id == land.Land_id))
                //        Context.prop_Land.Remove(land);
                //}

                foreach(var land in landCon.prop_Land)
                {
                    var exChild = parent.prop_Land
                        .Where(c => c.Land_id == land.Land_id)
                        .SingleOrDefault();

                    if(exChild != null)
                    {
                        Context.Entry(exChild).CurrentValues.SetValues(land);
                    }
                    else
                    {
                        parent.prop_Land.Add(land);
                    }
                }
                Context.Entry(parent).CurrentValues.SetValues(landCon);

                Context.SaveChanges();
            }
        }
    }
}
