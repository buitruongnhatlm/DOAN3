using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerDAL
    {
        private static ManagerDAL _instance;

        public static ManagerDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private ManagerDAL() { }

        public DataTable GetListManager()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListManager");
        }
    }
}
