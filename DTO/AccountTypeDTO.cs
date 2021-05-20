using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class AccountTypeDTO
   {
        private string _AccountTypeName;
        private string _Note;

        public string Note { get => _Note; set => _Note = value; }
        public string AccountTypeName { get => _AccountTypeName; set => _AccountTypeName = value; }

        public AccountTypeDTO(string accounttypename ,string note)
        {
            this.AccountTypeName = accounttypename;
            this.Note = note;
        }

        public AccountTypeDTO(DataRow row)
        {
            this.AccountTypeName = row["AccountTypeName"].ToString();
            this.Note = row["Note"].ToString();
        }
   }


    public class AccountType
    {
        private int _IDAccountType;
        private string _AccountTypeName;
        private string _Note;


        public string Note { get => _Note; set => _Note = value; }
        public int IDAccountType { get => _IDAccountType; set => _IDAccountType = value; }
        public string AccountTypeName { get => _AccountTypeName; set => _AccountTypeName = value; }

        public AccountType(int id, string accounttypename, string note)
        {
            this.IDAccountType = id;
            this.Note = note;
            this.AccountTypeName = accounttypename;

        }

    }
}
