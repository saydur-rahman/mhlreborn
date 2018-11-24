using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser;
using StairEstate.Entity;
using StairEstate.Entity.View_Model;
using StairEstate.Service;

namespace StaitEstate.View.Controllers.Project
{
    [RoutePrefix("project/LandMasters")]
    public class LandMastersController : Controller
    {
        private readonly IProjectTypeService _projectTypeService;
        private readonly IProjectService _projectService;
        private readonly ILandMasterService _landMasterService;
        private readonly IStackHolderService _stackHolderService;
        private readonly IUnitService _unitService;
        private readonly ILandService _landService;
        private readonly IUserService _userService;

        private readonly string url = "/project/landmasters/index";

        public LandMastersController(
            IProjectTypeService projectTypeService,
            IProjectService projectService,
            ILandMasterService landMasterService,
            IStackHolderService stackHolderService,
            IUnitService unitService,
            ILandService landService,
            IUserService userService
            )
        {
            _projectTypeService = projectTypeService;
            _projectService = projectService;
            _landMasterService = landMasterService;
            _stackHolderService = stackHolderService;
            _unitService = unitService;
            _landService = landService;
            _userService = userService;
        }

        // GET: LandMasters
        [Route("Index")]
        public ActionResult Index()
        {
            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        public ActionResult Create(int? id)
        {
            ViewBag.branchId = id;

            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.landLmId = id;

            if (_userService.AuthorizedUser(url))
                return View();

            else
                return RedirectToAction("Unauthorised", "Home");
        }








        ///Json
        /// 
        /// RESULT
        /// 
        /// 
        /// 
        /// 

        public JsonResult GetLandId()
        {
            int a = 0;
            string LandId;

            try
            {
                a = (int)_landMasterService.GetAll().Max(l => l.Land_Con_id);
            }

            catch (Exception)
            {
                a = 0;
            }

            finally
            {
                LandId = "LND-MHL-" + String.Format("{0:yyyy}", DateTime.Now) + "-" + (++a).ToString();
            }

            return Json(LandId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjectTypes()
        {
            var pts = _projectTypeService.GetAll().Select(pt => new
            {
                Id = pt.project_type_id,
                Name = pt.project_type
            });

            return Json(pts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjects(int? id)
        {
            var proj = _projectService.GetAll().Where(p => p.project_type_id == id && p.deleted != true)
                .Select(p => new
                {
                    Id = p.id,
                    Name = p.project_name
                });

            return Json(proj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLandOwners()
        {
            var owners = _stackHolderService.GetAll().Where(o => o.stack_holder_type_id == 1 && o.deleted != true)
                .Select(o => new
                {
                    Id = o.stack_holder_id,
                    Name = o.stack_holder_name,
                    Phone = o.stack_holder_phone
                });

            return Json(owners, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMedias()
        {
            var medias = _stackHolderService.GetAll().Where(o => o.stack_holder_type_id == 2 && o.deleted != true)
                .Select(o => new
                {
                    Id = o.stack_holder_id,
                    Name = o.stack_holder_name,
                    Phone = o.stack_holder_phone
                });

            return Json(medias, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnits()
        {
            var units = _unitService.GetAll().Select(u => new
            {
                Id = u.Unit_id,
                Name = u.Unit_Name
            });

            return Json(units, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateLandBasicInfo(LandBasicInfoVm landBasicInfo)
        {
            if (!ModelState.IsValid)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

            prop_Land_Contribution landContribution = new prop_Land_Contribution
            {
                Land_Con_id = landBasicInfo.Id,
                Land_Con_Auto_id = landBasicInfo.LandMasterId,
                Land_Con_Date_Created = DateTime.Now,
                Land_Con_Project_id = landBasicInfo.ProjectId,
                Land_Con_branch_Id = landBasicInfo.BranchId
            };



            foreach (var land in landBasicInfo.Lands)
            {
                prop_Land l = new prop_Land();
                l.Land_JL_no = land.JLNo;
                l.Land_Khatian_no = land.KhatianNo;
                l.Land_Dag_no = land.Dag;
                l.Land_Area = land.Area;
                l.Land_Rate_Per_Dag = land.Rate;
                l.Land_Unit_id = land.UnitId;
                l.Land_Mouza_id = land.MouzaId;

                foreach (var owner in land.Owners)
                {
                    prop_Land_LandOwner sh = new prop_Land_LandOwner
                    {
                        Land_Id = owner.LandId,
                        Land_Owner = owner.Id
                    };
                    l.prop_Land_LandOwner.Add(sh);
                }

                foreach (var media in land.Medias)
                {
                    prop_Land_Media lm = new prop_Land_Media
                    {
                        Land_id = media.LandId,
                        Land_media = media.Id
                    };
                    l.prop_Land_Media.Add(lm);
                }
                landContribution.prop_Land.Add(l);
            }

            if (landContribution.Land_Con_id == 0 || landContribution.Land_Con_id == null)
                _landMasterService.Create(landContribution);
            else
                _landMasterService.Edit(landContribution);

            return Json("Done", JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetLandMasters(int? id = -1)
        {
            if (id != -1)
            {

                var a = _landMasterService.GetAll().Where(l => l.Land_Con_branch_Id == id && l.deleted != true)
                    .Select(l => new
                    {
                        Id = l.Land_Con_id,
                        LandId = l.Land_Con_Auto_id,
                        Project = new
                        {
                            Id = l.proj_project.id,
                            Name = l.proj_project.project_name,
                            Type = l.proj_project.proj_project_type.project_type,
                        },
                        LandCount = (int)l.prop_Land.Count,
                        Date = String.Format("{0:dd/MM/yyyy}", l.Land_Con_Date_Created)

                    });
                return Json(a, JsonRequestBehavior.AllowGet);
            }

            var b = _landMasterService.GetAll().Where(l => l.deleted != true)
                .Select(l => new
                {
                    Id = l.Land_Con_id,
                    LandId = l.Land_Con_Auto_id,
                    Project = new
                    {
                        Id = l.proj_project.id,
                        Name = l.proj_project.project_name,
                        Type = l.proj_project.proj_project_type.project_type,
                    },
                    LandCount = (int)l.prop_Land.Count,
                    Date = String.Format("{0:dd/MM/yyyy}", l.Land_Con_Date_Created)
                });

            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLandMaster(int? id)
        {
            var landBasicInfo = new LandBasicInfoVm(_landMasterService.GetById(id));

            foreach (var lm in landBasicInfo.Lands)
            {
                foreach (var owner in lm.Owners)
                {
                    owner.Name = _stackHolderService.GetById(owner.OwnerId).stack_holder_name;
                    owner.Phone = _stackHolderService.GetById(owner.OwnerId).stack_holder_phone;
                }
            }

            foreach (var lm in landBasicInfo.Lands)
            {
                foreach (var media in lm.Medias)
                {
                    media.Name = _stackHolderService.GetById(media.MediaId).stack_holder_name;
                    media.Phone = _stackHolderService.GetById(media.MediaId).stack_holder_phone;
                }
            }

            return Json(landBasicInfo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteLM(int? id)
        {
            try
            {
                var lm = _landMasterService.GetById(id);
                lm.deleted = true;
                _landMasterService.Edit(lm);
                return Json("Done", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }


    }
}