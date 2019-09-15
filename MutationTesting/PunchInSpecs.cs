using System;
using BusinessLogic;
using FluentAssertions;
using Xunit;

namespace MutationTesting
{
    public class PunchInSpecs
    {
        [InlineData(15, true)]
        [InlineData(-15, false)]
        [InlineData(0, true)]
        [Theory]
        public void CanPunchInForSpecificDate(double punchInDelay, bool expectedResult)
        {
            var startTime = new DateTime(2019,1,1,14,00,00);
            var endTime = new DateTime(2019,1,1,20,00,00);
            var shift = new Shift(startTime, endTime, 1, 1);

            var punchInTime = startTime.AddMinutes(punchInDelay);

            shift.CanPunchIn(punchInTime).Should().Be(expectedResult);
        }
    }
}