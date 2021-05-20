using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
   public class AccountTypeDAL
    {
        private static AccountTypeDAL _instance;

        public static AccountTypeDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountTypeDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private AccountTypeDAL() { }

        public DataTable GetListAccountType()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListAccountType");
        }

        public List<AccountTypeDTO> GetListAccountTypeToCombobox()
        {
            List<AccountTypeDTO> _list = new List<AccountTypeDTO>();

            string _Query = "EXECUTE dbo.proc_GetListAccountType";

            DataTable _Table = DataProvider.Instance.ExcuteQuery(_Query);

            foreach (DataRow item in _Table.Rows)
            {
                AccountTypeDTO _account = new AccountTypeDTO(item);
                _list.Add(_account);
            }

            return _list;
        }

        /// <summary>
        /// Thêm loại tài khoản
        /// </summary>
        public bool InsertAccountType(string accounttypename, string note = null)
        {
            //string _table = "dbo.AccountType";
            //string _objects = " AccountTypeName , Note ";
            //string _values = " N'{0}' , N'{1}' " "accounttypename, note";

            //string _query = string.Format("EXEC proc_Insert @table = '{0}' , @object = N'{1}', @value = N'{2}'  ", _table,_objects,_values,_parameter);

            //// string _query = string.Format("INSERT INTO dbo.Account( UserName , PassWord , IDAccountType , Note ) VALUES (N'{0}', N'{1}', {2}, N'{3}')", username, password, accounttype, note);
            //int _result = DataProvider.Instance.ExcuteNonQuery(_query);
            return true;
        }

    }
}
