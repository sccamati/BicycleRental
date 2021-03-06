using BicycleRental.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared.Dto
{
    public class BikeDto : BaseEntity
    {
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public bool IsBorrowed { get; set; }
        public int ProductionDate { get; set; }
        public decimal PricePerHour { get; set; }
        public BikesTypeDto BikesType { get; set; }

    }
}
