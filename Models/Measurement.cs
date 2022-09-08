using System;

namespace HWork.Models
{
    public class Measurement
    {
        public Measurement(DateTime measurementTime, MeasurementType type, double measurementValue)
        {
            MeasurementTime = measurementTime;
            Type = type;
            MeasurementValue = measurementValue;
        }
        public Measurement()
        {
        }

        public DateTime MeasurementTime { get; set; }
        public MeasurementType Type { get; set; }
        public double MeasurementValue { get; set; }

        public string Stringify() 
        {
            var result = $"{MeasurementTime}, {Type}, {MeasurementValue}";
            return result;
        }
    }
}
