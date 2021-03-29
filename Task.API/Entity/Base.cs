using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Entity
{
    public class Base
    {
        public TradeHistory Body { get; set; }
        public int ResultCode { get; set; }
        public string ResultDescription { get; set; }
    }
}
