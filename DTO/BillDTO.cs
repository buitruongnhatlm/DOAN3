using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BillDTO
    {
        private string _CustomerName;
        private int _Price;
        private int _Discount;
        private int _TotalPrice;
        private int _Proceeds;
        private int _Change;
        private DateTime _Date;
        private string _Note;

        public string CustomerName { get => _CustomerName; set => _CustomerName = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int Discount { get => _Discount; set => _Discount = value; }
        public int TotalPrice { get => _TotalPrice; set => _TotalPrice = value; }
        public int Proceeds { get => _Proceeds; set => _Proceeds = value; }
        public int Change { get => _Change; set => _Change = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public string Note { get => _Note; set => _Note = value; }

        public BillDTO(string customername, int price, int discount, int totalprice,
                        int proceeds, int change, DateTime date, string note)
        {
            this.CustomerName = customername;
            this.Price = price;
            this.Discount = discount;
            this.TotalPrice = totalprice;
            this.Proceeds = proceeds;
            this.Change = change;
            this.Date = date;
            this.Note = note;

        }

        public BillDTO(DataRow row)
        {
            this.CustomerName = row["CustomerName"].ToString();
            this.Price = Convert.ToInt32(row["Price"].ToString());
            this.Discount = Convert.ToInt32(row["Discount"].ToString());
            this.TotalPrice = Convert.ToInt32(row["TotalPrice"].ToString());
            this.Proceeds = Convert.ToInt32(row["Proceeds"].ToString());
            this.Change = Convert.ToInt32(row["Change"].ToString());
            this.Date = Convert.ToDateTime(row["Date"].ToString());
            this.Note = row["Note"].ToString();
        }
    }

    public class Bill
    {
        private int _IDBill;
        private string _CustomerName;
        private int _Price;
        private int _Discount;
        private int _TotalPrice;
        private int _Proceeds;
        private int _Change;
        private DateTime _Date;
        private string _Note;

        public string CustomerName { get => _CustomerName; set => _CustomerName = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int Discount { get => _Discount; set => _Discount = value; }
        public int TotalPrice { get => _TotalPrice; set => _TotalPrice = value; }
        public int Proceeds { get => _Proceeds; set => _Proceeds = value; }
        public int Change { get => _Change; set => _Change = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int IDBill { get => _IDBill; set => _IDBill = value; }

        public Bill(int idbill, string customername, int price, int discount, int totalprice,
                        int proceeds, int change, DateTime date, string note)
        {
            this.IDBill = idbill;
            this.CustomerName = customername;
            this.Price = price;
            this.Discount = discount;
            this.TotalPrice = totalprice;
            this.Proceeds = proceeds;
            this.Change = change;
            this.Date = date;
            this.Note = note;

        }

        public Bill(DataRow row)
        {
            this.IDBill = Convert.ToInt32(row["IDBill"].ToString());
            this.CustomerName = row["CustomerName"].ToString();
            this.Price = Convert.ToInt32(row["Price"].ToString());
            this.Discount = Convert.ToInt32(row["Discount"].ToString());
            this.TotalPrice = Convert.ToInt32(row["TotalPrice"].ToString());
            this.Proceeds = Convert.ToInt32(row["Proceeds"].ToString());
            this.Change = Convert.ToInt32(row["Change"].ToString());
            this.Date = Convert.ToDateTime(row["Date"].ToString());
            this.Note = row["Note"].ToString();
        }
    }
}
