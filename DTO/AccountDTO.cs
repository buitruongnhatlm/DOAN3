using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        private string _UserName;
        private string _PassWord;
        private string _Note;
        private int _IDAccountType;

        public string UserName { get => _UserName; set => _UserName = value; }
        public string PassWord { get => _PassWord; set => _PassWord = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int IDAccountType { get => _IDAccountType; set => _IDAccountType = value; }

        public AccountDTO(string username, string password, string note, int idaccounttype)
        {
            this.UserName = username;
            this.PassWord = password;
            this.Note = note;
            this.IDAccountType = idaccounttype;

        }

        public AccountDTO(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.PassWord = row["PassWord"].ToString();
            this.Note = row["Note"].ToString();
            this.IDAccountType = Convert.ToInt32(row["IDAccountType"].ToString());
        }
        
    }

    public class Account
    {
        private int _IDAccount;
        private string _UserName;
        private string _PassWord;
        private string _Note;
        private int _IDAccountType;

        public int IDAccount { get => _IDAccount; set => _IDAccount = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string PassWord { get => _PassWord; set => _PassWord = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int IDAccountType { get => _IDAccountType; set => _IDAccountType = value; }
       

        public Account(int idaccount,string username, string password, string note, int idaccounttype)
        {
            this.IDAccount = idaccount;
            this.UserName = username;
            this.PassWord = password;
            this.Note = note;
            this.IDAccountType = idaccounttype;

        }

        public Account(DataRow row)
        {
            this.IDAccount = Convert.ToInt32(row["IDAccount"].ToString());

        }

    }
}
