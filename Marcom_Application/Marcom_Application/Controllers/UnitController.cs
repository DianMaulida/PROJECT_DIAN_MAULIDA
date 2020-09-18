using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marcom_Application.Model;
using Marcom_Application.Repo;
using PagedList;
namespace Marcom_Application.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
        public static string DataKosong;
        public ActionResult Index(string UnitCode, string UnitName, string searchName, string searchCode, DateTime? searchDate, string searchCreatedUnit, int? page)
        {

            List<master_unit> ListUnit = new List<master_unit>();
            ListUnit = UnitRepo.GetAllData();
            ViewBag.name = UnitName;
            ViewBag.UnitCode = new SelectList(ListUnit, "code", "code", UnitCode);
            ViewBag.UnitName = new SelectList(ListUnit, "name", "name", UnitName);
            ViewBag.CurrentFilter1 = searchDate;
            ViewBag.CurrentFilter2 = searchCreatedUnit;
            ViewBag.DataKosong = DataKosong;
            if (!string.IsNullOrEmpty(searchName))
            {
                ListUnit = ListUnit.Where(x => x.name == searchName).ToList();
            }
            if (!string.IsNullOrEmpty(searchCode))
            {
                ListUnit = ListUnit.Where(x => x.code == searchCode).ToList();
            }
            if (searchDate != null)
            {
                ListUnit = ListUnit.Where(x => x.created_date.ToString("dd MMMM yyyy") == searchDate.Value.ToString("dd MMMM yyyy")).ToList();
            }
            if (!string.IsNullOrEmpty(searchCreatedUnit))
            {
                ListUnit = ListUnit.Where(x => x.created_by == searchCreatedUnit).ToList();
            }
            if (ListUnit.Count == 0)
            {
                DataKosong = "Data tidak ditemukan";
            }
            else
            {
                DataKosong = "";
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ListUnit.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(master_unit dataunit)
        {
            string result = UnitRepo.CreateData(dataunit);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            master_unit dataunit = UnitRepo.GetDataById(id);
            ViewBag.name = dataunit.name;
            return View(dataunit);
        }
        [HttpPost]
        public ActionResult UpdateData(master_unit dataunit)
        {
            string result = UnitRepo.UpdateData(dataunit);
            return Json(new { respon = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            string result = UnitRepo.DeleteData(id);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            master_unit dataview = UnitRepo.GetDataById(id);
            return View(dataview);
        }
        public ActionResult GetDataById(int id)
        {
            master_unit data = new master_unit();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_unit.Where(a => a.id == id).FirstOrDefault();
            }

            return Json(new { respon = data }, JsonRequestBehavior.AllowGet);
        }
        //cek name sama 
        public JsonResult CheckName(string name)
        {
            return Json(UnitRepo.GetDataNama(name), JsonRequestBehavior.AllowGet);
        }

    }
}