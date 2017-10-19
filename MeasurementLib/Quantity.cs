using System;
using System.Collections.Generic;
using System.Text;

namespace MeasurementLib
{
    public class Quantity
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
