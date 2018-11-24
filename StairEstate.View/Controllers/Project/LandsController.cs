using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaitEstate.View.Controllers.Project
{
    [RoutePrefix("project/lands")]
    public class LandsController : Controller
    {
        // GET: Lands
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}