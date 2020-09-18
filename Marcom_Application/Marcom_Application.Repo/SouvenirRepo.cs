using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marcom_Application.Model;
using Marcom_Application.ViewModel;

namespace Marcom_Application.Repo
{
    public class SouvenirRepo
    {
        public static List<master_unit> GetDataJenisUnit()
        {
            List<master_unit> data = new List<master_unit>();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_unit.Where(a => a.is_delete == false).ToList();
            }
            return data;
        }
        public static List<master_souvenir> GetDataCreatedBy()
        {
            List<master_souvenir> data = new List<master_souvenir>();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_souvenir.Where(a => a.is_delete == false).ToList();
            }
            return data;
        }
        public static List<VMSouvenir> GetAllDataUnit()
        {
            List<VMSouvenir> dataAll = new List<VMSouvenir>();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                dataAll = (from so in db.master_souvenir
                           join un in db.master_unit on so.m_unit_id equals un.id
                           where so.is_delete == false
                           select new VMSouvenir
                           {
                            id = so.id,
                            codesouvenir = so.code,
                            namesouvenir = so.name,
                            description = so.description,
                            m_unit_id = so.m_unit_id,
                            name = un.name,
                            created_by = so.created_by,
                            created_date = so.created_date


                           }).ToList();
            }
            return dataAll;
        }
        public static string GenerateCode()
        {
            string result = "SV00";
            using (var db = new db_marcomEntities())
            {
                var souvenir = db.master_souvenir
                    .OrderByDescending(o => o.id).FirstOrDefault();

                var lastID = souvenir.id;
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
        public static string CreateData(VMSouvenir dataSouvenir)
        {
            try
            {
                master_souvenir souvenir = new master_souvenir();
                string newCode = GenerateCode();
                using (db_marcomEntities db = new db_marcomEntities())
                {
                   
                    souvenir.code = newCode;
                    //souvenir.code = dataSouvenir.code;
                    souvenir.name = dataSouvenir.name;
                    souvenir.description = dataSouvenir.description;
                    souvenir.m_unit_id = dataSouvenir.m_unit_id;
                    souvenir.is_delete = false;
                    souvenir.created_by = "Administrator";
                    souvenir.created_date = System.DateTime.Now;

                    db.master_souvenir.Add(souvenir);
                    db.SaveChanges();
                }
                return "Berhasil" + newCode;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static VMSouvenir GetDataById(int id)
        {
            VMSouvenir souvenir = new VMSouvenir();
            using(db_marcomEntities db = new db_marcomEntities())
            {
                souvenir = (from so in db.master_souvenir
                            join un in db.master_unit on so.m_unit_id equals un.id
                            where so.is_delete == false && so.id == id

                            select new VMSouvenir
                            {
                                idsouvenir = so.id,
                                codesouvenir = so.code,
                                namesouvenir = so.name,
                                m_unit_id = so.m_unit_id,
                                id=un.id,
                                name = un.name,
                                description = so.description,
                            }).FirstOrDefault();
            }
            return souvenir;
        }
        //public static string UpdateData(VMSouvenir datasouvenir)
        //{
        //    try
        //    {
        //        master_souvenir souvenir = new master_souvenir();
        //        using (db_marcomEntities1 db = new db_marcomEntities1())
        //        {
        //            souvenir = db.master_souvenir.Where(a => a.id == datasouvenir.id).FirstOrDefault();
        //            souvenir.name = datasouvenir.name;
        //            souvenir.description = datasouvenir.description;
        //            souvenir.is_delete = false;

        //            db.Entry(souvenir).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        return "Berhasil";
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message.ToString();
                
        //    }
        //}

        public static string UpdateData(VMSouvenir dataSouvenir)
        {
            try
            {
                master_souvenir souvenir = new master_souvenir();
                using (db_marcomEntities db = new db_marcomEntities())
                {
                    souvenir = db.master_souvenir.Where(a => a.id == dataSouvenir.id).FirstOrDefault();


                    souvenir.name = dataSouvenir.name;
                    souvenir.description = dataSouvenir.description;
                    souvenir.m_unit_id = dataSouvenir.m_unit_id;
                    souvenir.is_delete = false;
                    souvenir.updated_by = "Administrator";
                    souvenir.updated_date = System.DateTime.Now;
                    db.Entry(souvenir).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public static string DeleteData(VMSouvenir dataSouvenir)
        {
            try
            {
                master_souvenir souvenir = new master_souvenir();
                using(db_marcomEntities db = new db_marcomEntities())
                {
                    souvenir = db.master_souvenir.Where(a => a.id == dataSouvenir.id).FirstOrDefault();
                    souvenir.is_delete = true;

                    db.Entry(souvenir).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil" + souvenir.code;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static string GetDataNama(string name)
        {
            master_souvenir data = new master_souvenir();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_souvenir.Where(a => a.is_delete == false && a.name == name).FirstOrDefault();
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
