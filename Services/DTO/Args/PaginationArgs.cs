using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Args
{
    public class PaginationArgs
    {
        public int Limit { get; set; } = 10;
        public int Offset { get; set; } = 0;
    }
}
