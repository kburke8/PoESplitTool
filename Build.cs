using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoESplitTool
{
    public class Build
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Ascendancy { get; set; }
        public string Notes { get; set; }
        public List<ZoneBuildNote> ZoneBuildNotes { get; set; }
    }
}
