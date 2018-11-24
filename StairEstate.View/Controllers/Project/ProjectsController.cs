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
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Project
{
    [RoutePrefix("project/projects")]
    public class ProjectsController : Controller
    {
        private readonly string url = "/project/projects/index";

        private readonly IProjectService _projectService;
        private readonly IProjectTypeService _projectTypeService;
        private readonly IProjectStatusService _projectStatusService;
        private readonly IBranchService _branchService;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private MHLDB db = new MHLDB();



        public ProjectsController(IProjectService projectService, IProjectTypeService projectTypeService, IProjectStatusService projectStatusService, IBranchService branchService, IEmployeeService employeeService, IUserService userService)
        {
            _projectService = projectService;
            _projectTypeService = projectTypeService;
            _projectStatusService = projectStatusService;
            _branchService = branchService;
            _employeeService = employeeService;
            _userService = userService;
        }

        // GET: Projects
        [Route("Index")]
        public ActionResult Index()
        {

            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            proj_project model = _projectService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.Branchs = _branchService.GetAll();
            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == model.project_branch_id && e.deleted != true);
            ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
            ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");

            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Projects/Create
        public ActionResult Create(int? branchId)
        {
            if (branchId == -1 || branchId == null)
                branchId = _branchService.GetAll().FirstOrDefault().branch_id;

            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
            ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
            ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
            ViewBag.project_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");

            if (_userService.AuthorizedUser(url))
                return View();


            return RedirectToAction("Unauthorised", "Home");


        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(proj_project model, int? branchId, string manager, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (branchId == -1 || branchId == null)
                    branchId = _branchService.GetAll().FirstOrDefault().branch_id;

                model.project_branch_id = (int)branchId;


                var man = _employeeService.GetAll().Where(e => e.emp_code.Contains(manager)).SingleOrDefault();
                if (man != null)
                {
                    model.project_manager_id = man.emp_id;
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Manager Code Not Valid!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
                    ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
                    ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
                    ViewBag.project_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");
                    return View(model);
                }

                string extension = Path.GetExtension(imageFile.FileName);
                if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                {
                    ///ddfdfdfdf
                    ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
                    ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
                    ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
                    ViewBag.project_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");
                    return View(model);
                }

                string fileName = model.project_id + extension;

                model.project_image = "~/File/Project/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/File/Project/"), fileName);

                imageFile.SaveAs(fileName);

                _projectService.Create(model);

                return RedirectToAction("Index");
            }

            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == branchId && e.deleted != true);
            ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
            ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
            ViewBag.project_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");

            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proj_project model = _projectService.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            ViewBag.Branchs = _branchService.GetAll();
            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == model.project_branch_id && e.deleted != true);
            ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
            ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");

            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proj_project model, string manager, string branch, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var br = _branchService.GetAll().Where(b => b.branch_name.Contains(branch)).SingleOrDefault();

                if (br == null)
                {
                    ModelState.AddModelError(String.Empty, "Branch Not Valid!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == br.branch_id && e.deleted != true);
                    ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
                    ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
                    ViewBag.project_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");
                    return View(model);
                }

                model.project_branch_id = br.branch_id;

                var man = _employeeService.GetAll().Where(e => e.emp_code.Contains(manager)).SingleOrDefault();
                if (man != null)
                {
                    model.project_manager_id = man.emp_id;
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Manager Code Not Valid!");
                    ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == br.branch_id && e.deleted != true);
                    ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
                    ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
                    ViewBag.project_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");
                    return View(model);
                }

                if (imageFile != null)
                {
                    string extension = Path.GetExtension(imageFile.FileName);
                    if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                    {
                        ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                        ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == br.branch_id && e.deleted != true);
                        ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
                        ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
                        ViewBag.project_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name");
                        return View(model);
                    }

                    string fileName = model.project_id + extension;

                    model.project_image = "~/File/Project/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/File/Project/"), fileName);

                    FileInfo fi = new FileInfo(fileName);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    imageFile.SaveAs(fileName);
                }



                _projectService.Edit(model);


                return RedirectToAction("Index");
            }
            ViewBag.Branchs = _branchService.GetAll();
            ViewBag.SP = _employeeService.GetAll().Where(e => e.emp_branch_id == model.project_branch_id && e.deleted != true);
            ViewBag.project_status = new SelectList(_projectStatusService.GetAll(), "project_status_id", "project_status");
            ViewBag.project_type_id = new SelectList(_projectTypeService.GetAll(), "project_type_id", "project_type");
            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }


        //Json

        public JsonResult GetProjects(int? id = -1)
        {
            if (id != -1)
            {
                var proj = _projectService.GetAll().Where(p => p.deleted != true && p.project_branch_id == id).Select(
                    p => new
                    {
                        Id = p.id,
                        ProjectId = p.project_id,
                        Initial = p.project_initial,
                        Type = new
                        {
                            Id = p.proj_project_type.project_type_id,
                            Name = p.proj_project_type.project_type
                        },
                        Name = p.project_name,
                        Address = p.project_address,
                        Status = new
                        {
                            Id = p.proj_project_status.project_status_id,
                            Status = p.proj_project_status.project_status
                        },
                        StartDate = String.Format("{0:dd/MM/yyyy}", p.project_start_date),
                        EndDate = String.Format("{0:dd/MM/yyyy}", p.project_end_date),
                        ActualDate = String.Format("{0:dd/MM/yyyy}", p.project_actual_handover_date),
                        Serial = p.project_serial,
                        Manager = new
                        {
                            Id = p.hr_employee.emp_id,
                            Code = p.hr_employee.emp_code,
                            Name = p.hr_employee.emp_name,
                            Email = p.hr_employee.emp_email,
                            Phone = p.hr_employee.emp_phone,
                            Father = p.hr_employee.emp_father_or_husband_name,
                            Mother = p.hr_employee.emp_mother_name,
                            AddressPerma = p.hr_employee.emp_permanent_address,
                            AddressPre = p.hr_employee.emp_present_address,
                            Dob = String.Format("{0:dd/MM/yyyy}", p.hr_employee.emp_dob),
                            BirthPlace = p.hr_employee.emp_birth_place,
                            Image = p.hr_employee.emp_image,
                            EmployeeType = new
                            {
                                Id = p.hr_employee.hr_employee_type.emp_type_id,
                                Name = p.hr_employee.hr_employee_type.emp_type_name
                            },
                            Branch = new
                            {
                                Id = p.hr_employee.sys_branch.branch_id,
                                Name = p.hr_employee.sys_branch.branch_name
                            }
                        }
                    });

                return Json(proj, JsonRequestBehavior.AllowGet);
            }
            var projects = _projectService.GetAll().Where(p => p.deleted != true).Select(
                    p => new
                    {
                        Id = p.id,
                        ProjectId = p.project_id,
                        Initial = p.project_initial,
                        Type = new
                        {
                            Id = p.proj_project_type.project_type_id,
                            Name = p.proj_project_type.project_type
                        },
                        Name = p.project_name,
                        Address = p.project_address,
                        Status = new
                        {
                            Id = p.proj_project_status.project_status_id,
                            Status = p.proj_project_status.project_status
                        },
                        StartDate = String.Format("{0:dd/MM/yyyy}", p.project_start_date),
                        EndDate = String.Format("{0:dd/MM/yyyy}", p.project_end_date),
                        ActualDate = String.Format("{0:dd/MM/yyyy}", p.project_actual_handover_date),
                        Serial = p.project_serial,
                        Manager = new
                        {
                            Id = p.hr_employee.emp_id,
                            Code = p.hr_employee.emp_code,
                            Name = p.hr_employee.emp_name,
                            Email = p.hr_employee.emp_email,
                            Phone = p.hr_employee.emp_phone,
                            Father = p.hr_employee.emp_father_or_husband_name,
                            Mother = p.hr_employee.emp_mother_name,
                            AddressPerma = p.hr_employee.emp_permanent_address,
                            AddressPre = p.hr_employee.emp_present_address,
                            Dob = String.Format("{0:dd/MM/yyyy}", p.hr_employee.emp_dob),
                            BirthPlace = p.hr_employee.emp_birth_place,
                            Image = p.hr_employee.emp_image,
                            EmployeeType = new
                            {
                                Id = p.hr_employee.hr_employee_type.emp_type_id,
                                Name = p.hr_employee.hr_employee_type.emp_type_name
                            },
                            Branch = new
                            {
                                Id = p.hr_employee.sys_branch.branch_id,
                                Name = p.hr_employee.sys_branch.branch_name
                            }
                        }
                    });

            return Json(projects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjId()
        {
            int a = 0;
            string empCode;
            try
            {
                a = _projectService.GetAll().Max(e => e.id);
            }
            catch (Exception e)
            {
                a = 0;
            }

            finally
            {
                empCode = "PRJ-MHL-" + String.Format("{0:yyyy}", DateTime.Now) + "-" + (++a).ToString();
            }
            return Json(empCode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjSerial()
        {
            int a = 0;
            string empCode;
            try
            {
                a = _projectService.GetAll().Max(e => e.id);
            }
            catch (Exception e)
            {
                a = 0;
            }

            string ser = (++a).ToString();

            return Json(ser, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProj(int id)
        {
            try
            {
                var proj = _projectService.GetById(id);
                proj.deleted = true;
                _projectService.Edit(proj);

                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
