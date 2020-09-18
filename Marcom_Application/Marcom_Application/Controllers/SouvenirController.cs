using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marcom_Application.Model;
using Marcom_Application.Repo;
using Marcom_Application.ViewModel;
using PagedList;
namespace Marcom_Application.Controllers
{
    public class SouvenirController : Controller
    {
        // GET: Souvenir
        public static string DataKosong;
        public ActionResult Index(string searchCode, string UnitCode, string searchName, string searchUnitCode, DateTime? searchDate, string searchCreatedby, int? page)
        {
            List<VMSouvenir> ListSouvenir = SouvenirRepo.GetAllDataUnit();
            ViewBag.UnitCode = new SelectList(ListSouvenir, "name", "name", UnitCode); 
            ViewBag.CurrentFilter1 = searchCode;
            ViewBag.CurrentFilter2 = searchName;
            ViewBag.CurrentFilter3 = searchDate;
            ViewBag.CurrentFilter4 = searchCreatedby;
            ViewBag.DataKosong = DataKosong;
            if (!string.IsNullOrEmpty(searchName))
            {
                ListSouvenir = ListSouvenir.Where(x => x.namesouvenir == searchName).ToList();
            }
            if (!string.IsNullOrEmpty(searchCode))
            {
                ListSouvenir = ListSouvenir.Where(x => x.codesouvenir == searchCode).ToList();
            }
            if (!string.IsNullOrEmpty(searchUnitCode))
            {
                ListSouvenir = ListSouvenir.Where(x => x.name == searchUnitCode).ToList();
            }
            if (searchDate != null)
            {
                ListSouvenir = ListSouvenir.Where(x => x.created_date.ToString("dd MMMM yyyy") == searchDate.Value.ToString("dd MMMM yyyy")).ToList();
            }
            if (!string.IsNullOrEmpty(searchCreatedby))
            {
                ListSouvenir = ListSouvenir.Where(x => x.created_by == searchCreatedby).ToList();
            }
            if (ListSouvenir.Count == 0)
            {
                DataKosong = "Data tidak ditemukan";
            }
            else
            {
                DataKosong = "";
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ListSouvenir.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListJenisUnit = SouvenirRepo.GetDataJenisUnit();
            return View();

        }
        [HttpPost]
        public ActionResult CreateData(VMSouvenir dataSouvenir)
        {
            string result = SouvenirRepo.CreateData(dataSouvenir);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.ListJenisUnit = SouvenirRepo.GetDataJenisUnit();
            VMSouvenir dataSouvenir = SouvenirRepo.GetDataById(id);
            return View(dataSouvenir);
        }
        [HttpPost]
        public ActionResult UpdateData(VMSouvenir datasouvenir)
        {
            string result = SouvenirRepo.UpdateData(datasouvenir);
            return Json(new { respon = result }, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Delete(VMSouvenir dataSouvenir)
        {
            string result = SouvenirRepo.DeleteData(dataSouvenir);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult View(int id)
        {
            ViewBag.ListJenisUnit = SouvenirRepo.GetDataJenisUnit();
            VMSouvenir dataSouvenir = SouvenirRepo.GetDataById(id);
            return View(dataSouvenir);
        }
        public ActionResult GetDataById(int id)
        {
            ViewBag.ListJenisUnit = SouvenirRepo.GetDataJenisUnit();
            master_souvenir data = new master_souvenir();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_souvenir.Where(a => a.id == id).FirstOrDefault();
            }
            return Json(new { respon = data }, JsonRequestBehavior.AllowGet);

        }
        //cek name sama 
        public JsonResult CheckName(string name)
        {
            return Json(SouvenirRepo.GetDataNama(name), JsonRequestBehavior.AllowGet);
        }
    }
}