using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marcom_Application.Model;
using Marcom_Application.Repo;
using Marcom_Application.ViewModel;

namespace Marcom_Application.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}