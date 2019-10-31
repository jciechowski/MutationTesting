using System;
using BusinessLogic;
using FluentAssertions;
using Xunit;

namespace MutationTesting
{
    public class ShiftPunchIn
    {
        private int _employeeId = 1;

        [Fact]
        public void IsForbiddenForWrongEmployee()
        {
            var otherEmployee = _employeeId+1;

            var shift = new ShiftBuilder()
                .WithEmployeeId(otherEmployee)
                .Build();

            var punchInTime = DateTime.Now;
            shift.CanPunchIn(_employeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenAfterShiftEnd()
        {
            var shift = new ShiftBuilder()
                .WithEmployeeId(_employeeId)
                .Build();

            var punchInTime = DateTime.Now.AddHours(12);

            shift.CanPunchIn(_employeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenBeforeShiftStart()
        {
            var shift = new ShiftBuilder()
                .WithEmployeeId(_employeeId)
                .Build();

            var punchInTime = DateTime.Now.AddHours(-12);

            shift.CanPunchIn(_employeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsAllowedExactlyAtShiftStart()
        {
            var punchInTime = DateTime.Now.AddHours(-4);
            var startTime = punchInTime;

            var shift = new ShiftBuilder()
                .WithEmployeeId(_employeeId)
                .WithStartTime(startTime)
                .Build();

            shift.CanPunchIn(_employeeId, punchInTime).Should().BeTrue();
        }

        [Fact]
        public void IsForbiddenExactlyAtEndTime()
        {
            var punchInTime = DateTime.Now;
            var endTime = punchInTime;

            var shift = new ShiftBuilder()
                .WithEmployeeId(_employeeId)
                .WithEndTime(endTime).Build();

            shift.CanPunchIn(_employeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void FindAssignedShifts()
        {
            var shift = new Shift();

            shift.HasAnyShifts(_employeeId).Should().BeTrue();
        }

        [Fact]
        public void NoAssignedShifts()
        {
            var shift = new Shift();

            shift.HasAnyShifts(666).Should().BeFalse();
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