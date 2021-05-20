using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class FoodDAL
    {
        private static FoodDAL _instance;

        public static FoodDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FoodDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private FoodDAL() { }

        #region 

        public DataTable GetListFood()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListFood");
        }

        public int GetIDFoodByName(string foodname)
        {
            string query = string.Format("EXECUTE dbo.proc_GetIDFoodByName @FoodName = N'{0}' ",foodname);
            return (int)DataProvider.Instance.ExcuteSalar(query);
        }

        #endregion

    }
}
