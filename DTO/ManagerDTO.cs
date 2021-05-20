using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ManagerDTO
    {
        private string _Name;
        private DateTime _Birthday;
        private string _Sex;
        private int _IdentityNumber;
        private string _BirthPlace;
        private string _Address;
        private int _NumberPhone;
        private string _Email;
        private string _Note;
        private int _IDAccount;
        private int _IDDepartment;

        public string Name { get => _Name; set => _Name = value; }
        public DateTime Birthday { get => _Birthday; set => _Birthday = value; }
        public string Sex { get => _Sex; set => _Sex = value; }
        public int IdentityNumber { get => _IdentityNumber; set => _IdentityNumber = value; }
        public string BirthPlace { get => _BirthPlace; set => _BirthPlace = value; }
        public string Address { get => _Address; set => _Address = value; }
        public int NumberPhone { get => _NumberPhone; set => _NumberPhone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int IDAccount { get => _IDAccount; set => _IDAccount = value; }
        public int IDDepartment { get => _IDDepartment; set => _IDDepartment = value; }

        public ManagerDTO(string name, DateTime birthday, string sex, int identity, string birthplace, 
            string address, int numberphone, string email, int idaccount, int iddepartment, string note = null)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Sex = sex;
            this.IdentityNumber = identity;
            this.BirthPlace = birthplace;
            this.Address = address;
            this.NumberPhone = numberphone;
            this.Email = email;
            this.IDAccount = idaccount;
            this.IDDepartment = iddepartment;
            this.Note = note;
        }

        public ManagerDTO(DataRow row)
        {
            this.Name = row["Name"].ToString();
            this.Birthday = Convert.ToDateTime(row["Birthday"].ToString());
            this.Sex = row["Sex"].ToString();
            this.IdentityNumber = Convert.ToInt32(row["IdentityNumber"].ToString());
            this.BirthPlace = row["BirthPlace"].ToString();
            this.Address =row["Address"].ToString();
            this.NumberPhone = Convert.ToInt32(row["NumberPhone"].ToString());
            this.Email = row["Email"].ToString();
            this.IDAccount = Convert.ToInt32(row["IDAccount"].ToString());
            this.IDDepartment = Convert.ToInt32(row["IDDepartment"].ToString());
            this.Note = row["Note"].ToString();
        }

    }

    public class Manager
    {
        private int _IDManager;
        private string _Name;
        private DateTime _Birthday;
        private string _Sex;
        private int _IdentityNumber;
        private string _BirthPlace;
        private string _Address;
        private int _NumberPhone;
        private string _Email;
        private string _Note;
        private int _IDAccount;
        private int _IDDepartment;

        public string Name { get => _Name; set => _Name = value; }
        public DateTime Birthday { get => _Birthday; set => _Birthday = value; }
        public string Sex { get => _Sex; set => _Sex = value; }
        public int IdentityNumber { get => _IdentityNumber; set => _IdentityNumber = value; }
        public string BirthPlace { get => _BirthPlace; set => _BirthPlace = value; }
        public string Address { get => _Address; set => _Address = value; }
        public int NumberPhone { get => _NumberPhone; set => _NumberPhone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int IDAccount { get => _IDAccount; set => _IDAccount = value; }
        public int IDDepartment { get => _IDDepartment; set => _IDDepartment = value; }
        public int IDManager { get => _IDManager; set => _IDManager = value; }

        public Manager(int idmanager,string name, DateTime birthday, string sex, int identity, string birthplace,
            string address, int numberphone, string email, int idaccount, int iddepartment, string note = null)
        {
            this.IDManager = idmanager;
            this.Name = name;
            this.Birthday = birthday;
            this.Sex = sex;
            this.IdentityNumber = identity;
            this.BirthPlace = birthplace;
            this.Address = address;
            this.NumberPhone = numberphone;
            this.Email = email;
            this.IDAccount = idaccount;
            this.IDDepartment = iddepartment;
            this.Note = note;
        }

        public Manager(DataRow row)
        {
            this.IDManager = Convert.ToInt32(row["IDManager"].ToString());
            this.Name = row["Name"].ToString();
            this.Birthday = Convert.ToDateTime(row["Birthday"].ToString());
            this.Sex = row["Sex"].ToString();
            this.IdentityNumber = Convert.ToInt32(row["IdentityNumber"].ToString());
            this.BirthPlace = row["BirthPlace"].ToString();
            this.Address = row["Address"].ToString();
            this.NumberPhone = Convert.ToInt32(row["NumberPhone"].ToString());
            this.Email = row["Email"].ToString();
            this.IDAccount = Convert.ToInt32(row["IDAccount"].ToString());
            this.IDDepartment = Convert.ToInt32(row["IDDepartment"].ToString());
            this.Note = row["Note"].ToString();
        }

    }
}
