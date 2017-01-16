using AdventureWorks.BusinessCore.DAO;
using AdventureWorks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BusinessCore.BLL
{
    public class ShiftBLL
    {
        public List<Shift> GetAllShifts()
        {
            ShiftDAO sDAO = new ShiftDAO();
            return sDAO.GetAllShifts();
        }

        public Shift GetShift(int shiftID)
        {
            ShiftDAO sDAO = new ShiftDAO();
            return sDAO.GetShift(shiftID);
        }
    }
}
