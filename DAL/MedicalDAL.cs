using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class MedicalDAL
    {
        private static MedicalDAL _instance;

        public static MedicalDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MedicalDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private MedicalDAL() { }

        #region 

        public DataTable GetListMedical()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListMedical");
        }

        public int GetIDMedicalByName(string medicalname)
        {
            string query = string.Format("EXECUTE dbo.proc_GetIDMedicalByName @MedicalName = N'{0}' ", medicalname);
            return (int)DataProvider.Instance.ExcuteSalar(query);
        }

        #endregion
    }
}
