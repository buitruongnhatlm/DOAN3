using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FoodDTO
    {
        private string _FoodName;
        private string _Unit;
        private string _Type;
        private string _Note;
        private int _Price;

        public string FoodName { get => _FoodName; set => _FoodName = value; }
        public string Unit { get => _Unit; set => _Unit = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int Price { get => _Price; set => _Price = value; }
        public string Type { get => _Type; set => _Type = value; }

        public FoodDTO(string foodname, string unit,string type, int price ,string note)
        {
            this.FoodName = foodname;
            this.Unit = unit;
            this.Type = type;
            this.Price = price;
            this.Note = note;
        }

        public FoodDTO(DataRow row)
        {
            this.FoodName = row["FoodName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Type = row["Type"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Note = row["Note"].ToString();
        }
    }

    public class Food
    {
        private int _IDFood;
        private string _FoodName;
        private int _Price;
        private string _Unit;
        private string _Note;
        private string _Type;

        public string FoodName { get => _FoodName; set => _FoodName = value; }
        public string Unit { get => _Unit; set => _Unit = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int Price { get => _Price; set => _Price = value; }
        public int IDFood { get => _IDFood; set => _IDFood = value; }
        public string Type { get => _Type; set => _Type = value; }

        public Food(int idfood, string foodname, string unit,string type, int price, string note)
        {
            this.IDFood = idfood;
            this.FoodName = foodname;
            this.Type = type;
            this.Price = price;
            this.Unit = unit;
            this.Note = note;
        }

        public Food(DataRow row)
        {
            this.FoodName = row["FoodName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Type = row["Type"].ToString();
            this.Note = row["Note"].ToString();
            this.IDFood = Convert.ToInt32(row["IDFood"]);
        }

    }
}
