using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StairEstate.Entity;
using StairEstate.Entity.View_Model;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Plot_Management
{
    [RoutePrefix("plot/allocation")]
    public class PlotAllocationController : Controller
    {
        private readonly IPlotAllocationMasterService _plotAllocationMasterService;
        private readonly IPlotAllocationDetailsService _plotAllocationDetailsService;
        private readonly ICurrentStockMasterService _currentStockMasterService;
        private readonly ICurrentStockDetailsService _currentStockDetailsService;
        private readonly IBranchService _branchService;
        private readonly IRoadService _roadService;
        private readonly IBlockService _blockService;
        private readonly IUserService _userService;

        private readonly string url = "/plot/allocation/index";

        public PlotAllocationController(IPlotAllocationMasterService plotAllocationMasterService,
            IPlotAllocationDetailsService plotAllocationDetailsService,
            ICurrentStockMasterService currentStockMasterService,
            ICurrentStockDetailsService currentStockDetailsService,
            IBranchService branchService,
            IRoadService roadService,
            IBlockService blockService,
            IUserService userService)
        {
            _plotAllocationMasterService = plotAllocationMasterService;
            _plotAllocationDetailsService = plotAllocationDetailsService;
            _currentStockMasterService = currentStockMasterService;
            _currentStockDetailsService = currentStockDetailsService;
            _branchService = branchService;
            _roadService = roadService;
            _blockService = blockService;
            _userService = userService;
        }

        // GET: PlotAllocation
        [Route("index")]
        public ActionResult Index()
        {
            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }




        //Json
        [Route("GetPlotAllocationWithDetails/{id}/{pId}")]
        public JsonResult GetPlotAllocationWithDetails(int id, int pId)
        {
            var plotAllocDetails = _plotAllocationMasterService.GetAll().Where(p => p.Product_Id == id && p.Project_Id == pId).SingleOrDefault();
            if (plotAllocDetails != null)
            {
                var currentStock = _currentStockMasterService.GetAll()
                    .Where(c => c.Plot_Master_id == plotAllocDetails.Id).SingleOrDefault();

                var currentStockDetails = _currentStockDetailsService.GetAll()
                    .Where(c => c.Current_Master_Id == currentStock.Id);

                PlotAllocationMasterVm a = new PlotAllocationMasterVm(plotAllocDetails, currentStockDetails);


                return Json(a, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }

        [Route("PostPlotAlloc")]
        public JsonResult PostSingle(PlotAllocSingleVm plot)
        {
            try
            {
                var plotAllocationDetails = _plotAllocationMasterService.GetAll().Where(p => p.Project_Id == plot.ProjectId && p.Product_Id == plot.ProductId).SingleOrDefault();
                prod_current_stock_master plotCurrentStock;

                var blockName = _blockService.GetById(plot.BlockId).Block_name.Trim();
                var road = _roadService.GetById(plot.RoadId);
                var roadName = (road.Road_no.Trim() + "(" + road.Road_size + ")").Trim();
                var serialStr = "#" + blockName + "#" + roadName.Trim();
                if (plotAllocationDetails != null)
                {
                    plotCurrentStock = _currentStockMasterService.GetAll().Where(p => p.Plot_Master_id == plotAllocationDetails.Id).SingleOrDefault();
                    if (plot.Serial != null && NotAvailable(plot.Serial + serialStr, (int)plotAllocationDetails.Product_Id,
                            (int)plotAllocationDetails.Project_Id))
                    {
                        var post = new proj_plot_allocation_details()
                        {
                            Master_Id = plotAllocationDetails.Id,
                            Serial = plot.Serial + serialStr,
                            Saleable = plot.Saleable
                        };

                        _plotAllocationDetailsService.Create(post);

                        var postCurrent = new prod_current_stock_details()
                        {
                            Plot_allocation_Details_Id = post.Id,
                            Current_Master_Id = plotCurrentStock.Id
                        };

                        _currentStockDetailsService.Create(postCurrent);



                        var p = new PlotAllocationDetailsVm(post, postCurrent);

                        return Json(p, JsonRequestBehavior.AllowGet);
                    }
                    else if (plot.Muls.Count != 0)
                    {
                        var pp = new List<PlotAllocationDetailsVm>();

                        foreach (var serial in plot.Muls)
                        {
                            if (NotAvailable(serial.ToString() + serialStr, (int)plotAllocationDetails.Product_Id,
                                (int)plotAllocationDetails.Project_Id))
                            {
                                var post = new proj_plot_allocation_details()
                                {
                                    Master_Id = plotAllocationDetails.Id,
                                    Serial = serial.ToString() + serialStr,
                                    Saleable = plot.Saleable
                                };

                                _plotAllocationDetailsService.Create(post);

                                var postCurrent = new prod_current_stock_details()
                                {
                                    Plot_allocation_Details_Id = post.Id,
                                    Current_Master_Id = plotCurrentStock.Id
                                };

                                _currentStockDetailsService.Create(postCurrent);

                                pp.Add(new PlotAllocationDetailsVm(post, postCurrent));
                            }
                        }

                        return Json(pp, JsonRequestBehavior.AllowGet);
                    }
                }

                else
                {
                    var newPM = new proj_plot_allocation_master()
                    {
                        Product_Id = plot.ProductId,
                        Project_Id = plot.ProjectId,
                    };

                    _plotAllocationMasterService.Create(newPM);

                    var newCSM = new prod_current_stock_master()
                    {
                        Branch_Id = 1,
                        Company_Id = 1,
                        Country_Id = 1,
                        Plot_Master_id = newPM.Id
                    };

                    _currentStockMasterService.Create(newCSM);


                    if (plot.Serial != null && (NotAvailable(plot.Serial + serialStr, (int)newPM.Product_Id, (int)newPM.Project_Id)))
                    {
                        var post = new proj_plot_allocation_details()
                        {
                            Master_Id = newPM.Id,
                            Serial = plot.Serial + serialStr,
                            Saleable = plot.Saleable
                        };

                        _plotAllocationDetailsService.Create(post);

                        var postCurrent = new prod_current_stock_details()
                        {
                            Plot_allocation_Details_Id = post.Id,
                            Current_Master_Id = newCSM.Id
                        };

                        _currentStockDetailsService.Create(postCurrent);

                        var p = new PlotAllocationDetailsVm(post, postCurrent);

                        return Json(p, JsonRequestBehavior.AllowGet);
                    }
                    if (plot.Muls.Count > 0)
                    {
                        var pp = new List<PlotAllocationDetailsVm>();

                        foreach (var serial in plot.Muls)
                        {
                            if (NotAvailable(serial.ToString() + serialStr, (int)newPM.Product_Id,
                                (int)newPM.Project_Id))
                            {
                                var post = new proj_plot_allocation_details()
                                {
                                    Master_Id = newPM.Id,
                                    Serial = serial.ToString() + serialStr,
                                    Saleable = plot.Saleable
                                };


                                _plotAllocationDetailsService.Create(post);

                                var postCurrent = new prod_current_stock_details()
                                {
                                    Plot_allocation_Details_Id = post.Id,
                                    Current_Master_Id = newCSM.Id
                                };

                                _currentStockDetailsService.Create(postCurrent);

                                pp.Add(new PlotAllocationDetailsVm(post, postCurrent));
                            }
                        }

                        return Json(pp, JsonRequestBehavior.AllowGet);
                    }


                    return Json("Done", JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

            return Json("Error", JsonRequestBehavior.AllowGet);
        }

        [Route("delete/{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                var user  = UserSession.GetUserFromSession();
                var a =_userService.GetById(user.user_id).sys_user_type.usr_type_Id;

                if (a == 1)
                {
                    var d = _plotAllocationDetailsService.GetById(id);
                    var dd = _currentStockDetailsService.GetAll().Where(c => c.Plot_allocation_Details_Id == d.Id)
                        .SingleOrDefault();

                    _currentStockDetailsService.Delete(dd);
                    _plotAllocationDetailsService.Delete(d);

                    return Json("Done", JsonRequestBehavior.AllowGet);
                }
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }


        //Private Helper Methods
        private bool NotAvailable(string serial, int productId, int projectId)
        {
            var master = _plotAllocationMasterService.GetAll()
                .Where(p => p.Product_Id == productId && p.Project_Id == projectId).SingleOrDefault();

            var details = _plotAllocationDetailsService.GetAll()
                .Where(p => p.Master_Id == master.Id && p.Serial.Equals(serial)).SingleOrDefault();
            if (details == null)
                return true;

            return false;
        }

    }

}