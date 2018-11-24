using StairEstate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaitEstate.View.Controllers.Plot_Management
{
    public class FacingController : Controller
    {
        private readonly IFacingService _facingService;

        public FacingController()
        {}
        public FacingController( IFacingService facingService)
        {
            _facingService = facingService;
        }
        // GET: Facing
        public ActionResult Index()
        {
            return View();
        }



        //Json


    }
}