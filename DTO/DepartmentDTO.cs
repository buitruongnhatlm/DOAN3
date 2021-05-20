using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DepartmentDTO
    {
        private string _DepartmentName;
        private string _Note;

        public string DepartmentName { get => _DepartmentName; set => _DepartmentName = value; }
        public string Note { get => _Note; set => _Note = value; }

        public DepartmentDTO(string department, string note=null)
        {
            this.DepartmentName = department;
            this.Note = note;
        }

        public DepartmentDTO(DataRow row)
        {
            this.DepartmentName = row["DepartmentName"].ToString();
            this.Note = row["Note"].ToString();
        }
    }

    public class Department
    {
        private int _IDDepartment;
        private string _DepartmentName;
        private string _Note;

        public string DepartmentName { get => _DepartmentName; set => _DepartmentName = value; }
        public string Note { get => _Note; set => _Note = value; }
        public int IDDepartment { get => _IDDepartment; set => _IDDepartment = value; }

        public Department(int id,string department, string note = null)
        {
            this.IDDepartment = id;
            this.DepartmentName = department;
            this.Note = note;
        }

        public Department(DataRow row)
        {
            this.IDDepartment = Convert.ToInt32(row["IDDepartment"].ToString());
            this.DepartmentName = row["DepartmentName"].ToString();
            this.Note = row["Note"].ToString();
        }
    }
}
