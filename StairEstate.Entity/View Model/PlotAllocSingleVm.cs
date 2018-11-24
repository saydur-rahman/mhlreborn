using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Entity.View_Model
{
    public class PlotAllocSingleVm
    {
        public int ProductId { get; set; }

        public int ProjectId { get; set; }
        public int BlockId { get; set; }
        public int RoadId { get; set; }
        public int FacingId { get; set; }
        public int Saleable { get; set; }
        public string Serial { get; set; }

        public List<int> Muls { get; set; }
    }
}
