﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplications.DataTransferObjects
{
    public class SaleRequestDTO
    {
        
        public int Vendedor { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }

    }
}
