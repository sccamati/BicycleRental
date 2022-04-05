using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared.Dto.UseCaseResponse.Bike.Bike.Bike
{
    public class GetBikesReponse
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public bool IsBorrowed { get; set; }
        public int ProductionDate { get; set; }
        public BikesType BikesType { get; set; }
    }
}
