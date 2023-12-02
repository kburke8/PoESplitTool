using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PoESplitTimer
{
    public class Run : ObservableObject
    {
        [JsonIgnore]
        private TimerManager timerManager;

        [JsonIgnore]
        private ObservableCollection<ZoneTime> zoneTimes;
        public ObservableCollection<ZoneTime> ZoneTimes
        {
            get => zoneTimes;
            set => SetProperty(ref zoneTimes, value);
        }
        public Dictionary<string, ZoneTime> HistoricalZoneTimes { get; set; } = new Dictionary<string, ZoneTime>();

        [JsonIgnore]
        private bool isRunning;
        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }

        [JsonIgnore]
        private TimeSpan elapsed;
        public TimeSpan Elapsed
        {
            get => elapsed;
            set => SetProperty(ref elapsed, value);
        }

        public int CurrentAct { get; set; } = 1;
        public Zone? CurrentZone { get; set; } = null;

        [JsonIgnore]
        public TimeSpan CityTime => ZoneTimes.Where(x => x.Zone.IsCity).Aggregate(TimeSpan.Zero, (x, y) => x + y.SegmentTime ?? TimeSpan.Zero);

        public Run() { 
        }
        public Run(TimerManager timerManager)
        {
            this.timerManager = timerManager;
            IsRunning = false;
            ZoneTimes = new ObservableCollection<ZoneTime>();
            this.timerManager.TimerTicked += UpdateZoneTime;
        }

        private void UpdateZoneTime(TimeSpan elapsed)
        {
            if (ZoneTimes.Count > 0)
            {
                ZoneTimes[ZoneTimes.Count - 1].Elapsed = elapsed;
            }
            Elapsed = elapsed;
        }

        public void Start()
        {
            ZoneTimes.Clear();
            CurrentZone = ZoneData.Zones.FirstOrDefault(z => z.Name == "The Twilight Strand" && z.Act == 1);
            ZoneTimes.Add(new ZoneTime(CurrentZone, DateTime.Now, TimeSpan.Zero));
            IsRunning = true;
            timerManager.StartTimer();
        }
        public void Reset()
        {
            timerManager.ResetTimer();
            IsRunning = false;
            ZoneTimes.Clear();
        }
        public void Stop()
        {
            timerManager.StopTimer();
            IsRunning = false;
        }

        public void Resume()
        {
            timerManager.ResumeTimer();
            IsRunning = true;
        }

        public void Finish()
        {
            timerManager.StopTimer();
            IsRunning = false;
        }

        public void AddZone(string zoneName)
        {
            var zone = ZoneData.Zones.FirstOrDefault(z => z.Name == zoneName);
            if (zone == null)
            {
                return;
            }
            ZoneTimes.Add(new ZoneTime(zone, DateTime.Now, timerManager.Elapsed));
            var currentZoneTime = ZoneTimes.Last(x=>x.ZoneName == CurrentZone.Name);
            currentZoneTime.EndTime = DateTime.Now;
            CurrentZone = ZoneData.Zones.FirstOrDefault(z => z.Name == zoneName);
            if (CurrentZone.Act > CurrentAct)
            {
                CurrentAct = CurrentZone.Act;
            }
        }
    }
}
