using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApps.Models
{
    public class VasViewModel
    {
        public string name { get; set; }
        public List<ChildViewModel> child { get; set; }
    }

    public class ChildViewModel
    {
        public string name { get; set; }
        public string url { get; set; }
        public string buttonText { get; set; }
        public string isVisible { get; set; }
    }
}
