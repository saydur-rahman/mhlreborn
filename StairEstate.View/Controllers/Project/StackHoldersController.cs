using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Entity.View_Model;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Project
{
    [RoutePrefix("project/stackholders")]
    public class StackHoldersController : Controller
    {
        private readonly string url = "/project/stackholders/index";

        private readonly IStackHolderService _stackHolderService;
        private readonly IStackHolderTypeService _stackHolderTypeService;
        private readonly ICountryService _countryService;
        private readonly IUserService _userService;

        public StackHoldersController(
            IStackHolderService stackHolderService,
            IStackHolderTypeService stackHolderTypeService,
            ICountryService countryService,
            IUserService userService
            )
        {
            _stackHolderService = stackHolderService;
            _stackHolderTypeService = stackHolderTypeService;
            _countryService = countryService;
            _userService = userService;
        }

        // GET: StackHolders
        [Route("index")]
        public ActionResult Index()
        {
            if (_userService.AuthorizedUser(url))
                return View();


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: StackHolders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            sales_stack_holder model = _stackHolderService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.stack_holder_type_id = new SelectList(_stackHolderTypeService.GetAll(), "stack_holder_type_id", "stack_holder_type", model.stack_holder_type_id);
            ViewBag.stack_holder_country_id = new SelectList(_countryService.GetAll(), "id", "name", model.stack_holder_country_id);

            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: StackHolders/Create
        public ActionResult Create()
        {
            ViewBag.stack_holder_type_id = new SelectList(_stackHolderTypeService.GetAll(), "stack_holder_type_id", "stack_holder_type");
            ViewBag.stack_holder_country_id = new SelectList(_countryService.GetAll(), "id", "name");
            if (_userService.AuthorizedUser(url))
                return View();


            return RedirectToAction("Unauthorised", "Home");
        }

        // POST: StackHolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( sales_stack_holder model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    string extension = Path.GetExtension(imageFile.FileName);

                    if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                    {
                        ModelState.AddModelError(String.Empty, "Not a valid image file!");
                        ViewBag.stack_holder_type_id = new SelectList(_stackHolderTypeService.GetAll(), "stack_holder_type_id", "stack_holder_type", model.stack_holder_type_id);
                        ViewBag.stack_holder_country_id = new SelectList(_countryService.GetAll(), "id", "name", model.stack_holder_country_id);
                        return View(model);
                    }
                    
                    string fileName = model.stack_holder_name + model.stack_holder_nid_no + extension;

                    model.stack_holder_image = "~/File/StackHolder/" + fileName;

                    fileName = Path.Combine(Server.MapPath("~/File/StackHolder/"), fileName);

                    imageFile.SaveAs(fileName);
                }

                _stackHolderService.Create(model);
                return RedirectToAction("Index");
            }

            ViewBag.stack_holder_type_id = new SelectList(_stackHolderTypeService.GetAll(), "stack_holder_type_id", "stack_holder_type", model.stack_holder_type_id);
            ViewBag.stack_holder_country_id = new SelectList(_countryService.GetAll(), "id", "name", model.stack_holder_country_id);
            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: StackHolders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sales_stack_holder model = _stackHolderService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.stack_holder_type_id = new SelectList(_stackHolderTypeService.GetAll(), "stack_holder_type_id", "stack_holder_type", model.stack_holder_type_id);
            ViewBag.stack_holder_country_id = new SelectList(_countryService.GetAll(), "id", "name", model.stack_holder_country_id);
            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        // POST: StackHolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sales_stack_holder model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    string extension = Path.GetExtension(imageFile.FileName);

                    if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                    {
                        ModelState.AddModelError(String.Empty, "Not a valid image file!");
                        ViewBag.stack_holder_type_id = new SelectList(_stackHolderTypeService.GetAll(), "stack_holder_type_id", "stack_holder_type", model.stack_holder_type_id);
                        ViewBag.stack_holder_country_id = new SelectList(_countryService.GetAll(), "id", "name", model.stack_holder_country_id);
                        return View(model);
                    }

                    string fileName = model.stack_holder_name + model.stack_holder_nid_no + extension;

                    model.stack_holder_image = "~/File/StackHolder/" + fileName;

                    fileName = Path.Combine(Server.MapPath("~/File/StackHolder/"), fileName);

                    FileInfo f = new FileInfo(fileName);

                    if (f.Exists)
                    {
                        f.Delete();
                    }

                    imageFile.SaveAs(fileName);
                }

                _stackHolderService.Edit(model);
                return RedirectToAction("Index");
            }

            ViewBag.stack_holder_type_id = new SelectList(_stackHolderTypeService.GetAll(), "stack_holder_type_id", "stack_holder_type", model.stack_holder_type_id);
            ViewBag.stack_holder_country_id = new SelectList(_countryService.GetAll(), "id", "name", model.stack_holder_country_id);
            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }



        ///
        /// JsonResult
        /// 
        public JsonResult GetStackHolders(int? id)
        {
            if (id == null || id == -1)
            {
                var a = _stackHolderService.GetAll().Where(s => s.deleted != true).Select(
                    s => new
                    {
                        Id = s.stack_holder_id,
                        Name = s.stack_holder_name,
                        Phone = s.stack_holder_phone,
                        Email = s.stack_holder_email,
                        Father = s.stack_holder_Father_name,
                        Mother = s.stack_holder_Father_name,
                        ContactPerson = s.stack_holder_contact_person,
                        ContactPersonMobileNo = s.stack_holder_contact_person_number,
                        AddressPer = s.stack_holder_per_address,
                        AddressPre = s.stack_holder_pre_address,
                        NId = s.stack_holder_nid_no,
                        Dob = s.stack_holder_Dob,
                        Country = new
                        {
                            Id = s.sys_country.id,
                            Name = s.sys_country.name,
                            Currency = s.sys_country.currency
                        },
                        StackHolderType = new
                        {
                            Id = s.sales_stack_holder_type.stack_holder_type_id,
                            Name = s.sales_stack_holder_type.stack_holder_type
                        },
                    });

                return Json(a, JsonRequestBehavior.AllowGet);
            }

            var b = _stackHolderService.GetAll().Where(s => s.deleted != true && s.stack_holder_country_id == id).Select(
                s => new
                {
                    Id = s.stack_holder_id,
                    Name = s.stack_holder_name,
                    Phone = s.stack_holder_phone,
                    Email = s.stack_holder_email,
                    Father = s.stack_holder_Father_name,
                    Mother = s.stack_holder_Father_name,
                    ContactPerson = s.stack_holder_contact_person,
                    ContactPersonMobileNo = s.stack_holder_contact_person_number,
                    AddressPer = s.stack_holder_per_address,
                    AddressPre = s.stack_holder_pre_address,
                    NId = s.stack_holder_nid_no,
                    Dob = s.stack_holder_Dob,
                    Country = new
                    {
                        Id = s.sys_country.id,
                        Name = s.sys_country.name,
                        Currency = s.sys_country.currency
                    },
                    StackHolderType = new
                    {
                        Id = s.sales_stack_holder_type.stack_holder_type_id,
                        Name = s.sales_stack_holder_type.stack_holder_type
                    },
                });

            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteStk(int? id)
        {
            try
            {
                var stk = _stackHolderService.GetById(id);
                stk.deleted = true;
                _stackHolderService.Edit(stk);

                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Erro", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
