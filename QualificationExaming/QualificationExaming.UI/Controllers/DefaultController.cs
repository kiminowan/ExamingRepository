using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualificationExaming.UI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public JsonResult Index()
        {
            var file = System.Web.HttpContext.Current.Request.Files;
            var name = file[0].FileName;
            return Json(file[0].FileName);
        }
    }
}