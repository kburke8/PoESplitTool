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
                    Notes = "copy regex"
                },
                new ZoneBuildNote
                {
                    ZoneName = "Lioneye's Watch",
                    Notes = "Take Galvanic Arrow. Buy MS Boots/Serrated Quiv/3-G"
                },
                new ZoneBuildNote
                {
                    ZoneName = "The Tidal Island",
                    Notes = "Take Sniper's Mark, Dash, Mirage Archer. Buy War Banner."
                },
                new ZoneBuildNote
                {
                    ZoneName = "The Lower Prison",
                    Notes = "Buy Frostblink?"
                },
                new ZoneBuildNote
                {
                    ZoneName = "The Upper Prison",
                    Notes = "Take Blink Arrow, Manaforged Arrow. Add Cold Damage."
                },
                new ZoneBuildNote
                {
                    ZoneName = "The Cavern of Wrath",
                    Notes = "Take Lightning Arrow. Buy LMP, Sapphire Ring."
                },
            }
        };
        public static List<Build> BuildsList = new List<Build>() { LADeadeye };

    }
}
