using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DetalleDeLlamadas
    {
        public int CallDetailId { get; set; }
        public string MobileLine { get; set; }
        public string CalledPartyNumber { get; set; }
        public string CalledPartyDescription { get; set; }
        public string DateTime { get; set; }
        public string HourTime { get; set; }
        public int Duration { get; set; }
        public float TotalCost { get; set; }
        public ML.LineasCelulares LineasCelulares { get; set; }

    }
}
