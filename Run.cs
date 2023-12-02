using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PoESplitTimer
{
    public class Run : ObservableObject
    {
        private TimerManager timerManager;

        private ObservableCollection<ZoneTime> zoneTimes;
        public ObservableCollection<ZoneTime> ZoneTimes
        {
            get => zoneTimes;
            set => SetProperty(ref zoneTimes, value);
        }
        private bool isRunning;
        public bool IsRunning
        {
            get => isRunning;
            set => SetProperty(ref isRunning, value);
        }

        private TimeSpan elapsed;
        public TimeSpan Elapsed
        {
            get => elapsed;
            set => SetProperty(ref elapsed, value);
        }


        public Zone? CurrentZone = null;

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
            ZoneTimes.Add(new ZoneTime(CurrentZone.Name, DateTime.Now, CurrentZone.Notes, TimeSpan.Zero));
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

        public void AddZone(string zoneName)
        {
            var zone = ZoneData.Zones.FirstOrDefault(z => z.Name == zoneName);
            if (zone == null)
            {
                return;
            }
            ZoneTimes.Add(new ZoneTime(zone.Name, DateTime.Now, zone.Notes, timerManager.Elapsed));
            var currentZoneTime = ZoneTimes.Last(x=>x.ZoneName == CurrentZone.Name);
            currentZoneTime.EndTime = DateTime.Now;
            CurrentZone = ZoneData.Zones.FirstOrDefault(z => z.Name == zoneName);
        }
    }
}
