using StairEstate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaitEstate.View.Controllers.Sales
{
    [RoutePrefix("sales/plot")]
    public class SalesPlotController : Controller
    {
        private readonly IPlotSalesOrderService _plotSalesOrderService;
        private readonly IPlotSalesOrderDetailsService _plotSalesOrderDetailsService;
        private readonly IPlotSalesDetailsService _plotSalesDetailsService;
        private readonly IPlotCustomerService _plotCustomerService;
        private readonly ICurrentStockDetailsService _currentStockDetailsService;
        private readonly IBranchService _branchService;

        public SalesPlotController(IPlotSalesOrderService plotSalesOrderService,
            IPlotSalesOrderDetailsService plotSalesOrderDetailsService,
            IPlotSalesDetailsService plotSalesDetailsService,
            IPlotCustomerService plotCustomerService,
            ICurrentStockDetailsService currentStockDetailsService,
            IBranchService branchService
            )
        {
            _plotSalesOrderService = plotSalesOrderService;
            _plotSalesOrderDetailsService = plotSalesOrderDetailsService;
            _plotSalesDetailsService = plotSalesDetailsService;
            _plotCustomerService = plotCustomerService;
            _currentStockDetailsService = currentStockDetailsService;
            _branchService = branchService;
        }


        // GET: SalesPlot
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }



        //Json
        [Route("getNextFileNo")]
        public JsonResult GetFileNo()
        {
            var no = 0;
            try
            {
                no = _plotSalesOrderService.GetAll().Max(s => s.Id);
            }
            catch (Exception e)
            {
                no = 0;
            }

            string number = (no + 1).ToString("D4");

            return Json(number, JsonRequestBehavior.AllowGet);
        }


        [Route("getNextInvoiceNo")]
        public JsonResult GetInvoiceNo()
        {
            var LoggedInUser = UserSession.GetUserFromSession().user_id.ToString("D3");

            int no = 0;
            try
            {
                no = _plotSalesOrderService.GetAll().Max(s => s.Id);
            }
            catch (Exception e)
            {
                no = 0;
            }

            string nextNumber = (no + 1).ToString("D3");

            string year = DateTime.Now.Year.ToString();


            string invoiceNumber = LoggedInUser + "-INV-PEL-" + year + "-" + nextNumber;



            return Json(invoiceNumber, JsonRequestBehavior.AllowGet);
        }

        [Route("getNextSalesNo")]
        public JsonResult GetSalesNo()
        {
            var LoggedInUser = UserSession.GetUserFromSession().user_id.ToString("D3");

            int no = 0;
            try
            {
                no = _plotSalesOrderService.GetAll().Max(s => s.Id);
            }
            catch (Exception e)
            {
                no = 0;
            }

            string nextNumber = (no + 1).ToString("D3");

            string year = DateTime.Now.Year.ToString();


            string salesOrderNumber = LoggedInUser + "-SO-PEL-" + year + "-" + nextNumber;



            return Json(salesOrderNumber, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("plotSearch")]
        public JsonResult plotSearch(string block, string road, int? facing, string plotNo, int projectId)
        {
            var query = _currentStockDetailsService.search().Where(c => c.Sold == null && c.proj_plot_allocation_details.Saleable == 1 && c.proj_plot_allocation_details.proj_plot_allocation_master.Project_Id == projectId);

            if (block != null)
            {
                query = query.Where(c => c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_block.Block_name.Contains(block));
            }

            if (road != null)
            {
                query = query.Where(c => c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_road.Road_no.Contains(road));
            }

            if (facing != null)
            {
                query = query.Where(c => c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.Facing_id == facing);
            }
            if (plotNo != null)
            {
                query = query.Where(c => c.proj_plot_allocation_details.Serial.ToString().Contains(plotNo));
            }


            var result = query.Select(c => new
            {
                Id = c.Id,
                Block = new
                {
                    Id = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_block.Block_id,
                    Name = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_block.Block_name.Trim()
                },
                Road = new
                {
                    Id = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_road.Block_id,
                    No = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_road.Road_no.Trim(),
                },
                Facing = new
                {
                    Id = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_facing.Facing_id,
                    Name = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.proj_facing.Facing_name.Trim()
                },
                Size = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.Plot_Size,
                Unit = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.prop_unit.Unit_Name.Trim(),
                PlotNo = c.proj_plot_allocation_details.Serial,
                PlotDescription = c.prod_current_stock_master.proj_plot_allocation_master.proj_plot.Plot_desc.Trim()
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Route("getDept")]
        public JsonResult GetDept()
        {
            var result = _branchService.GetAll().Select(b => new {
                Id = b.branch_id,
                Name = b.branch_name
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}