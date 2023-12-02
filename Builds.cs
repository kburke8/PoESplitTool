using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoESplitTool
{
    public static class Builds
    {
        public static Build LADeadeye = new Build
        {
            Name = "LA Deadeye",
            Class = PoEClass.Ranger,
            Ascendancy = PoEAscendancy.Deadeye,
            Notes = "Notes",
            ZoneBuildNotes = new List<ZoneBuildNote>
            {
                new ZoneBuildNote
                {
                    ZoneName = "The Twilight Strand",
                    Notes = "Make sure you pick up momentum"
                }
            }
        };
        public static List<Build> BuildsList = new List<Build>() { LADeadeye };

    }
}
