using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marcom_Application.Model;
using Marcom_Application.ViewModel;
using Marcom_Application.Repo;
using PagedList;
namespace Marcom_Application.Controllers
{
    public class T_EventController : Controller
    {
        // GET: T_Event
        public static string DataKosong;
        public ActionResult Index(int? status, string searchCode, string searchRequestBy, DateTime? searchRequestDate, string searchCreatedby,DateTime? searchCreatedDate, int? page)
        {
            //ViewBag.ListData
            List<transaksi_event> ListEvent = EventRepo.GetAllData();
            ViewBag.CurrentFilter1 = searchCode;
            ViewBag.CurrentFilter2 = searchRequestBy;
            ViewBag.CurrentFilter3 = searchRequestDate;
            ViewBag.CurrentFilter4 = status;
            ViewBag.CurrentFilter5 = searchCreatedby;
            ViewBag.CurrentFilter6 = searchCreatedDate;
            ViewBag.DataKosong = DataKosong;
            if (!string.IsNullOrEmpty(searchCode))
            {
                ListEvent = ListEvent.Where(x => x.code == searchCode).ToList();
            }
            if (!string.IsNullOrEmpty(searchRequestBy))
            {
                ListEvent = ListEvent.Where(x => x.request_by == searchRequestBy).ToList();
            }
            if (searchRequestDate != null)
            {
                ListEvent = ListEvent.Where(x => x.request_date.ToString("dd MMMM yyyy") == searchRequestDate.Value.ToString("dd MMMM yyyy")).ToList();
            }
            if (status != null)
              {
                  ListEvent = ListEvent.Where(x => x.status == status).ToList();
              }
            if (searchCreatedDate != null)
            {
                ListEvent = ListEvent.Where(x => x.created_date.Value.ToString("dd MMMM yyyy") == searchCreatedDate.Value.ToString("dd MMMM yyyy")).ToList();
            }
            if (!string.IsNullOrEmpty(searchCreatedby))
            {
                ListEvent = ListEvent.Where(x => x.created_by == searchCreatedby).ToList();
            }
            if (ListEvent.Count == 0)
            {
                DataKosong = "Data tidak ditemukan";
            }
            else
            {
                DataKosong = "";
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(ListEvent.ToPagedList(pageNumber, pageSize));
           
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateData(VMEvent dataevent)
        {
            string result = EventRepo.CreateData(dataevent);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            VMEvent dataevent = EventRepo.GetDataById(id);
            return View(dataevent);
        }
        [HttpPost]
        public ActionResult UpdateData(VMEvent dataevent)
        {
            string result = EventRepo.UpdateData(dataevent);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Approval(int id)
        {
            VMEvent dataevent = EventRepo.GetDataById(id);
            return View(dataevent);
        }
        [HttpPost]
        public ActionResult UpdateApproval(VMEvent dataevent)
        {
            string result = EventRepo.UpdateApproval(dataevent);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CloseRequest(int id)
        {
            VMEvent dataevent = EventRepo.GetDataById(id);
            return View(dataevent);
        }
        public ActionResult UpdateClose(VMEvent dataevent)
        {
            string result = EventRepo.UpdateClose(dataevent);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult View(int id)
        {
                 
            VMEvent dataevent = EventRepo.GetDataById(id);
            return View(dataevent);
        }
        //public ActionResult GetDataById(long id)
        //{
        //    transaksi_event data = new transaksi_event();
        //    using (db_marcomEntities db = new db_marcomEntities())
        //    {
        //        data = db.transaksi_event.Where(a => a.id == id).FirstOrDefault();
        //    }

        //    return Json(new { respon = data }, JsonRequestBehavior.AllowGet);

        //}
        //tesss
        public ActionResult Delete(VMEvent dataevent)
        {
            string result = EventRepo.DeleteData(dataevent);
            return Json(new { respon = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDataById(long id)
        {
            transaksi_event data = new transaksi_event();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.transaksi_event.Where(a => a.id == id).FirstOrDefault();
            }

            return Json(new { respon = data }, JsonRequestBehavior.AllowGet);

        }
    }
}