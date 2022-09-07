using HWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HWork
{
    public class MeasurementsWorker : IMeasurementsWorker
    {

        public List<Measurement> SampleMeasurements(DateTime startOfSampling, List<Measurement> unsampledMeasurements)
        {
            // your implementation here
            var sampledMeasurements = new Dictionary<MeasurementType, List<Measurement>>();

            var groupedListByTime = GetGroupedMeasurementsByTime(startOfSampling, unsampledMeasurements);

            var sampledMeasurementsList = GetSampledMeasurementsList(groupedListByTime);

            return sampledMeasurementsList.OrderBy(x => x.Type).ToList();
        }

        private List<MeasurementsByTime> GetGroupedMeasurementsByTime(DateTime startOfSampling, List<Measurement> unsampledMeasurements)
        {
            var groupedListByTime = unsampledMeasurements.Where(x => x.MeasurementTime > startOfSampling).GroupBy(x =>
            {
                var stamp = x.MeasurementTime;
                stamp = stamp.AddMinutes(-(stamp.Minute % 5 == 0 && stamp.Second == 0 ? stamp.Minute : stamp.Minute % 5));
                stamp = stamp.AddMilliseconds(-stamp.Millisecond - 1000 * stamp.Second);
                return stamp;
            })
            .Select(g => new MeasurementsByTime()
            {
                TimeStamp = g.Key,
                Measurements = g
                  .Select(x => x).ToList()
            })
            .ToList();

            return groupedListByTime;
        }

        private List<Measurement> GetGroupedMeasurementsByType(MeasurementsByTime measurementByTime)
        {
            var measurementsList = measurementByTime.Measurements.GroupBy(x => x.Type)
                .ToDictionary(group => group.Key, group => group.OrderBy(x => x.MeasurementTime).LastOrDefault()).Values.ToList();
            return measurementsList;
        }

        private List<Measurement> GetSampledMeasurementsList(List<MeasurementsByTime> measurementsByTime)
        {
            var sampledMeasurementsList = new List<Measurement>();

            foreach (var item in measurementsByTime)
            {
                var measurements = GetGroupedMeasurementsByType(item);

                foreach (var measurement in measurements)
                {
                    measurement.MeasurementTime = item.TimeStamp;
                    measurement.MeasurementTime = measurement.MeasurementTime.AddMinutes(5);
                    sampledMeasurementsList.Add(measurement);
                }
            }

            return sampledMeasurementsList;
        }
    }
}
