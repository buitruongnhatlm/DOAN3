using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
   public class DepartmentDAL
    {
        private static DepartmentDAL _instance;

        public static DepartmentDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DepartmentDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private DepartmentDAL() { }

        public DataTable GetListDepartment()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Department");
        }
    }
}
