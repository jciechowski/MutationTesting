using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class Data
    {
        public static List<Shift> Shifts { get; } = new List<Shift>();

        static Data()
        {
            Shifts.AddRange(new List<Shift>
            {
                new Shift(DateTime.Parse("2019-10-01T10:00"),DateTime.Parse("2019-10-01T14:00"),1),
                new Shift(DateTime.Parse("2019-10-01T14:00"),DateTime.Parse("2019-10-01T18:00"),1),
                new Shift(DateTime.Parse("2019-10-01T10:00"),DateTime.Parse("2019-10-01T18:00"),2),
                new Shift(DateTime.Parse("2019-10-01T08:00"),DateTime.Parse("2019-10-01T14:00"),3)
            });
        }
    }
}