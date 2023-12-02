using PoESplitTool;
using System.ComponentModel;

public class ZoneTime : ObservableObject
{

    private TimeSpan elapsed;
    private DateTime? startTime;
    private DateTime? endTime;

    public string ZoneName { get; set; }
    public string Notes { get; set; }

    public string BuildNotes { get; set; }

    public TimeSpan Elapsed
    {
        get => elapsed;
        set => SetProperty(ref elapsed, value);
    }

    public TimeSpan? SegmentTime => EndTime != null && StartTime != null ? EndTime - StartTime : null;
    public TimeSpan? SplitTime { get; set; }

    public DateTime? StartTime
    {
        get => startTime;
        set => SetProperty(ref startTime, value);
    }

    public DateTime? EndTime
    {
        get => endTime;
        set  {
            SetProperty(ref endTime, value);
            OnPropertyChanged(nameof(SegmentTime));
        }
    }

    public ZoneTime(string zoneName, DateTime startTime, string notes, TimeSpan? splitTime)
    {
        ZoneName = zoneName;
        StartTime = startTime;
        Notes = notes;
        var buildZoneNotes = Builds.LADeadeye.ZoneBuildNotes.Where(x => x.ZoneName == zoneName).FirstOrDefault();
        BuildNotes = buildZoneNotes != null ? buildZoneNotes.Notes : "";
        SplitTime = splitTime;
    }
}
