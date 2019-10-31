using System;
using BusinessLogic;
using FluentAssertions;
using Xunit;

namespace MutationTesting
{
    public class ShiftPunchIn
    {
        private const int EmployeeId = 1;

        [Fact]
        public void IsForbiddenForWrongEmployee()
        {
            var otherEmployee = EmployeeId+1;

            var shift = new ShiftBuilder()
                .WithEmployeeId(otherEmployee)
                .Build();

            var punchInTime = DateTime.Now;
            shift.CanPunchIn(EmployeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenAfterShiftEnd()
        {
            var shift = new ShiftBuilder()
                .WithEmployeeId(EmployeeId)
                .Build();

            var punchInTime = DateTime.Now.AddHours(12);

            shift.CanPunchIn(EmployeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenBeforeShiftStart()
        {
            var shift = new ShiftBuilder()
                .WithEmployeeId(EmployeeId)
                .Build();

            var punchInTime = DateTime.Now.AddHours(-12);

            shift.CanPunchIn(EmployeeId, punchInTime).Should().BeFalse();
        }
    }

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