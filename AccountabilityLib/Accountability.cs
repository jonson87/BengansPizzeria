using MeasurementLib;

namespace AccountabilityLib
{
    public class Accountability
    {
        public int AccountabilityId { get; set; }
        public int AccountabilityTypeId { get; set; }
        public AccountabilityType AccountabilityType { get; set; }
        public int CommisionerId { get; set; }
        public Party Commissioner { get; set; }
        public int ResponsibleId { get; set; }
        public Party Responsible { get; set; }
        public int TimePeriodId { get; set; }
        public TimePeriod TimePeriod { get; set; }
    }
}
