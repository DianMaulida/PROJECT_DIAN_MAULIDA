using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom_Application.ViewModel
{
    public class VMTransaksiSouvenirItem
    {
        //souvenir
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int m_unit_id { get; set; }
        public bool is_delete { get; set; }
    

        //transaksi_souvenir_item
        public int idsouveniritem { get; set; }
        public string codesouveniritem { get; set; }
        public int t_souvenir_id { get; set; }
        public int m_souvenir_id { get; set; }
        public Nullable<long> qty { get; set; }
        public Nullable<long> qty_settlement { get; set; }
        public string note { get; set; }
        public Nullable<System.DateTime> due_date { get; set; }
        public string status { get; set; }
        public string request_by { get; set; }
        public Nullable<System.DateTime> request_date { get; set; }
  
    }
}
