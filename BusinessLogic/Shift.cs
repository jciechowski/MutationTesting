using System;

namespace BusinessLogic
{
    public class Shift
    {
        private DateTime StartTime { get; }
        private DateTime EndTime { get; }
        private long EmployeeId { get; }

        public Shift(long employeeId, DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            EmployeeId = employeeId;
        }

        public bool CanPunchIn(long employeeId, DateTime punchInDateTime)
        {
            var shiftBelongsToEmployee = employeeId == EmployeeId;
            var punchedInAfterStart = punchInDateTime >= StartTime;
            var punchedInBeforeEnd = punchInDateTime < EndTime;

            return shiftBelongsToEmployee && punchedInAfterStart && punchedInBeforeEnd;
        }
    }
}