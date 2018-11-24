using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StairEstate.Entity;
using StairEstate.Entity.View_Model;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Plot_Management
{

    [global::System.Web.Mvc.RoutePrefix("plot/products")]
    public class ProductsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPlotService _plotService;
        private readonly ICatagoryService _catagoryService;
        private readonly IBrandService _brandService;
        private readonly IProjectService _projectService;
        private readonly IFacingService _facingService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        private readonly string url = "/plot/products/index";

        public ProductsController(
            IUserService userService,
            IPlotService plotService, 
            ICatagoryService catagoryService, 
            IBrandService brandService, 
            IProjectService projectService, 
            IFacingService facingService, 
            IProductService productService,
            IProductTypeService productTypeService)
        {
            _userService = userService;
            _plotService = plotService;
            _catagoryService = catagoryService;
            _brandService = brandService;
            _projectService = projectService;
            _facingService = facingService;
            _productService = productService;
            _productTypeService = productTypeService;
        }

        // GET: Products
        [global::System.Web.Mvc.Route("index")]
        public ActionResult Index()
        {
            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }


        public ActionResult Create(int? cId, int? id)
        {
            if (id > 0 || id != null)
            {
                var p = _plotService.GetById(id);
                ViewBag.PlotId = id;
                var cat = p.prod_product.prod_catagory;
                ViewBag.CatName = cat.Catagory_name;
                ViewBag.CatId = cId;
            }
            else
            {
                
                var cat = _catagoryService.GetById(cId);
                ViewBag.CatName = cat.Catagory_name;
                ViewBag.CatId = cId;
            }

            return View();
        }

        public ActionResult Edit(int? id)
        {
            var p = _plotService.GetById(id);
            ViewBag.PlotId = id;
            var cat = p.prod_product.prod_catagory;
            ViewBag.CatName = cat.Catagory_name;
            ViewBag.CatId = p.prod_product.Prod_catagory_id;

            return View();
        }




        //Json

        public ActionResult GetProducts(int? id)
        {
            var a = _plotService.GetAll().Where(p => p.deleted != true && p.prod_product.Prod_catagory_id == id).Select(p =>
                new
                {
                    Id = p.Plot_id,
                    Block = new
                    {
                        Id = p.proj_block.Block_id,
                        Name = p.proj_block.Block_name
                    },
                    Road = new
                    {
                        Id = p.Road_id,
                        No = p.proj_road.Road_no,
                        Size = new
                        {
                            Num = p.proj_road.Road_size,
                            Unit = p.proj_road.prop_unit.Unit_Name
                        }
                    },
                    Facing = new
                    {
                        Id = p.proj_facing.Facing_id,
                        Name = p.proj_facing.Facing_name
                    },
                    Size = new
                    {
                        Num = p.Plot_Size,
                        Unit = p.prop_unit.Unit_Name
                    },
                    Desc = p.Plot_desc,
                    Type = new
                    {
                        Id =p.prod_product.Prod_type.Id,
                        Name = p.prod_product.Prod_type.Name
                    },
                    Active = (bool)p.prod_product.Prod_active ?   "Active": "In Active"
                });

            return Json(a, JsonRequestBehavior.AllowGet);
        }
        
        [Route("{bId}/{rId}/{fId}")]
        public ActionResult GetProducts(int? bId, int? rId, int? fId)
        {
            var a = _plotService.GetAll().Where(p => p.deleted != true && p.Block_id == bId && p.Road_id == rId && p.Facing_id == fId).Select(p =>
                new
                {
                    Id = p.Plot_id,
                    Block = new
                    {
                        Id = p.proj_block.Block_id,
                        Name = p.proj_block.Block_name
                    },
                    Road = new
                    {
                        Id = p.Road_id,
                        No = p.proj_road.Road_no,
                        Size = new
                        {
                            Num = p.proj_road.Road_size,
                            Unit = p.proj_road.prop_unit.Unit_Name
                        }
                    },
                    Facing = new
                    {
                        Id = p.proj_facing.Facing_id,
                        Name = p.proj_facing.Facing_name
                    },
                    Size = new
                    {
                        Num = p.Plot_Size,
                        Unit = p.prop_unit.Unit_Name
                    },
                    Desc = p.Plot_desc,
                    Type = new
                    {
                        Id = p.prod_product.Prod_type.Id,
                        Name = p.prod_product.Prod_type.Name
                    },
                    Active = (bool)p.prod_product.Prod_active ? "Active" : "In Active"
                });

            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBrands(int? id)
        {
            var br = _brandService.GetAll().Where(b => b.prod_company.Country_id == id).Select(b => new
            {
                Id = b.Brand_id,
                Name = b.Brand_name
            });
            return Json(br, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCatagories(int? id)
        {
            var cats = _catagoryService.GetAll().Where(c => c.Brand_id == id).Select(c => new
            {
                Id = c.Catagory_id,
                Name = c.Catagory_name
            });

            return Json(cats, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjects(int id)
        {
            var projs = _projectService.GetAll().Where(p => p.proj_project_type.catagory_id == id && p.deleted != true)
                .Select(p => new
                {
                    Id = p.id,
                    Name = p.project_name
                });

            return Json(projs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFacings()
        {
            var fs = _facingService.GetAll().Select(f => new
            {
                Id = f.Facing_id,
                Name = f.Facing_name
            });

            return Json(fs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlot(int? id)
        {
            var plot = _plotService.GetById(id);
            var p = new PlotVm(plot);
            return Json(p, JsonRequestBehavior.AllowGet);
        }

        public JsonResult postProduct(PlotVm postProduct)
        {
            try
            {
                if (postProduct.Id == 0 || postProduct.Id == null)
                {
                    var product = new prod_product();
                    product.Prod_active = (bool)postProduct.Active;
                    product.Prod_catagory_id = postProduct.CatId;
                    product.Prod_date = DateTime.Now;
                    product.Prod_type_id = postProduct.Type;
                    product.proj_plot.Add(new proj_plot()
                    {
                        Block_id = postProduct.BlockId,
                        Road_id = postProduct.RoadId,
                        Facing_id = postProduct.FacingId,
                        Plot_Size = postProduct.Size,
                        Unit_id = postProduct.UnitId,
                        Plot_desc = postProduct.Desc
                    });

                    _productService.Create(product);
                    return Json("Done", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var p = _plotService.GetById(postProduct.Id);
                    p.Block_id = postProduct.BlockId;
                    p.Road_id = postProduct.RoadId;
                    p.Facing_id = postProduct.FacingId;
                    p.Plot_Size = postProduct.Size;
                    p.Unit_id = postProduct.UnitId;
                    p.Plot_desc = postProduct.Desc;

                    _plotService.Edit(p);

                    var pro = _productService.GetById(p.Prod_id);
                    pro.Prod_type_id = postProduct.Type;

                    _productService.Edit(pro);

                    return Json("Done", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAutoGenProdId(int pId)
        {
            var prod = _plotService.GetAll().Max(p => p.Plot_id);

            var project = _projectService.GetById(pId);

            string code = project.proj_project_type.prod_catagory.Catagory_name + prod.ToString() + String.Format("{0:hhmmss}", DateTime.Now);
            return Json(code, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProdTypes()
        {
            var pt = _productTypeService.GetAll().Select(p => new
            {
                Id = p.Id,
                Name = p.Name
            });

            return Json(pt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProd(int id)
        {
            var p = _plotService.GetById(id);
            p.deleted = true;
            _plotService.Edit(p);

            return Json("Done", JsonRequestBehavior.AllowGet);
        }

    }
}