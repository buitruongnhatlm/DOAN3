using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class AccountDAL
    {
        int _TYPE;
        string _TENTAIKHOAN;

        private static AccountDAL _instance;

        public static AccountDAL Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AccountDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private AccountDAL() { }

        #region Login

        public bool Login(string username, string password)
        {
            string _query = " EXECUTE dbo.proc_Login @username , @password ";

            DataTable _result = DataProvider.Instance.ExcuteQuery(_query, new object[] { username, password });

            foreach (DataRow row in _result.Rows)
            {
                AccountDTO _accountDTO = new AccountDTO(row);
            }

            return _result.Rows.Count > 0;

        }

        #endregion

        #region 

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExcuteQuery("EXECUTE dbo.proc_GetListAccount");
        }


        /// <summary>
        /// Thêm tài khoản
        /// </summary>
        /// <param name="tentaikhoan"></param>
        /// <param name="matkhau"></param>
        /// <param name="email"></param>
        /// <param name="sodienthoai"></param>
        /// <param name="idloaitaikhoan"></param>
        /// <param name="ghichu"></param>
        /// <returns></returns>
        public bool InsertAccount(string username, string password, int accounttype, string note = null)
        {
            string _query = string.Format("INSERT INTO dbo.Account( UserName , PassWord , IDAccountType , Note ) VALUES (N'{0}', N'{1}', {2}, N'{3}')", username, password, accounttype, note);
            int _result = DataProvider.Instance.ExcuteNonQuery(_query);
            return _result > 0;
        }

        /// <summary>
        /// cập nhật tài khoản
        /// </summary>
        /// <param name="tentaikhoan"></param>
        /// <param name="email"></param>
        /// <param name="sodienthoai"></param>
        /// <param name="idloaitaikhoan"></param>
        /// <param name="ghichu"></param>
        /// <returns></returns>
        public bool UpdateAccount(string username, string password, int accounttype, string note = null)
        {
            string _query = string.Format("UPDATE dbo.Account SET PassWord=N'{0}', Note=N'{1}', IDAccountType={2} WHERE UserName = N'{3}' ", password, note, accounttype, username);
            int _result = DataProvider.Instance.ExcuteNonQuery(_query);
            return _result > 0;
        }

        /// <summary>
        /// xóa tài khoản
        /// </summary>
        /// <param name="tentaikhoan"></param>
        /// <returns></returns>
        public bool DeleteAccount(string username)
        {
            string _query = string.Format("DELETE dbo.Account WHERE UserName=N'{0}' ", username);
            int _result = DataProvider.Instance.ExcuteNonQuery(_query);
            return _result > 0;
        }

        /// <summary>
        /// Tìm kiếm tài khoản
        /// </summary>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public DataTable SearchAccountByUserName(string content)
        {
            string _query = string.Format(" EXECUTE dbo.proc_SearchAccountByUserName @content = N'{0}' ", content);
            return DataProvider.Instance.ExcuteQuery(_query);
        }

        public DataTable SearchAccountByNote(string content)
        {
            string _query = string.Format(" EXECUTE dbo.proc_SearchAccountByNote @content = N'{0}' ", content);
            return DataProvider.Instance.ExcuteQuery(_query);
        }


        public int GetIDAccountByUsername(string tentaikhoan)
        {
            int _id = 1;

            string _query = string.Format("Select IDAccountType from dbo.Account where UserName = N'{0}'", tentaikhoan);

            DataTable _result = DataProvider.Instance.ExcuteQuery(_query, new object[] { tentaikhoan });

            foreach (DataRow row in _result.Rows)
            {
                Account _account = new Account(row);
                _id = _account.IDAccountType;
            }

            return _id;
        }


        #endregion

    }
}
