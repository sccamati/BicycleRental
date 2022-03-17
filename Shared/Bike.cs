using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared
{
    public class Bike
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public Type Type { get; set; }
        public bool IsBorrowed { get; set; }
        public int ProductionDate { get; set; }
    }
}
