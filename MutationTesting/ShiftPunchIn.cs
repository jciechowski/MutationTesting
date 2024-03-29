﻿using System;
using FluentAssertions;
using Xunit;

namespace MutationTesting
{
    public class ShiftPunchIn
    {
        private const int DefaultEmployeeId = 1;

        [Fact]
        public void IsForbiddenForWrongEmployee()
        {
            var otherEmployee = DefaultEmployeeId + 1;

            var shift = new ShiftBuilder()
                .WithEmployeeId(otherEmployee)
                .WithStartTime(DateTime.Now)
                .WithEndTime(DateTime.Now.AddHours(8))
                .Build();

            var punchInTime = DateTime.Now;
            shift.CanPunchIn(DefaultEmployeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenAfterShiftEnd()
        {
            var shift = new ShiftBuilder()
                .WithEmployeeId(DefaultEmployeeId)
                .WithStartTime(DateTime.Now)
                .WithEndTime(DateTime.Now.AddHours(8))
                .Build();

            var punchInTime = DateTime.Now.AddHours(12);

            shift.CanPunchIn(DefaultEmployeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsForbiddenBeforeShiftStart()
        {
            var shift = new ShiftBuilder()
                .WithEmployeeId(DefaultEmployeeId)
                .WithStartTime(DateTime.Now)
                .WithEndTime(DateTime.Now.AddHours(8)) 
                .Build();

            var punchInTime = DateTime.Now.AddHours(-1);

            shift.CanPunchIn(DefaultEmployeeId, punchInTime).Should().BeFalse();
        }

        [Fact]
        public void IsAllowedExactlyAtShiftStart()
        {
            var punchInTime = DateTime.Now.AddHours(-4);
            var startTime = punchInTime;

            var shift = new ShiftBuilder()
                .WithEmployeeId(DefaultEmployeeId)
                .WithStartTime(startTime)
                .Build();

            shift.CanPunchIn(DefaultEmployeeId, punchInTime).Should().BeTrue();
        }

        [Fact]
        public void IsForbiddenExactlyAtEndTime()
        {
            var punchInTime = DateTime.Now;
            var endTime = punchInTime;

            var shift = new ShiftBuilder()
                .WithEmployeeId(DefaultEmployeeId)
                .WithEndTime(endTime).Build();

            shift.CanPunchIn(DefaultEmployeeId, punchInTime).Should().BeFalse();
        }
    }
}