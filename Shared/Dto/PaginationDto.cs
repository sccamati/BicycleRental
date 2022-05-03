using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared.Dto
{
    public class PaginationDto
    {
        public int Page { get; set; }
        public int QuantityPerPage { get; set; }
    }
}
