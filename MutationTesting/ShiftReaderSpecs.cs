using BusinessLogic;
using FluentAssertions;
using Xunit;

namespace MutationTesting
{
    public class ShiftReaderSpecs
    {
        [Fact]
        public void GetAllShiftsForEmployee()
        {
            var shiftReader = new ShiftReader();
            var employee = new Employee(1);

            var employeeShifts = shiftReader.GetShiftsForEmployee(employee);

            employeeShifts.Should().NotBeEmpty();
        }

        [Fact]
        public void ReturnsEmptyListForWrongEmployee()
        {
            var shiftReader = new ShiftReader();
            var employee = new Employee(-1);

            var shiftsForEmployee = shiftReader.GetShiftsForEmployee(employee);

            shiftsForEmployee.Should().BeEmpty();
        }
    }
}