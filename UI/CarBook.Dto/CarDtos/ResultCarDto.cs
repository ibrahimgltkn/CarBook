using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDtos
{
    public class ResultCarDto
    {
        public int carID { get; set; }
        public int brandID { get; set; }
        public string model { get; set; }
        public string coverImageUrl { get; set; }
        public int km { get; set; }
        public string transmission { get; set; }
        public int seat { get; set; }
        public int luggage { get; set; }
        public string fuel { get; set; }
        public string bıgImageUrl { get; set; }

    }
}
