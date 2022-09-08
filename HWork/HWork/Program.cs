using HWork.Models;
using System;
using System.Collections.Generic;

namespace HWork
{
    class Program
    {
        static void Main(string[] args)
        {
            IMeasurementsWorker measurementsWorker = new MeasurementsWorker();
            InputsData inputsData = new InputsData();

            var sampledList = measurementsWorker.SampleMeasurements(DateTime.Parse("2017 - 01 - 03T10: 02:00"), inputsData.CreateInputs());

            ShowResults(sampledList);
        }

        private static void ShowResults(List<Measurement> measurementsList)
        {
            foreach (var item in measurementsList)
                Console.WriteLine(item.MeasurementTime + ", " + item.Type.ToString() + ", " + item.MeasurementValue);
        }
    }
}
