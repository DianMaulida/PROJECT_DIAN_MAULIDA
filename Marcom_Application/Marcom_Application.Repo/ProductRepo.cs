using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marcom_Application.Model;


namespace Marcom_Application.Repo
{
    public class ProductRepo
    {
        public static List<master_product> GetAllData()
        {
            List<master_product> ListProduct = new List<master_product>();
            using(db_marcomEntities db = new db_marcomEntities())
            {
                ListProduct = db.master_product.Where(a => a.is_delete == false).ToList();
            }
            return ListProduct;
        }
      
        //codegenerated
        public static string GenerateCode()
        {
            string result = "PR00";
            using (var db = new db_marcomEntities())
            {
                var product = db.master_product
                    .OrderByDescending(o => o.id).FirstOrDefault();

                var lastID = product.id;
                var newCode = lastID + 1;

                if (newCode < 10)
                {
                    result += "0" + newCode;
                }
                else
                {
                    result += newCode; //maks 99
                }
            }
            return result;
        }
        //tambahmasterunit
        public static string CreateData(master_product dataproduct)
        {
            try
            {
                master_product product = new master_product();
                string newCode = GenerateCode();
                using (db_marcomEntities db = new db_marcomEntities())
                {
                    
                    product.code = newCode;
                    product.name = dataproduct.name;
                    product.description = dataproduct.description;
                    product.is_delete = false;
                    product.created_by = "Administrator";
                    product.created_date = System.DateTime.Now;

                    db.master_product.Add(product);
                    db.SaveChanges();
                }
                return "Berhasil"+ newCode;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static master_product GetDataById(int id)
        {
            master_product product = new master_product();
            using(db_marcomEntities db = new db_marcomEntities())
            {
                product = db.master_product.Where(a => a.id == id).FirstOrDefault();
            }
            return product;
        }
        public static string UpdateData(master_product dataproduct)
        {
            try
            {
                master_product product = new master_product();
                using(db_marcomEntities db = new db_marcomEntities())
                {
                    product = db.master_product.Where(a => a.id == dataproduct.id).FirstOrDefault();
                    product.name = dataproduct.name;
                    product.description = dataproduct.description;
                    product.is_delete = false;
                    product.updated_by = "Administrator";
                    product.updated_date = System.DateTime.Now;

                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil";
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static string DeleteData(int id)
        {
            try
            {
                master_product product = new master_product();
                using(db_marcomEntities db = new db_marcomEntities())
                {
                    product = db.master_product.Where(a => a.id == id).FirstOrDefault();
                    product.is_delete = true;

                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil"+ product.code;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static string GetDataNama(string name)
        {
            master_product data = new master_product();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_product.Where(a => a.is_delete == false && a.name == name).FirstOrDefault();
            }
            if (data != null)
            {
                return "ada";
            }
            else
            {
                return "tidak ada";
            }
        }
    }
}
