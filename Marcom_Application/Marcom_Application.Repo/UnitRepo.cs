using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marcom_Application.Model;

namespace Marcom_Application.Repo
{
    public class UnitRepo
    {
        //getalldataa
        public static List<master_unit> GetAllData()
        {
            List<master_unit> ListUnit = new List<master_unit>();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                ListUnit = db.master_unit.Where(a => a.is_delete == false).ToList();   
            }
                return ListUnit;
        }
        
        //code generated
        public static string GenerateCode()
        {
            string result = "UN00";
            using (var db = new db_marcomEntities())
            {
                var unit = db.master_unit
                    .OrderByDescending(o => o.id).FirstOrDefault();

                var lastID = unit.id;
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
        //tambah master unit
        public static string CreateData(master_unit dataunit)
        {
            try
            {
                master_unit unit = new master_unit();
                string newCode = GenerateCode();
                using(db_marcomEntities db = new db_marcomEntities())
                {
                   
                    unit.code = newCode;
                    unit.name = dataunit.name;
                    unit.description = dataunit.description;
                    unit.is_delete = false;
                    unit.created_by = "Administrator";
                    unit.created_date = System.DateTime.Now;

                    db.master_unit.Add(unit);
                    db.SaveChanges();
                }
                return "Berhasil"+ newCode;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static master_unit GetDataById(int id)
        {
            master_unit unit = new master_unit();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                unit = db.master_unit.Where(a => a.id == id).FirstOrDefault();
            }
            return unit;
        }
        //update data
        public static string UpdateData(master_unit dataunit)
        {
            try
            {
                master_unit unit = new master_unit();
                using (db_marcomEntities db = new db_marcomEntities())
                {
                    unit = db.master_unit.Where(a => a.id == dataunit.id).FirstOrDefault();
                    unit.name = dataunit.name;
                    unit.description = dataunit.description;
                    //unit.code = dataunit.code;
                    unit.is_delete = false;
                    unit.updated_by = "Administrator";
                    unit.updated_date = System.DateTime.Now;

                    db.Entry(unit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        //deletedata
        public static string DeleteData(int id)
        {
            try
            {
                master_unit dataunit = new master_unit();
                using(db_marcomEntities db = new db_marcomEntities())
                {
                    dataunit = db.master_unit.Where(a => a.id == id).FirstOrDefault();
                    dataunit.is_delete = true;

                    db.Entry(dataunit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil"+ dataunit.code;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static string GetDataNama(string name)
        {
            master_unit data = new master_unit();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_unit.Where(a => a.is_delete == false && a.name == name).FirstOrDefault();
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
