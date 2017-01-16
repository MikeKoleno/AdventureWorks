using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureWorks.BusinessCore.DAO;
using AdventureWorks.BusinessCore.BLL;

namespace AdventureWorks.BusinessCore
{
    public class CoreFactory
    {
        private static volatile CoreFactory instance;
        private static object syncRoot = new Object();

        private readonly EmployeeBLL employeeBusinessLogic = new EmployeeBLL();
        private readonly ShiftBLL shiftBusinessLogic = new ShiftBLL();

        private CoreFactory() { }

        public EmployeeBLL EmployeeBusinessLogic
        {
            get
            {
                return employeeBusinessLogic;
            }
        }

        public ShiftBLL ShiftBusinessLogic
        {
            get
            {
                return shiftBusinessLogic;
            }
        }

        public static CoreFactory GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new CoreFactory();
                }
            }

            return instance;
        }
    }
}