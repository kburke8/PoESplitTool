using System;
using System.Windows.Threading;

namespace PoESplitTimer
{
    public class TimerManager
    {
        private const int TimerInterval = 10;
        public DispatcherTimer Timer { get; private set; }
        private int TickCount { get; set; }
        private bool IsReset { get; set; }
        public TimeSpan Elapsed => IsReset ? TimeSpan.Zero : DateTime.Now - StartTime - PauseTime;
        public DateTime StartTime { get; private set; }
        public TimeSpan PauseTime => Pauses.Count > 0 ? Pauses.Select(x => (x.End ?? DateTime.Now)- x.Start)?.Aggregate((x, y) => x + y) ?? TimeSpan.Zero : TimeSpan.Zero;
        private List<(DateTime Start, DateTime? End)> Pauses { get; set; } = new List<(DateTime Start, DateTime? End)>(); // Pauses are stored as a list of tuples, where each tuple is a start and end time for a pause
        public event Action<TimeSpan> TimerTicked;

        public TimerManager()
        {
            Timer = new DispatcherTimer(priority: DispatcherPriority.Send);
            Timer.Interval = TimeSpan.FromMilliseconds(TimerInterval);
            Timer.Tick += (s, e) =>
            {

                var now = DateTime.Now;
                var nowMilliseconds = (int)now.TimeOfDay.TotalMilliseconds;
                var timerInterval = TimerInterval -
                 nowMilliseconds % TimerInterval;//5: sometimes the tick comes few millisecs early
                Timer.Interval = TimeSpan.FromMilliseconds(timerInterval);
                TickCount++;
                TimerTicked?.Invoke(Elapsed);
            };
        }

        public void StartTimer()
        {
            StartTime = DateTime.Now;
            Pauses.Clear();
            Timer.Start();
            TickCount = 0;
            IsReset = false;

        }

        public void ResumeTimer()
        {
            var now = DateTime.Now;
            var pause = Pauses.Last();
            pause.End = now;
            Pauses[Pauses.Count - 1] = pause;
            Timer.Start();
            TickCount = 0;
        }

        public void ResetTimer()
        {
            IsReset = true;
            Timer.Stop();
            StartTime = DateTime.Now;
            TickCount = 0;
            Pauses.Clear();
            TimerTicked?.Invoke(Elapsed);
        }

        public void StopTimer()
        {
            var now = DateTime.Now;
            var pause = (now, (DateTime?) null);
            Pauses.Add(pause);
            Timer.Stop();
        }
    }
}
