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

namespace StaitEstate.View.Controllers.Project
{
    [RoutePrefix("project/mouzas")]
    public class MouzasController : Controller
    {
        private readonly string url = "/project/mouzas/index";

        private readonly IMouzaService _mouzaService;
        private readonly IThanaService _thanaService;
        private readonly IDistrictService _districtService;
        private readonly IUserService _userService;
        private MHLDB db = new MHLDB();

        public MouzasController(IMouzaService mouzaService, IThanaService thanaService, IDistrictService districtService, IUserService userService)
        {
            _mouzaService = mouzaService;
            _thanaService = thanaService;
            _districtService = districtService;
            _userService = userService;
        }


        // GET: Mouzas
        [Route("index")]
        public ActionResult Index()
        {
            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Mouzas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_mouza sys_mouza = db.sys_mouza.Find(id);
            if (sys_mouza == null)
            {
                return HttpNotFound();
            }

            if (_userService.AuthorizedUser(url))
                return View(sys_mouza);

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Mouzas/Create
        public ActionResult Create()
        {

            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        // POST: Mouzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mouza_id,Mouza_name,Mouza_Thana_id")] sys_mouza sys_mouza)
        {
            if (ModelState.IsValid)
            {
                db.sys_mouza.Add(sys_mouza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            if (_userService.AuthorizedUser(url))
                return View(sys_mouza);

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Mouzas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sys_mouza sys_mouza = db.sys_mouza.Find(id);
            if (sys_mouza == null)
            {
                return HttpNotFound();
            }

            if (_userService.AuthorizedUser(url))
                return View(sys_mouza);

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        // POST: Mouzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sys_mouza model)
        {
            if (ModelState.IsValid)
            {
                _mouzaService.Edit(model);
                return RedirectToAction("Index");
            }

            if (_userService.AuthorizedUser(url))
                return View(model);

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        ///
        /// JsonResult
        ///   
        // /mouzas/getthanas/1
        public JsonResult GetThanas(int id)
        {
            var thanas = _thanaService.GetAll().Where(t => t.Thana_District_id == id)
                .Select(t => new
                {
                    Id = t.Thana_id,
                    Name = t.Thana_name
                });
            return Json(thanas, JsonRequestBehavior.AllowGet);

        }
        // /mouzas/getDistricts/ {1?}
        public JsonResult GetDistricts(int? id)
        {
            if (id == null)
            {
                var dists = _districtService.GetAll().Select(d => new
                {
                    Id = d.District_id,
                    Name = d.District_Name
                });

                return Json(dists, JsonRequestBehavior.AllowGet);
            }

            var ds = _districtService.GetAll().Where(d => d.District_Country_id == id).Select(d => new
            {
                Id = d.District_id,
                Name = d.District_Name
            });

            return Json(ds, JsonRequestBehavior.AllowGet);
        }


        // /mouza/getMouzas/ {1?}
        public JsonResult GetMouzas(int? id)
        {
            if (id == null)
            {
                var ms = _mouzaService.GetAll().Where(m => m.deleted != true).Select(m => new
                {
                    Id = m.Mouza_id,
                    Name = m.Mouza_name,
                    Thana = m.sys_thana.Thana_name,
                    District = m.sys_thana.sys_district.District_Name
                });

                return Json(ms, JsonRequestBehavior.AllowGet);
            }

            var mouzas = _mouzaService.GetAll().Where(m => m.deleted != true && m.Mouza_Thana_id == id).Select(m => new
            {
                Id = m.Mouza_id,
                Name = m.Mouza_name,
                Thana = m.sys_thana.Thana_name,
                District = m.sys_thana.sys_district.District_Name
            });

            return Json(mouzas, JsonRequestBehavior.AllowGet);
        }
        ///    /mouza/GetMouzaDetails/id?
        public JsonResult GetMouzaDetails(int? id)
        {
            var a = _mouzaService.GetAll().Where(m => m.Mouza_id == id).SingleOrDefault();
            var b = new
            {
                Mouza = a.Mouza_name,
                Thana = a.sys_thana.Thana_name,
                District = a.sys_thana.sys_district.District_Name
            };

            return Json(b, JsonRequestBehavior.AllowGet);

        }



        public JsonResult DeleteMouza(int id)
        {
            try
            {
                var mouza = _mouzaService.GetById(id);
                mouza.deleted = true;
                _mouzaService.Edit(mouza);

                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
