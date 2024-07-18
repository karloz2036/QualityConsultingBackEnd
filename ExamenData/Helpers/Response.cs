using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.Helpers
{
    public class Response
    {
        public Data? Data { get; set; }
        public string? IsCorrect { get; set; }
        public string? IsBreakOperation { get; set; }
        public string? Message { get; set; }
        public int TotalRegistros { get; set; }
    }
}
