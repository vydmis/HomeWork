using HWork.Models;
using System;
using System.Collections.Generic;

namespace HWork
{
    public interface IMeasurementsWorker
    {
        List<Measurement> SampleMeasurements(DateTime startOfSampling, List<Measurement> unsampledMeasurements);
    }
}