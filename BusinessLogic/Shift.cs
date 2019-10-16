using System;

namespace BusinessLogic
{
    public class Shift
    {
        private DateTime StartTime { get; }
        private DateTime EndTime { get; }
        public long EmployeeId { get; }

        public Shift(DateTime startTime, DateTime endTime, long employeeId)
        {
            StartTime = startTime;
            EndTime = endTime;
            EmployeeId = employeeId;
        }

        public bool CanPunchIn(Employee employee, DateTime punchInDateTime)
        {
            var shiftBelongsToEmployee = employee.Id == EmployeeId;
            var punchedInAfterStart = punchInDateTime >= StartTime;
            var punchedInBeforeEnd = punchInDateTime < EndTime;

            if (!shiftBelongsToEmployee) return false;

            return punchedInBeforeEnd && punchedInAfterStart;
        }
    }
}