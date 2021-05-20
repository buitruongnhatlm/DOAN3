using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class EquipmentDAL
    {
        private static EquipmentDAL _instance;

        public static EquipmentDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EquipmentDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private EquipmentDAL() { }

        #region 

        public DataTable GetListEquipmentSoccer()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListEquipmentSoccer");
        }

        public DataTable GetListEquipmentBadminton()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListEquipmentBadminton");
        }

        public int GetIDEquipmentByName(string equipmentname)
        {
            string query = string.Format("EXECUTE dbo.proc_GetIDEquipmentByName @EquipmentName = N'{0}' ", equipmentname);
            return (int)DataProvider.Instance.ExcuteSalar(query);
        }

        #endregion
    }
}
