using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class BillInfomationDTO
    {
        private int _IDBill;
        private int _IDFood;
        private int _IDYardType;
        private int _IDMedical;
        private int _IDEquipment;
        private int _IDManager;
        private int _FoodCount;
        private int _MedicalCount;
        private int _YardCount;
        private int _EquipmentCount;

        public int IDBill { get => _IDBill; set => _IDBill = value; }
        public int IDFood { get => _IDFood; set => _IDFood = value; }
        public int IDYardType { get => _IDYardType; set => _IDYardType = value; }
        public int IDMedical { get => _IDMedical; set => _IDMedical = value; }
        public int IDEquipment { get => _IDEquipment; set => _IDEquipment = value; }
        public int IDManager { get => _IDManager; set => _IDManager = value; }
        public int FoodCount { get => _FoodCount; set => _FoodCount = value; }
        public int MedicalCount { get => _MedicalCount; set => _MedicalCount = value; }
        public int YardCount { get => _YardCount; set => _YardCount = value; }
        public int EquipmentCount { get => _EquipmentCount; set => _EquipmentCount = value; }

        public BillInfomationDTO(int idbill, int idfood, int idyardtype, int idmedical, int idequipment, int idmanager,
            int foodcount, int medicalcount, int yardcount, int equipmentcount)
        {
            this.IDBill = idbill;
            this.IDFood = idfood;
            this.IDYardType = idyardtype;
            this.IDMedical = idmedical;
            this.IDEquipment = idequipment;
            this.IDManager = idmanager;
            this.FoodCount = foodcount;
            this.MedicalCount = medicalcount;
            this.YardCount = yardcount;
            this.EquipmentCount = equipmentcount;
        }

        public BillInfomationDTO(DataRow row)
        {
            this.IDBill = Convert.ToInt32(row["IDBill"].ToString());
            this.IDFood = Convert.ToInt32(row["IDFood"].ToString());
            this.IDYardType = Convert.ToInt32(row["IDYardType"].ToString());
            this.IDMedical = Convert.ToInt32(row["IDMedical"].ToString());
            this.IDEquipment = Convert.ToInt32(row["IDEquipment"].ToString());
            this.IDManager = Convert.ToInt32(row["IDManager"].ToString());
            this.FoodCount = Convert.ToInt32(row["FoodCount"].ToString());
            this.MedicalCount = Convert.ToInt32(row["MedicalCount"].ToString());
            this.YardCount = Convert.ToInt32(row["YardCount"].ToString());
            this.EquipmentCount = Convert.ToInt32(row["EquipmentCount"].ToString());
        }
    }

    public class BillInfomation
    {
        private int _IDBillInfomation;
        private int _IDBill;
        private int _IDFood;
        private int _IDYardType;
        private int _IDMedical;
        private int _IDEquipment;
        private int _IDManager;

        public int IDBill { get => _IDBill; set => _IDBill = value; }
        public int IDFood { get => _IDFood; set => _IDFood = value; }
        public int IDYardType { get => _IDYardType; set => _IDYardType = value; }
        public int IDMedical { get => _IDMedical; set => _IDMedical = value; }
        public int IDEquipment { get => _IDEquipment; set => _IDEquipment = value; }
        public int IDManager { get => _IDManager; set => _IDManager = value; }
        public int IDBillInfomation { get => _IDBillInfomation; set => _IDBillInfomation = value; }

        public BillInfomation(int idinfo,int idbill, int idfood, int idyardtype, int idmedical, int idequipment, int idmanager)
        {
            this.IDBillInfomation = idinfo;
            this.IDBill = idbill;
            this.IDFood = idfood;
            this.IDYardType = idyardtype;
            this.IDMedical = idmedical;
            this.IDEquipment = idequipment;
            this.IDManager = idmanager;
        }

        public BillInfomation(DataRow row)
        {
            this.IDBillInfomation = Convert.ToInt32(row["IDBillInfomation"].ToString());
            this.IDBill = Convert.ToInt32(row["IDBill"].ToString());
            this.IDFood = Convert.ToInt32(row["IDFood"].ToString());
            this.IDYardType = Convert.ToInt32(row["IDYardType"].ToString());
            this.IDMedical = Convert.ToInt32(row["IDMedical"].ToString());
            this.IDEquipment = Convert.ToInt32(row["IDEquipment"].ToString());
            this.IDManager = Convert.ToInt32(row["IDManager"].ToString());
        }

    }
}
