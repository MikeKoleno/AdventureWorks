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
            EmployeeDAO eDAO = new EmployeeDAO();
            return eDAO.GetAllEmployees();
        }

        public Employee GetEmployee(int employeeID)
        {
            EmployeeDAO eDAO = new EmployeeDAO();
            return eDAO.GetEmployee(employeeID);
        }

        public void UpdateEmployee (Employee employeeToUpdate)
        {
            EmployeeDAO eDAO = new EmployeeDAO();
            if (!HasSpecialChars(employeeToUpdate.LoginID.Replace("\\","" ).Replace("-", ""))) {
                eDAO.UpdateEmployee(employeeToUpdate);
            } else
            {
                throw new SystemException("Employee LoginID must contain ONLY alpha or numeric characters");
            }
            
        }

        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
    }
}
