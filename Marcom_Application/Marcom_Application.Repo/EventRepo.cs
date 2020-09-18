using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marcom_Application.Model;
using Marcom_Application.ViewModel;


namespace Marcom_Application.Repo
{
    public class EventRepo
    {
        public static List<master_employee> GetDataJenisEmployee()
        {
            List<master_employee> data = new List<master_employee>();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                data = db.master_employee.Where(a => a.is_delete == false).ToList();
            }
            return data;
        }
        public static List<transaksi_event> GetAllData()
        {
            List<transaksi_event> ListEvent = new List<transaksi_event>();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                ListEvent = db.transaksi_event.Where(a => a.is_delete == false).ToList();
            }
            return ListEvent;
        }
        //public static List<VMEvent> GetAllDataEvent()
        //{
        //    List<VMEvent> dataAll = new List<VMEvent>();
        //    using (db_marcomEntities db = new db_marcomEntities())
        //    {
        //        dataAll = (from ev in db.transaksi_event
        //                   join em in db.master_employee on ev.request_by equals em.id
        //                   where ev.is_delete == false
        //                   select new VMEvent
        //                   {
        //                       idevent = ev.id,
        //                       codeevent = ev.code,
        //                       request_by = em.id,
        //                       first_name = em.first_name,
        //                       last_name = em.last_name,
        //                       request_date = ev.request_date,
        //                       status = ev.status,
        //                       created_by = ev.created_by,
        //                       created_date = ev.created_date
        //                   }).ToList();
        //    }
        //    return dataAll;
        //}
        public static string GenerateCode()
        {
            string result = "TRWOEV" + System.DateTime.Now.ToString("ddMMyy") + "000";
            using (var db = new db_marcomEntities())
            {
                var tevent = db.transaksi_event
                    .OrderByDescending(o => o.id).FirstOrDefault();

                var lastID = tevent.id;
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
        public static string CreateData(VMEvent dataevent)
        {
            try
            {
                transaksi_event eventt = new transaksi_event();
                string newCode = GenerateCode();
                using (db_marcomEntities db = new db_marcomEntities())
                {

                    eventt.code = newCode;
                    eventt.event_name= dataevent.event_name;
                    eventt.place = dataevent.place;
                    eventt.start_date = dataevent.start_date;
                    eventt.end_date = dataevent.end_date;
                    eventt.budget = dataevent.budget;
                    eventt.is_delete = false;
                    eventt.status = 1;
                    eventt.request_by = "Sahid Triambudhi";
                    eventt.request_date = System.DateTime.Now;
                    eventt.created_by = "Sahid Triambudhi";
                    eventt.created_date = System.DateTime.Now;

                    db.transaksi_event.Add(eventt);
                    db.SaveChanges();
                }
                return "Berhasil" + newCode;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
        public static VMEvent GetDataById(int id)
        {
            VMEvent eventt = new VMEvent();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                eventt = (from ev in db.transaksi_event
                          where ev.is_delete == false && ev.id == id

                            select new VMEvent
                            {
                                idevent = ev.id,
                                codeevent = ev.code,
                                event_name = ev.event_name,
                                place = ev.place,
                                start_date = ev.start_date,
                                end_date = ev.end_date,
                                budget = ev.budget,
                                note = ev.note,
                                assign_to = ev.assign_to,
                                is_delete = false,
                                status = ev.status,
                                request_by = ev.request_by,
                                request_date = ev.request_date,
                                created_by = ev.created_by,
                                created_date = ev.created_date,
                                
                            }).FirstOrDefault();
            }
            return eventt;
        }
        public static string UpdateApproval(VMEvent dataevent)
        {
            try
            {
                transaksi_event eventt = new transaksi_event();
                using (db_marcomEntities db = new db_marcomEntities())
                {
                    eventt = db.transaksi_event.Where(a => a.id == dataevent.idevent).FirstOrDefault();
                    eventt.status = 2;
                    eventt.assign_to = dataevent.assign_to;
                    eventt.approved_by = 1;
                    eventt.approved_date = System.DateTime.Now;
                    db.Entry(eventt).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil" + eventt.code;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public static string UpdateData(VMEvent dataevent)
        {
            try
            {
                transaksi_event eventt = new transaksi_event();
                using (db_marcomEntities db = new db_marcomEntities())
                {
                    eventt = db.transaksi_event.Where(a => a.id == dataevent.idevent).FirstOrDefault();


                    eventt.event_name = dataevent.event_name;
                    eventt.place = dataevent.place;
                    eventt.start_date = dataevent.start_date;
                    eventt.end_date = dataevent.end_date;
                    eventt.note = dataevent.note;
                    eventt.budget = dataevent.budget;
                    eventt.is_delete = false;
                    eventt.updated_by = "Sahid Triambudhi";
                    eventt.updated_date = System.DateTime.Now;
                    db.Entry(eventt).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil" + eventt.code;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public static string UpdateClose(VMEvent dataevent)
        {
            try
            {
                transaksi_event eventt = new transaksi_event();
                using (db_marcomEntities db = new db_marcomEntities())
                {
                    eventt = db.transaksi_event.Where(a => a.id == dataevent.idevent).FirstOrDefault();

                    eventt.status = 3;
                    eventt.closed_date = System.DateTime.Now;

                    db.Entry(eventt).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return "Berhasil" + eventt.code;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public static string DeleteData(VMEvent dataevent)
        {
            try
            {
                transaksi_event eventt = new transaksi_event();
               
                using (db_marcomEntities db = new db_marcomEntities())
                {
                  
                    eventt = db.transaksi_event.Where(a => a.id == dataevent.idevent).FirstOrDefault();
                    eventt.closed_date = System.DateTime.Now;
                 
                    db.Entry(eventt).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                   
                   
                }

                return "Berhasil";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
