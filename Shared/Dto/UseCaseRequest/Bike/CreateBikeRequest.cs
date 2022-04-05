using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared.Dto.UseCaseRequest.Bike
{
    public class CreateBikeRequest
    {
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public int ProductionDate { get; set; }
        public BikesType BikesType { get; set; }
    }
}
