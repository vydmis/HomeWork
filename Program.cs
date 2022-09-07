using HWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HWork
{
    class Program
    {
        static void Main(string[] args)
        {
            IMeasurementsWorker measurementsWorker = new MeasurementsWorker();

            var sampledList = measurementsWorker.SampleMeasurements(DateTime.Parse("2017 - 01 - 03T10: 02:00"), CreateInputs());

            ShowResults(sampledList);
        }

        private static void ShowResults(List<Measurement> measurementsList)
        {
            foreach (var item in measurementsList)
                Console.WriteLine(item.MeasurementTime + ", " + item.Type.ToString() + ", " + item.MeasurementValue);
        }

        private static List<Measurement> CreateInputs()
        {
            List<Measurement> measurementsList = new List<Measurement>();

            measurementsList.Add(new Measurement()
            {
                MeasurementTime = DateTime.Parse("2017 - 01 - 03T10: 04:45"),
                Type = MeasurementType.TEMP,
                MeasurementValue = 35.79
            });
            measurementsList.Add(new Measurement()
            {
                MeasurementTime = DateTime.Parse("2017 - 01 - 03T10: 01:18"),
                Type = MeasurementType.SPO2,
                MeasurementValue = 98.78
            });
            measurementsList.Add(new Measurement()
            {
                MeasurementTime = DateTime.Parse("2017 - 01 - 03T10: 09:07"),
                Type = MeasurementType.TEMP,
                MeasurementValue = 35.01
            });
            measurementsList.Add(new Measurement()
            {
                MeasurementTime = DateTime.Parse("2017 - 01 - 03T10: 03:34"),
                Type = MeasurementType.SPO2,
                MeasurementValue = 96.49
            });
            measurementsList.Add(new Measurement()
            {
                MeasurementTime = DateTime.Parse("2017 - 01 - 03T10: 02:01"),
                Type = MeasurementType.TEMP,
                MeasurementValue = 35.82
            });
            measurementsList.Add(new Measurement()
            {
                MeasurementTime = DateTime.Parse("2017 - 01 - 03T10: 05:00"),
                Type = MeasurementType.SPO2,
                MeasurementValue = 97.17
            });
            measurementsList.Add(new Measurement()
            {
                MeasurementTime = DateTime.Parse("2017 - 01 - 03T10: 05:01"),
                Type = MeasurementType.SPO2,
                MeasurementValue = 95.08
            });

            return measurementsList;
        }
    }
}
