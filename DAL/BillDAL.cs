using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
   public class BillDAL
    {

        #region DesignPartern Singleton

        private static BillDAL _instance;

        public static BillDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BillDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private BillDAL() { }

        #endregion

        #region 

        public int GetBillUncheck()
        {
            string _query =  "SELECT* FROM dbo.Bill WHERE Note = 0" ;
            DataTable data = DataProvider.Instance.ExcuteQuery(_query);

            if (data.Rows.Count > 0)
            {
                Bill _bill = new Bill(data.Rows[0]);
                return _bill.IDBill;
            }

            return -1;
        }

        public bool InsertBill(string customername, int price, int discount, int totalprice, int proceeds, int change)
        {
            string _query = string.Format(
            "EXECUTE dbo.proc_InsertBill @CustomerName = N'{0}' , @Price = {1} , @Discount = {2} , @TotalPrice = {3} , @Proceeds = {4} , @Change = {5} ",
            customername,price,discount,totalprice,proceeds,change);

            int _result = DataProvider.Instance.ExcuteNonQuery(_query);
            return _result > 0;
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteSalar("SELECT MAX(IDBill) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }

        public bool CheckoutBill(int idbill)
        {
            string _query = string.Format(" EXECUTE dbo.proc_CheckOutBill @IDBill = {0} ", idbill);
            int _result = DataProvider.Instance.ExcuteNonQuery(_query);
            return _result > 0;
        }


        #endregion
    }

}
