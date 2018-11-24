using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Entity.View_Model
{
    public class PlotAllocationMasterVm
    {
        public PlotAllocationMasterVm(proj_plot_allocation_master plotAllocationMaster,IEnumerable<prod_current_stock_details> stockDetails)
        {
            Id = plotAllocationMaster.Id;
            ProjectId = plotAllocationMaster.Project_Id;
            ProductId = plotAllocationMaster.Product_Id;
            ProductQuantity = plotAllocationMaster.Product_Quantity;
            PlotAllocationDetails = new List<PlotAllocationDetailsVm>();
            foreach (var d in plotAllocationMaster.proj_plot_allocation_details)
            {
                foreach (var c in stockDetails)
                {
                    if (d.Id == c.Plot_allocation_Details_Id)
                    {
                        PlotAllocationDetails.Add(new PlotAllocationDetailsVm(d, c));
                    }
                }
            }
        }

        public int Id { get; set; }

        public int? ProjectId { get; set; }

        public int? ProductId { get; set; }

        public int? ProductQuantity { get; set; }

        public ICollection<PlotAllocationDetailsVm> PlotAllocationDetails { get; set; }

        public int Saleable { get; set; }
    }

    public class PlotAllocationDetailsVm
    {
        public PlotAllocationDetailsVm(proj_plot_allocation_details plotAllocationDetails, prod_current_stock_details stockDetails)
        {
            Id = plotAllocationDetails.Id;
            MasterId = plotAllocationDetails.Master_Id;
            Serial = plotAllocationDetails.Serial;
            if (plotAllocationDetails.Saleable == 1)
                Saleable = "Salable";
            else if(plotAllocationDetails.Saleable == 2)
                Saleable = "Non Saleable";
            else if (plotAllocationDetails.Saleable == 3)
                Saleable = "Reserved";
            else if (plotAllocationDetails.Saleable == 4)
                Saleable = "Joint Venture";
            Sold = stockDetails.Sold != null ? true : false ;
        }

        public int Id { get; set; }

        public int? MasterId { get; set; }

        public string Serial { get; set; }

        public string Saleable { get; set; }

        public bool Sold { get; set; }
    }
}
