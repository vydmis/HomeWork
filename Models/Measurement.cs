using System;

namespace HWork.Models
{
    public class Measurement
    {
        public DateTime MeasurementTime { get; set; }
        public MeasurementType Type { get; set; }
        public double MeasurementValue { get; set; }
    }
}
