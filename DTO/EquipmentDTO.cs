using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EquipmentDTO
    {
        private string _EquipmentName;
        private string _Unit;
        private string _Note;
        private int _Price;
        private string _Type;

        public string Unit { get => _Unit; set => _Unit = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int Price { get => _Price; set => _Price = value; }
        public string EquipmentName { get => _EquipmentName; set => _EquipmentName = value; }
        public string Type { get => _Type; set => _Type = value; }

        public EquipmentDTO(string equipmentname, string unit, string type, int price, string note)
        {
            this.EquipmentName = equipmentname;
            this.Unit = unit;
            this.Type = type;
            this.Price = price;
            this.Note = note;
        }

        public EquipmentDTO(DataRow row)
        {
            this.EquipmentName = row["EquipmentName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Type = row["Type"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Note = row["Note"].ToString();
        }
    }

    public class Equipment
    {
        private int _IDEquipment;
        private string _EquipmentName;
        private string _Unit;
        private string _Note;
        private int _Price;
        private string _Type;

        public string Unit { get => _Unit; set => _Unit = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int Price { get => _Price; set => _Price = value; }
        public string EquipmentName { get => _EquipmentName; set => _EquipmentName = value; }
        public int IDEquipment { get => _IDEquipment; set => _IDEquipment = value; }
        public string Type { get => _Type; set => _Type = value; }

        public Equipment(int idequipment,string equipmentname, string type ,string unit, int price, string note)
        {
            this.IDEquipment = idequipment;
            this.EquipmentName = equipmentname;
            this.Unit = unit;
            this.Type = type;
            this.Price = price;
            this.Note = note;
        }

        public Equipment(DataRow row)
        {
            this.IDEquipment = Convert.ToInt32(row["IDEquipment"]);
            this.EquipmentName = row["EquipmentName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Type = row["Type"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Note = row["Note"].ToString();
        }
    }

}
