using PoESplitTool;
using System.ComponentModel;
using System.Text.Json.Serialization;

public class ZoneTime : ObservableObject
{

    private TimeSpan elapsed;
    private DateTime? startTime;
    private DateTime? endTime;
    private TimeSpan personalBest;
    public TimeSpan PersonalBest
    {
        get => personalBest;
        set => SetProperty(ref personalBest, value);
    }
    public Zone Zone { get; set; }
    [JsonIgnore]
    public string ZoneName => Zone.Name;
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
    
    public ZoneTime(Zone zone, DateTime startTime, TimeSpan? splitTime, TimeSpan? personalBest = null)
    {
        Zone = zone;
        StartTime = startTime;
        Notes = zone.Notes;
        var buildZoneNotes = Builds.LADeadeye.ZoneBuildNotes.Where(x => x.ZoneName == zone.Name).FirstOrDefault();
        BuildNotes = buildZoneNotes != null ? buildZoneNotes.Notes : "";
        SplitTime = splitTime;
        PersonalBest = personalBest ?? TimeSpan.Zero;
    }
}
