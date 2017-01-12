using AdventureWorks.BusinessCore.DAO;
using AdventureWorks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BusinessCore.BLL
{
    public class EmployeeBLL
    {
        public List<Employee> GetAllEmployees()
        {
            return DAOFactory.GetInstance().EmployeeDataAccess.GetAllEmployees();
        }

        public Employee GetEmployee(int employeeID)
        {
            return DAOFactory.GetInstance().EmployeeDataAccess.GetEmployee(employeeID);
        }

        public void UpdateEmployee (Employee employeeToUpdate)
        {
            
        }
    }
}
