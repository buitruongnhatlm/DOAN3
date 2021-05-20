using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BillLogDTO
    {
        private int _IDBillInfomation;
        private int _IDBill;
        private string _CustomerName;
        private int _Price;
        private int _Discount;
        private int _TotalPrice;
        private int _Proceeds;
        private int _Change;
        private DateTime _Date;
        private string _Note;
        private string _Food;
        private string _YardType;
        private string _Medical;
        private string _Equipment;
        private string _Manager;
        private int _FoodCount;
        private int _MedicalCount;
        private int _YardCount;
        private int _EquipmentCount;


        public BillLogDTO(int idbill, int idbillinfo,string customername, int price, int discount, int totalprice, string food, 
                        string yardtype, string medical, string equipment, string manager,int foodcount, int medicalcount, 
                        int yardcount, int equipmentcount, int proceeds, int change, DateTime date, string note)
        {
            this.IDBill = idbill;
            this.IDBillInfomation = idbillinfo;
            this.CustomerName = customername;
            this.Price = price;
            this.Discount = discount;
            this.TotalPrice = totalprice;
            this.Proceeds = proceeds;
            this.Change = change;
            this.Date = date;
            this.Note = note;
            this.Food = food;
            this.YardType = yardtype;
            this.Medical = medical;
            this.Equipment = equipment;
            this.Manager = manager;
            this.FoodCount = foodcount;
            this.MedicalCount = medicalcount;
            this.YardCount = yardcount;
            this.EquipmentCount = equipmentcount;

        }

        public int IDBillInfomation { get => _IDBillInfomation; set => _IDBillInfomation = value; }
        public int IDBill { get => _IDBill; set => _IDBill = value; }
        public string CustomerName { get => _CustomerName; set => _CustomerName = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int Discount { get => _Discount; set => _Discount = value; }
        public int TotalPrice { get => _TotalPrice; set => _TotalPrice = value; }
        public int Proceeds { get => _Proceeds; set => _Proceeds = value; }
        public int Change { get => _Change; set => _Change = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public string Note { get => _Note; set => _Note = value; }
        public string Food { get => _Food; set => _Food = value; }
        public string YardType { get => _YardType; set => _YardType = value; }
        public string Medical { get => _Medical; set => _Medical = value; }
        public string Equipment { get => _Equipment; set => _Equipment = value; }
        public string Manager { get => _Manager; set => _Manager = value; }
        public int FoodCount { get => _FoodCount; set => _FoodCount = value; }
        public int MedicalCount { get => _MedicalCount; set => _MedicalCount = value; }
        public int YardCount { get => _YardCount; set => _YardCount = value; }
        public int EquipmentCount { get => _EquipmentCount; set => _EquipmentCount = value; }

        public BillLogDTO(DataRow row)
        {
            this.IDBill = Convert.ToInt32(row["IDBill"].ToString());
            this.IDBillInfomation = Convert.ToInt32(row["IDBillInfomation"].ToString());
            this.CustomerName = row["CustomerName"].ToString();
            this.Price = Convert.ToInt32(row["Price"].ToString());
            this.Discount = Convert.ToInt32(row["Discount"].ToString());
            this.TotalPrice = Convert.ToInt32(row["TotalPrice"].ToString());
            this.Proceeds = Convert.ToInt32(row["Proceeds"].ToString());
            this.Change = Convert.ToInt32(row["Change"].ToString());
            this.Date = Convert.ToDateTime(row["Date"].ToString());
            this.Note = row["Note"].ToString();
            this.Food = row["FoodName"].ToString();
            this.YardType = row["YardTypeName"].ToString();
            this.Medical = row["MedicalName"].ToString();
            this.Equipment = row["EquipmentName"].ToString();
            this.Manager = row["Name"].ToString();
            this.FoodCount = Convert.ToInt32(row["FoodCount"].ToString());
            this.MedicalCount = Convert.ToInt32(row["MedicalCount"].ToString());
            this.YardCount = Convert.ToInt32(row["YardCount"].ToString());
            this.EquipmentCount = Convert.ToInt32(row["EquipmentCount"].ToString());
        }

    }
}
