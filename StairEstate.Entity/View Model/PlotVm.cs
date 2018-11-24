using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Entity.View_Model
{
    public class PlotVm
    {
        public PlotVm()
        {
                
        }
        public PlotVm(proj_plot plot)
        {
            Id = plot.Plot_id;
            DateTime = plot.prod_product.Prod_date;
            BlockId = plot.Block_id;
            RoadId = plot.Road_id;
            FacingId = plot.Facing_id;
            Size = (float)plot.Plot_Size;
            UnitId = plot.Unit_id;
            Desc = plot.Plot_desc;
            Active = plot.prod_product.Prod_active;
            CatId = plot.prod_product.Prod_catagory_id;
            Type = plot.prod_product.Prod_type.Id;
        }


        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public int? BlockId { get; set; }

        public int? RoadId { get; set; }

        public int? FacingId { get; set; }

        public float Size { get; set; }

        public int? UnitId { get; set; }

        public string Desc { get; set; }

        public bool? Active { get; set; }
        
        public int? CatId { get; set; }

        public int? Type { get; set; }
    }
}
