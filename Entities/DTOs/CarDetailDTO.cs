using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDTO:IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public int FindeksPoint { get; set; }

        public List<CarImage> CarImages { get; set; }
    }
}
