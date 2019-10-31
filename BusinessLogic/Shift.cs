using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Shift
    {
        private DateTime StartTime { get; }
        private DateTime EndTime { get; }
        private long EmployeeId { get; }

        public Shift()
        {
            
        }

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

        public bool HasAnyShifts(long employeeId)
        {
            var userShifts = new Dictionary<long, Shift>()
            {
                {1, new Shift(1, DateTime.Now, DateTime.Now.AddHours(4))},
                {2, new Shift(1, DateTime.Now, DateTime.Now.AddHours(4))},
                {3, new Shift(1, DateTime.Now, DateTime.Now.AddHours(4))}
            };

            return userShifts.Keys.Any(key => key == employeeId);
        }
    }
}