using FluentAssertions;
using HWork.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HWork.Tests
{
    [TestFixture]
    public class MeasurementsWorkerTests
    {
        [Test]
        public void SampleMeasurements_WithProvidedData_GiveExpectedResults()
        {
            //ARRANGE

            var inputData = new InputsData();
            var measurementsWorker = new MeasurementsWorker();
            var expectedDataList = new List<Measurement>()
            {
                new Measurement(new DateTime(2017,01,03,10,05,00), MeasurementType.TEMP, 35.79),
                new Measurement(new DateTime(2017,01,03,10,10,00), MeasurementType.TEMP, 35.01),
                new Measurement(new DateTime(2017,01,03,10,05,00), MeasurementType.SPO2, 97.17),
                new Measurement(new DateTime(2017,01,03,10,10,00), MeasurementType.SPO2, 95.08)
            };

            var expectedStringList = expectedDataList.Select(x => x.Stringify()).ToList();

            //ACT

            var results = measurementsWorker.SampleMeasurements(DateTime.Parse("2017 - 01 - 03T10: 02:00"), inputData.CreateInputs());

            //ASSERT
            results.Count.Should().Be(expectedDataList.Count);

            results.Should().AllSatisfy(x =>
            {
                expectedStringList.Contains(x.Stringify());
            });
        }
    }
}
