using System;
using BusinessLogic;

namespace MutationTesting
{
    public class ShiftBuilder
    {
        private long _employeeId = 1;
        private DateTime _startTime = DateTime.Now.AddHours(-4);
        private DateTime _endTime = DateTime.Now.AddHours(4);

        public ShiftBuilder WithEmployeeId(long employeeId)
        {
            _employeeId = employeeId;
            return this;
        }

        public ShiftBuilder WithStartTime(DateTime startTime)
        {
            _startTime = startTime;
            return this;
        }

        public ShiftBuilder WithEndTime(DateTime endTime)
        {
            _endTime = endTime;
            return this;
        }

        public Shift Build()
        {
            return new Shift(_employeeId, _startTime, _endTime);
        }
    }
}