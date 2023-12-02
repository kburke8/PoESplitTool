using PoESplitTimer;
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

        //List of runs for each act
        public List<Run> Act1Runs { get; set; } = new List<Run>();
        public List<Run> Act2Runs { get; set; } = new List<Run>();
        public List<Run> Act3Runs { get; set; } = new List<Run>();
        public List<Run> Act4Runs { get; set; } = new List<Run>();  
        public List<Run> Act5Runs { get; set; } = new List<Run>();
        public List<Run> Act6Runs { get; set; } = new List<Run>();
        public List<Run> Act7Runs { get; set; } = new List<Run>();
        public List<Run> Act8Runs { get; set; } = new List<Run>();
        public List<Run> Act9Runs { get; set; } = new List<Run>();
        public List<Run> Act10Runs { get; set; } = new List<Run>();

        public Build()
        {
        }

        // Method to add a new run to the build
        public void AddRun(Run run, List<Run> actList)
        {
            actList.Add(run);
            if (actList.Count > 20)
            {
                actList.RemoveAt(0); // Keep only the last 20 runs
            }
        }
    }
}
