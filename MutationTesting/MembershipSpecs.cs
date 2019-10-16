using BusinessLogic;
using FluentAssertions;
using Xunit;

namespace MutationTesting
{
    public class MembershipSpecs
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(-1, false)]
        public void RecognizeDepartmentMembership(long employeeId, bool correctMembership)
        {
            var department = new Department();
            var employee = new Employee(employeeId);

            department.IsMember(employee.Id).Should().Be(correctMembership);
        }
    }
}