using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StairEstate.Entity;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Sales
{
    [RoutePrefix("sales/salespersons")]
    public class EmployeesController : Controller
    {
        private readonly string url = "/sales/salespersons/index";

        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeTypeService _employeeTypeService;
        private readonly IBranchService _branchService;
        private readonly IUserService _userService;

        public EmployeesController(IEmployeeService employeeService, 
            IEmployeeTypeService employeeTypeService, 
            IBranchService branchService, 
            IUserService userService)
        {
            _employeeService = employeeService;
            _employeeTypeService = employeeTypeService;
            _branchService = branchService;
            _userService = userService;
        }

        // GET: Employees
        [Route("index")]
        public ActionResult Index()
        {
            var hr_employee = _employeeService.GetAll();
            

            if (_userService.AuthorizedUser(url))
                return View(hr_employee.ToList());


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hr_employee hr_employee = _employeeService.GetById(id);
            if (hr_employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.emp_type_id = new SelectList(_employeeTypeService.GetAll(), "emp_type_id", "emp_type_name", hr_employee.emp_type_id);
            ViewBag.emp_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name", hr_employee.emp_branch_id);
            

            if (_userService.AuthorizedUser(url))
                return View(hr_employee);


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Employees/Create
        [Route("create/{branchId?}")]
        public ActionResult Create(int branchId)
        {
            ViewBag.emp_type_id = new SelectList(_employeeTypeService.GetAll() , "emp_type_id", "emp_type_name");
           

            if (_userService.AuthorizedUser(url))
                return View();


            return RedirectToAction("Unauthorised", "Home");
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create/{branchId?}")]
        public ActionResult Create(hr_employee model, int branchId, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(imageFile.FileName);

                if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                {
                    ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                    ViewBag.emp_type_id = new SelectList(_employeeTypeService.GetAll(), "emp_type_id", "emp_type_name", model.emp_type_id);
                    return View(model);
                }



                string fileName = model.emp_code + extension;
                
                model.emp_image = "~/File/Employee/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/File/Employee/"), fileName);
                
                imageFile.SaveAs(fileName);

                model.emp_branch_id = branchId;




                _employeeService.Create(model);





                return RedirectToAction("Index");
            }

            ViewBag.emp_type_id = new SelectList(_employeeTypeService.GetAll(), "emp_type_id", "emp_type_name", model.emp_type_id);
           

            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        // GET: Employees/Edit/5
        [Route("Edit/{id?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hr_employee hr_employee = _employeeService.GetById(id);
            if (hr_employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_type_id = new SelectList(_employeeTypeService.GetAll(), "emp_type_id", "emp_type_name", hr_employee.emp_type_id);
            ViewBag.emp_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name", hr_employee.emp_branch_id);
            if (_userService.AuthorizedUser(url))
                return View(hr_employee);


            return RedirectToAction("Unauthorised", "Home");
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id?}")]
        public ActionResult Edit(hr_employee model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {

                if (imageFile != null)
                {

                    string extension = Path.GetExtension(imageFile.FileName);

                    if (!(extension.Equals(".jpg") || extension.Equals(".JPG")))
                    {
                        ModelState.AddModelError(string.Empty, "Not an accepted image type!");
                        ViewBag.emp_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name",
                            model.emp_branch_id);
                        ViewBag.emp_type_id = new SelectList(_employeeTypeService.GetAll(), "emp_type_id",
                            "emp_type_name", model.emp_type_id);
                        return View(model);
                    }

                    string fileName = model.emp_code + extension;

                    model.emp_image = "~/File/Employee/" + fileName;

                    fileName = Path.Combine(Server.MapPath("~/File/Employee/"), fileName);
                    FileInfo fi = new FileInfo(fileName);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    imageFile.SaveAs(fileName);
                }

                _employeeService.Edit(model);
                return RedirectToAction("Index");
            }
            ViewBag.emp_type_id = new SelectList(_employeeTypeService.GetAll(), "emp_type_id", "emp_type_name", model.emp_type_id);
            ViewBag.emp_branch_id = new SelectList(_branchService.GetAll(), "branch_id", "branch_name", model.emp_branch_id);
            if (_userService.AuthorizedUser(url))
                return View(model);


            return RedirectToAction("Unauthorised", "Home");
        }

        
        //Json
        public JsonResult GetEmp(int? id = -1)
        {
            if (id != -1)
            {
                var emps = _employeeService.GetAll().Where(e => e.deleted != true && e.emp_branch_id == id).Select(e => new
                {
                    Id = e.emp_id,
                    Code = e.emp_code,
                    Name = e.emp_name,
                    Email = e.emp_email,
                    Phone = e.emp_phone,
                    Father = e.emp_father_or_husband_name,
                    Mother = e.emp_mother_name,
                    AddressPerma = e.emp_permanent_address,
                    AddressPre = e.emp_present_address,
                    Dob = String.Format("{0:dd/MM/yyyy}", e.emp_dob),
                    BirthPlace = e.emp_birth_place,
                    Image = e.emp_image,
                    EmployeeType = new
                    {
                        Id = e.hr_employee_type.emp_type_id,
                        Name = e.hr_employee_type.emp_type_name
                    },
                    Branch = new
                    {
                        Id = e.sys_branch.branch_id,
                        Name = e.sys_branch.branch_name
                    },

                });

                return Json(emps, JsonRequestBehavior.AllowGet);
            }

            var emp = _employeeService.GetAll().Where(e => (e.deleted != true)).Select(e => new
            {
                Id = e.emp_id,
                Code = e.emp_code,
                Name = e.emp_name,
                Email = e.emp_email,
                Phone = e.emp_phone,
                Father = e.emp_father_or_husband_name,
                Mother = e.emp_mother_name,
                AddressPerma = e.emp_permanent_address,
                AddressPre = e.emp_present_address,
                Dob = String.Format("{0:dd/MM/yyyy}", e.emp_dob),
                BirthPlace = e.emp_birth_place,
                Image = e.emp_image,
                EmployeeType = new
                {
                    Id = e.hr_employee_type.emp_type_id,
                    Name = e.hr_employee_type.emp_type_name
                },
                Branch = new
                {
                    Id = e.sys_branch.branch_id,
                    Name = e.sys_branch.branch_name
                },

            });

            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmpById(int id)
        {
            try
            {
                var e = _employeeService.GetById(id);
                if (e.deleted != true || e != null)
                {
                    var emp = new
                    {
                        Id = e.emp_id,
                        Code = e.emp_code,
                        Name = e.emp_name,
                        Email = e.emp_email,
                        Phone = e.emp_phone,
                        Father = e.emp_father_or_husband_name,
                        Mother = e.emp_mother_name,
                        AddressPerma = e.emp_permanent_address,
                        AddressPre = e.emp_present_address,
                        Dob = String.Format("{0:dd/MM/yyyy}", e.emp_dob),
                        BirthPlace = e.emp_birth_place,
                        Image = e.emp_image,
                        EmployeeType = new
                        {
                            Id = e.hr_employee_type.emp_type_id,
                            Name = e.hr_employee_type.emp_type_name
                        },
                        Branch = new
                        {
                            Id = e.sys_branch.branch_id,
                            Name = e.sys_branch.branch_name
                        },

                    };
                    return Json(emp, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    isSuccessful = false
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    isSuccessful = false
                }, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult GetEmpCode()
        {
            int a = 0;
            string empCode;
            try
            {
                a = _employeeService.GetAll().Max(e => e.emp_id);
            }
            catch (Exception e)
            {
                a = 0;
            }

            finally
            {
                empCode = "emp-" + (++a).ToString();
            }
            return Json(empCode, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteEmp(int id)
        {
            try
            {
                var emp = _employeeService.GetById(id);
                emp.deleted = true;
                _employeeService.Edit(emp);

                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
