using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class MedicalDTO
    {
        private string _MedicalName;
        private string _Unit;
        private string _Type;
        private int _Price;
        private string _Note;


        public string MedicalName { get => _MedicalName; set => _MedicalName = value; }
        public string Unit { get => _Unit; set => _Unit = value; }
        public int Price { get => _Price; set => _Price = value; }
        public string Note { get => _Note; set => _Note = value; }
        public string Type { get => _Type; set => _Type = value; }

        public MedicalDTO(string medicalname, string unit,string type, int price, string note)
        {
            this.MedicalName = medicalname;
            this.Unit = unit;
            this.Type = type;
            this.Price = price;
            this.Note = note;
        }

        public MedicalDTO(DataRow row)
        {
            this.MedicalName = row["MedicalName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Type = row["Type"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Note = row["Note"].ToString();
        }
    }

    public class Medical
    {
        private int _IDMedical;
        private string _MedicalName;
        private string _Unit;
        private int _Price;
        private string _Note;
        private string _Type;

        public string MedicalName { get => _MedicalName; set => _MedicalName = value; }
        public string Unit { get => _Unit; set => _Unit = value; }
        public int Price { get => _Price; set => _Price = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int IDMedical { get => _IDMedical; set => _IDMedical = value; }
        public string Type { get => _Type; set => _Type = value; }

        public Medical(int idmedical ,string medicalname, string unit, string type ,int price, string note)
        {
            this.IDMedical = idmedical;
            this.MedicalName = medicalname;
            this.Unit = unit;
            this.Type = type;
            this.Price = price;
            this.Note = note;
        }

        public Medical(DataRow row)
        {
            this.IDMedical = Convert.ToInt32(row["IDMedical"]);
            this.MedicalName = row["MedicalName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Unit = row["Type"].ToString();
            this.Price = Convert.ToInt32(row["Price"]);
            this.Note = row["Note"].ToString();
        }
    }
}
