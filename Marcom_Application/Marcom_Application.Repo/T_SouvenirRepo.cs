using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marcom_Application.Model;
using Marcom_Application.ViewModel;
namespace Marcom_Application.Repo
{
    public class T_SouvenirRepo
    {
        public static  List<transaksi_souvenir> GetAllData()
        {
            List<transaksi_souvenir> ListT_Souvenir = new List<transaksi_souvenir>();
            using (db_marcomEntities db = new db_marcomEntities())
            {
                ListT_Souvenir = db.transaksi_souvenir.Where(a => a.is_delete == false).ToList();
            }
            return ListT_Souvenir;
        }
    }
}
