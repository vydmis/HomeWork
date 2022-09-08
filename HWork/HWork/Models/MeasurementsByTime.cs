using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWork.Models
{
    public class MeasurementsByTime
    {
        public DateTime TimeStamp { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}
