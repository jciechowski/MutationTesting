using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Department
    {
        private ICollection<long> Membership { get; }

        public Department()
        {
            Membership = new List<long> {1, 2, 3, 4};
        }

        public bool IsMember(long employeeId)
        {
            return Membership.Any(member => member == employeeId);
        }
    }
}