using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcom_Application.ViewModel
{
    public class VMSouvenir
    {
        //tabel unit
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        //tabel souvenir
        public int idsouvenir { get; set; }
        public string codesouvenir { get; set; }
        public string namesouvenir { get; set; }
        public string description { get; set; }
        public int m_unit_id { get; set; }
        public bool is_delete { get; set; }
        public string created_by { get; set; }
        public System.DateTime created_date { get; set; }
    }
}
