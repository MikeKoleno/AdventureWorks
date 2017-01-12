using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureWorks.BusinessCore.DAO;

namespace AdventureWorks.BusinessCore
{
    public class DAOFactory
    {
        private static volatile DAOFactory instance;
        private static object syncRoot = new Object();

        private readonly ShiftDAO shiftDataAccess = new ShiftDAO();
        private readonly EmployeeDAO employeeDataAccess = new EmployeeDAO();

        private DAOFactory() { }

        public ShiftDAO ShiftDataAccess
        {
            get
            {
                return shiftDataAccess;
            }
        }

        public EmployeeDAO EmployeeDataAccess
        {
            get
            {
                return employeeDataAccess;
            }
        }

        public static DAOFactory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new DAOFactory();
                }
            }

            return instance;
        }
    }
}