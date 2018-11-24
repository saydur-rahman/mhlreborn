using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Plot_Management
{
    [RoutePrefix("plot/blocks")]
    public class BlocksController : Controller
    {
        private readonly IBlockService _blockService;
        private readonly IProjectService _projectService;


        public BlocksController(IBlockService blockService, IProjectService projectService)
        {
            _blockService = blockService;
            _projectService = projectService;
        }

        // GET: Blocks
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Blocks/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(proj_block model)
        {
            if (model.Block_name != null)
            {
                _blockService.Create(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            proj_block model = _blockService.GetById(id);
            model.Block_name = model.Block_name.Trim();
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Blocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Block_id,Block_name")]
            proj_block model)
        {
            if (ModelState.IsValid)
            {
                _blockService.Edit(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        //JSON

        public JsonResult GetBlocks(int? id)
        {
            var a = _blockService.GetAll().Where(b => b.deleted != true).Select(b => new
            {
                Id = b.Block_id,
                Name = b.Block_name
            });

            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBlock(int? id)
        {
            try
            {
                var b = _blockService.GetById(id);
                b.deleted = true;
                _blockService.Edit(b);

                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }



    }
}
