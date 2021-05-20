using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class BillInfomationDAL
    {

        #region DesignPartern Singleton

        private static BillInfomationDAL _instance;

        public static BillInfomationDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BillInfomationDAL();
                }

                return _instance;
            }

            private set => _instance = value;
        }

        private BillInfomationDAL() { }

        #endregion

        public bool InsertBillInfomation(int idbill, int idfood, int foodcount, int idmedical, int medicalcount, int idequipment, int equipmentcount, int idyardtype, int yardtypecount , int idmanager)
        {
            string _query = string.Format(
                " EXECUTE dbo.proc_InsertBillInfomation @IDBill = {0} , @IDFood = {1} , @FoodCount = {2}, @IDMedical = {3} , @MedicalCount = {4} , @IDEquipment = {5} , @EquipmentCount = {6} , @IDYardType = {7} , @YardTypeCount = {8} , @IDManager = {9} ",
                idbill,idfood,foodcount,idmedical,medicalcount,idequipment,equipmentcount,idyardtype,yardtypecount,idmanager);

            int _result = DataProvider.Instance.ExcuteNonQuery(_query);
            return _result > 0;
        }

        

    }
}
