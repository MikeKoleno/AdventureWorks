using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AdventureWorks.Model;
using AdventureWorks.BusinessCore;

namespace AdventureWorks.ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/")]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> allEmployees = CoreFactory.GetInstance().EmployeeBusinessLogic.GetAllEmployees();
            return allEmployees;
        }

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/{employeeID}")]
        public Employee GetEmployee(string employeeID)
        {
            Employee employee = CoreFactory.GetInstance().EmployeeBusinessLogic.GetEmployee(Int32.Parse(employeeID));
            return employee;
        }
    }
}
