using System.Collections.Generic;

namespace RecapApp
{
    public class SessionInfo
    {
        public WeekendInfoData WeekendInfo { get; set; }
        public DriverInfoData DriverInfo { get; set; }

        public class WeekendInfoData
        {
            public string TrackDisplayName { get; set; }
            public int TrackID { get; set; }

            public WeekendOptionsData WeekendOptions { get; set; }
        }

        public class WeekendOptionsData
        {
            public int NumStarters { get; set; }
            public string StartingGrid { get; set; }
        }

        public class DriverInfoData
        {
            public int DriverCarIdx { get; set; }
            public List<DriverData> Drivers { get; set; }
        }

        public class DriverData
        {
            public int CarIdx { get; set; }
            public string UserName { get; set; }
        }
    }
}
