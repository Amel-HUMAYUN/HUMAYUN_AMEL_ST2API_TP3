using System;
using System.Collections.Generic;
using System.Text;

namespace HUMAYUN_AMEL_ST2API_TP2
{
    public class List
    {
        public double dt { get; set; }
        public Ma2 main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds2 clouds { get; set; }
        public Wind2 wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; }
        public Sys2 sys { get; set; }
        public string dt_txt { get; set; }
    }
}
