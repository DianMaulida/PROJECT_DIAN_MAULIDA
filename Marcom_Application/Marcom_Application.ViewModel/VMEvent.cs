using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom_Application.ViewModel
{
    public class VMEvent
    {
        //company
        public int idcompany { get; set; }
        public string codecompany { get; set; }
        public string namecompany { get; set; }
        //employee
        public int idemployee { get; set; }
        public string employee_number { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Nullable<int> m_company_id { get; set; }
        public string email { get; set; }
        //event
        public int idevent { get; set; }
        public string codeevent { get; set; }
        public string event_name { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string place { get; set; }
        public Nullable<long> budget { get; set; }
        public string request_by { get; set; }
        public System.DateTime request_date { get; set; }
        public Nullable<int> approved_by { get; set; }
        public Nullable<System.DateTime> approved_date { get; set; }
        public Nullable<int> assign_to { get; set; }
        public Nullable<System.DateTime> closed_date { get; set; }
        public string note { get; set; }
        public Nullable<int> status { get; set; }
        public string reject_reason { get; set; }
        public Nullable<bool> is_delete { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }

    }
}
