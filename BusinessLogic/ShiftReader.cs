using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ShiftReader
    {
        public IEnumerable<Shift> GetShiftsForEmployee(Employee employee)
        {
            return Data.Shifts.Where(shift => shift.EmployeeId == employee.Id).ToList();
        }
    }
}