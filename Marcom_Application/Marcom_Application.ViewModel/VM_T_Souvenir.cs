using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom_Application.ViewModel
{
    public class VM_T_Souvenir
    {
        //tabel transaksi souvenir
        public int id { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public Nullable<int> t_event_id { get; set; }
        public int request_by { get; set; }
        public Nullable<System.DateTime> request_date { get; set; }
        public Nullable<System.DateTime> request_due_date { get; set; }
        public Nullable<int> approved_by { get; set; }
        public Nullable<System.DateTime> approved_date { get; set; }
        public string received_by { get; set; }
        public Nullable<System.DateTime> received_date { get; set; }
        public Nullable<int> settlement_by { get; set; }
        public Nullable<System.DateTime> settlement_date { get; set; }
        public Nullable<int> settlement_approved_by { get; set; }
        public Nullable<System.DateTime> settlement_approved_date { get; set; }
        public Nullable<int> status { get; set; }
        public string note { get; set; }
        public string reject_reason { get; set; }
        public Nullable<bool> is_delete { get; set; }
        public Nullable<long> created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<long> updated_by { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
    }
}
