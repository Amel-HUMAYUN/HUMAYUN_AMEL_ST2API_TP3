 using System;
using System.Collections.Generic;
using System.Text;

namespace HUMAYUN_AMEL_ST2API_TP2
{
    public class Root
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string @base { get; set; }
        public Main Main { get; set; }
        public int visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
