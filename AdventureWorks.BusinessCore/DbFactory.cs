using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureWorks.BusinessCore.DAO;

namespace AdventureWorks.BusinessCore
{
    public class DbFactory
    {
        private static volatile DbFactory instance;
        private static object syncRoot = new Object();

        private readonly ShiftDAO shiftDataAccess = new ShiftDAO();
        private readonly EmployeeDAO employeeDataAccess = new EmployeeDAO();

        private DbFactory() { }

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

        public static DbFactory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new DbFactory();
                }
            }

            return instance;
        }
    }
}
