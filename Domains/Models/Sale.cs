using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Models
{
    public class Sale
    {
        public int Vendedor { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }

    }
}
