using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Model
{
    public class DepartmentStint
    {
        private Department dept; 
        private DateTime departmentStartDate;
        private DateTime departmentEndDate;

        public Department Dept
        {
            get
            {
                return dept;
            }

            set
            {
                dept = value;
            }
        }

        public DateTime DepartmentStartDate
        {
            get
            {
                return departmentStartDate;
            }

            set
            {
                departmentStartDate = value;
            }
        }

        public DateTime DepartmentEndDate
        {
            get
            {
                return departmentEndDate;
            }

            set
            {
                departmentEndDate = value;
            }
        }
    }
}
