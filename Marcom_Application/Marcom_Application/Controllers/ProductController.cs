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
    public class ProductController : Controller
    {
        // GET: Product
        public static string DataKosong;
        public ActionResult Index(string searchCode, string searchName, string searchDescription, DateTime? searchDate, string searchCreatedby, int? page)
        {
            List<master_product> ListProduct = ProductRepo.GetAllData();
            ViewBag.CurrentFilter1 = searchCode;
            ViewBag.CurrentFilter2 = searchName;
            ViewBag.CurrentFilter3 = searchDescription;
            ViewBag.CurrentFilter4 = searchDate;
            ViewBag.CurrentFilter5 = searchCreatedby;
            ViewBag.DataKosong = DataKosong;
            if (!string.IsNullOrEmpty(searchName))
            {
                ListProduct = ListProduct.Where(x => x.name == searchName).ToList();
            }
            if (!string.IsNullOrEmpty(searchCode))
            {
                ListProduct = ListProduct.Where(x => x.code == searchCode).ToList();
            }
            if (!string.IsNullOrEmpty(searchDescription))
            {
                ListProduct = ListProduct.Where(x => x.description == searchDescription).ToList();
            }
            if (searchDate != null)
            {
                ListProduct = ListProduct.Where(x => x.created_date.ToString("dd MMMM yyyy") == searchDate.Value.ToString("dd MMMM yyyy")).ToList();
            }
            if (!string.IsNullOrEmpty(searchCreatedby))
            {
                ListProduct = ListProduct.Where(x => x.created_by == searchCreatedby).ToList();
            }
            if (ListProduct.Count == 0)
            {
                DataKosong = "Data tidak ditemukan";
            }
            else
            {
                DataKosong = "";
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ListProduct.ToPagedList(pageNumber, pageSize));
            //return View(ListProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateData(master_product dataproduct)
        {
            string result = ProductRepo.CreateData(dataproduct);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
            //return Json(new { respon = result }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            master_product dataproduct = ProductRepo.GetDataById(id);
            return View(dataproduct);
        }
        [HttpPost]
        public ActionResult UpdateData(master_product dataproduct)
        {
            string result = ProductRepo.UpdateData(dataproduct);
            return Json(new { respon = result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Delete(int id)
        {
            string result = ProductRepo.DeleteData(id);
            string[] spearator = { "Berhasil" };
            return Json(new { respon = result.Split(spearator, StringSplitOptions.RemoveEmptyEntries) }, JsonRequestBehavior.AllowGet);
            //return Json(new { respon = result }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            master_product dataview = ProductRepo.GetDataById(id);
            return View(dataview);
        }
        //cek name sama 
        public JsonResult CheckName(string name)
        {
            return Json(ProductRepo.GetDataNama(name), JsonRequestBehavior.AllowGet);
        }

    }
}