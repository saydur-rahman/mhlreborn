using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Plot_Management
{
    [RoutePrefix("Plot/Roads")]
    public class RoadsController : Controller
    {
        private readonly IRoadService _roadService;
        private readonly IBlockService _blockService;
        private readonly IProjectService _projectService;
        private readonly IUnitService _unitService;

        public RoadsController(IRoadService roadService, IBlockService blockService, IProjectService projectService,IUnitService unitService)
        {
            _roadService = roadService;
            _blockService = blockService;
            _projectService = projectService;
            _unitService = unitService;
        }

        // GET: Roads
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }


        // GET: Roads/Create
        public ActionResult Create(int? bId)
        {
            ViewBag.BlockName = _blockService.GetById(bId).Block_name;
            
            ViewBag.Unit_id = new SelectList(_unitService.GetAll(), "Unit_id", "Unit_Name");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Road_id,Road_no,Road_size,Unit_id")] proj_road proj_road, int? bId)
        {
            if (ModelState.IsValid)
            {
                proj_road.Block_id = bId;
                _roadService.Create(proj_road);
                return RedirectToAction("Index");
            }
            
            ViewBag.BlockName = _blockService.GetById(bId).Block_name;

            ViewBag.Unit_id = new SelectList(_unitService.GetAll(), "Unit_id", "Unit_Name");
            return View(proj_road);
        }

        // GET: Roads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            proj_road proj_road = _roadService.GetById(id);
            proj_road.Road_no = proj_road.Road_no.Trim();
            proj_road.Road_size = proj_road.Road_size.Trim();
            if (proj_road == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.BranchName = proj_road.proj_block.Block_name;

            ViewBag.Unit_id = new SelectList(_unitService.GetAll(), "Unit_id", "Unit_Name");

            return View(proj_road);
        }

        // POST: Roads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Road_id,Road_no,Road_size,Block_id,Unit_id")] proj_road proj_road)
        {
            if (ModelState.IsValid)
            {
                _roadService.Edit(proj_road);
                return RedirectToAction("Index");
            }
            ViewBag.BranchName = proj_road.proj_block.Block_name;

            ViewBag.Unit_id = new SelectList(_unitService.GetAll(), "Unit_id", "Unit_Name");

            return View(proj_road);
        }





        //JSon 
        public JsonResult GetRoads(int? id)
        {
            var a = _roadService.GetAll().Where(r => r.Block_id == id && r.deleted != true).Select(r => new
            {
                Id = r.Road_id,
                Name = r.Road_no,
                Size = r.Road_size,
                Unit = new
                {
                    Id = r.Unit_id,
                    Name = r.prop_unit.Unit_Name
                }
            });
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRoad(int? id)
        {
            try
            {
                var d = _roadService.GetById(id);
                d.deleted = true;
                _roadService.Edit(d);

                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}
