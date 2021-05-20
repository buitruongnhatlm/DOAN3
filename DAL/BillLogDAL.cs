using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class BillLogDAL
    {
        private static BillLogDAL _instance;

        public static BillLogDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BillLogDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private BillLogDAL() { }

        public DataTable GetLogBill()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetLogBill");
        }

    }
}
