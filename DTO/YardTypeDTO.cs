using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class YardTypeDTO
    {
        private string _YardTypeName;
        private string _Unit;
        private string _Type;
        private string _Note;
        private int _Price;
       
       
        public string Unit { get => _Unit; set => _Unit = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int Price { get => _Price; set => _Price = value; }
        public string YardTypeName { get => _YardTypeName; set => _YardTypeName = value; }
        public string Type { get => _Type; set => _Type = value; }

        public YardTypeDTO(string yardtypename, string unit,string type, int price, string note)
        {
            this.YardTypeName = yardtypename;
            this.Unit = unit;
            this.Type = type;
            this.Price = price;
            this.Note = note;
        }

        public YardTypeDTO(DataRow row)
        {
            this.YardTypeName = row["YardTypeName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Type = row["Type"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Note = row["Note"].ToString();
        }
    }

    public class YardType
    {
        private int _IDYardType;
        private string _YardTypeName;
        private string _Unit;
        private string _Note;
        private int _Price;
        private string _Type;


        public string Unit { get => _Unit; set => _Unit = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int Price { get => _Price; set => _Price = value; }
        public string YardTypeName { get => _YardTypeName; set => _YardTypeName = value; }
        public int IDYardType { get => _IDYardType; set => _IDYardType = value; }
        public string Type { get => _Type; set => _Type = value; }

        public YardType(int idyardtype, string yardtypename,string type , string unit, int price, string note)
        {
            this.IDYardType = idyardtype;
            this.YardTypeName = yardtypename;
            this.Unit = unit;
            this.Type = type;
            this.Price = price;
            this.Note = note;
        }

        public YardType(DataRow row)
        {
            this.IDYardType = Convert.ToInt32(row["IDYardType"]);
            this.YardTypeName = row["YardTypeName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Type = row["Type"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Note = row["Note"].ToString();
        }
    }
}
