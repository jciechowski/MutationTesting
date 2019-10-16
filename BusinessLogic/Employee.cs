namespace BusinessLogic
{
    public class Employee
    {
        public long Id { get; private set; }

        public Employee(long id)
        {
            Id = id;
        }
    }
}