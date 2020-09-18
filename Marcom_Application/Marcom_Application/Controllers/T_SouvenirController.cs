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
    public class T_SouvenirController : Controller
    {
        // GET: T_Souvenir
        public static string DataKosong;
        public ActionResult Index(string searchTransactionCode, string searchReceivedby, DateTime? searchReceivedDate , DateTime? searchCreatedDate, int? searchCreatedby, int? page)
        {
            List<transaksi_souvenir> ListT_Souvenir = T_SouvenirRepo.GetAllData();
            ViewBag.CurrentFilter1 = searchTransactionCode;
            ViewBag.CurrentFilter2 = searchReceivedby;
            ViewBag.CurrentFilter3 = searchReceivedDate;
            ViewBag.CurrentFilter4 = searchCreatedDate;
            ViewBag.CurrentFilter5 = searchCreatedby;
            ViewBag.DataKosong = DataKosong;
            if (!string.IsNullOrEmpty(searchTransactionCode))
            {
                ListT_Souvenir = ListT_Souvenir.Where(x => x.code == searchTransactionCode).ToList();
            }
            if (!string.IsNullOrEmpty(searchReceivedby))
            {
                ListT_Souvenir = ListT_Souvenir.Where(x => x.received_by == searchReceivedby).ToList();
            }
            if (searchReceivedDate != null)
            {
                ListT_Souvenir = ListT_Souvenir.Where(x => x.received_date == searchReceivedDate).ToList();
            }
            if (searchCreatedDate != null)
            {
                ListT_Souvenir = ListT_Souvenir.Where(x => x.created_date.Value.ToString("dd MMMM yyyy") == searchCreatedDate.Value.ToString("dd MMMM yyyy")).ToList();
            }
            if (searchCreatedby != null)
            {
                ListT_Souvenir = ListT_Souvenir.Where(x => x.created_by == searchCreatedby).ToList();
            }
            if (ListT_Souvenir.Count == 0)
            {
                DataKosong = "Data tidak ditemukan";
            }
            else
            {
                DataKosong = "";
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ListT_Souvenir.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateData()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateData()
        {
            return View();
        }
        [HttpGet]
        public ActionResult View_T_Souvenir()
        {
            return View();
        }
    }
}