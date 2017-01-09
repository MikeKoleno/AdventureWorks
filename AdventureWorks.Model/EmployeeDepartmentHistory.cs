using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Model
{
    public class EmployeeDepartmentHistory : Employee
    {
        private List<DepartmentStint> dptHistory = new List<DepartmentStint>();

        public List<DepartmentStint> DptHistory
        {
            get
            {
                return dptHistory;
            }

            set
            {
                dptHistory = value;
            }
        }
    }
}
