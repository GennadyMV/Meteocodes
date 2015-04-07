using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Meteo.Common;
using Codes.Common;

namespace Meteo.Controllers
{
    public class SchemaController : Controller
    {
        //
        // GET: /Schema/Update

        public ActionResult Update()
        {
            try
            {
                ViewBag.Msg = "Схема успешно обновлена";
                Codes.Common.NHibernateHelper.UpdateSchema();
                //Domain.Init();
            }
            catch (Exception ex)
            {
                ViewBag.Msg = String.Format("{0}\n{1}", ex.Message, ex.Source);
            }
            return View();
        }

    }
}
