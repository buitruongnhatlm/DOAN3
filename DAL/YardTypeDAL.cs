using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class YardTypeDAL
    {
        private static YardTypeDAL _instance;

        public static YardTypeDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new YardTypeDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private YardTypeDAL() { }

        #region 

        public DataTable GetListYardTypeSoccer()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListYardTypeSoccer");
        }

        public DataTable GetListYardTypeBadminton()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListYardTypeBadminton");
        }

        public int GetIDYardTypeByName(string yardtypename)
        {
            string query = string.Format("EXECUTE dbo.proc_GetIDYardTypeByName @YardName = N'{0}' ", yardtypename);
            return (int)DataProvider.Instance.ExcuteSalar(query);
        }

        #endregion
    }
}
