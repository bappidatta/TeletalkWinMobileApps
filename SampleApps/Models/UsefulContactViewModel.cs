using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApps.Models
{
    public class UsefulContactViewModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Charge { get; set; }

        public string DialCode { get; set; }
        public string MessageBody { get; set; }
        public string MessageSento { get; set; }

        public string IsVisible { get; set; }
        public string SetWidth { get; set; }
    }
}
