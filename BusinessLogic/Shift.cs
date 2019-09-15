using System;

namespace BusinessLogic
{
    public class Shift
    {
        public Shift(DateTime startTime, DateTime endTime, long employeeId, long departmentId)
        {
            StartTime = startTime;
            EndTime = endTime;
            EmployeeId = employeeId;
            DepartmentId = departmentId;
        }

        private DateTime StartTime { get; }
        private DateTime EndTime { get; }
        private long EmployeeId { get; }
        private long DepartmentId { get; }

        public bool CanPunchIn(DateTime punchInDateTime)
        {
            return punchInDateTime >= StartTime && punchInDateTime < EndTime;
        }
    }
}