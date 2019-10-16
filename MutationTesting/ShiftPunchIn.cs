using System;
using BusinessLogic;
using FluentAssertions;
using Xunit;

namespace MutationTesting
{
    public class ShiftPunchIn
    {
        [Fact]
        public void IsForbiddenAfterEndTime()
        {
            var employee = new Employee(1);
            var endTime = DateTime.Now.AddHours(1);

            var shift = new ShiftBuilder().WithEmployee(employee.Id).WithEndTime(DateTime.Now).Build();

            shift.CanPunchIn(employee, endTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenAtEndTime()
        {
            var employee = new Employee(1);
            var endTime = DateTime.Now.AddHours(-12);

            var shift = new ShiftBuilder().WithEmployee(employee.Id).WithEndTime(endTime).Build();

            shift.CanPunchIn(employee, endTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenForPastShifts()
        {
            var employee = new Employee(1);

            var shift = new ShiftBuilder().WithEmployee(employee.Id).Build();

            shift.CanPunchIn(employee, DateTime.Now).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenForWrongEmployee()
        {
            var employee = new Employee(-1);
            var otherEmployee = new Employee(1);

            var startTime = DateTime.Now;
            var shift = new ShiftBuilder().WithEmployee(otherEmployee.Id).WithStartTime(startTime).Build();


            shift.CanPunchIn(employee, startTime).Should().BeFalse();
        }

        [Fact]
        public void IsPossibleAtStartTime()
        {
            var employee = new Employee(1);
            var startTime = DateTime.Now.AddDays(-1);

            var shift = new ShiftBuilder().WithEmployee(employee.Id).WithStartTime(startTime).Build();


            shift.CanPunchIn(employee, startTime).Should().BeTrue();
        }
    }

    public class ShiftBuilder
    {
        private long _employeeId = 1;
        private DateTime _endTime = DateTime.Now.AddHours(-4);
        private DateTime _startTime = DateTime.Now.AddHours(-12);

        public ShiftBuilder WithEmployee(long employeeId)
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
            return new Shift(_startTime, _endTime, _employeeId);
        }
    }
}