using PoESplitTool;
using System.Windows;

namespace PoESplitTimer
{
    public partial class MainWindow : Window
    {
        public Run currentRun;
        private TimerManager timerManager;
        private LogParser logParser;

        public MainWindow()
        {
            InitializeComponent();
            timerManager = new TimerManager();
            currentRun = new Run(timerManager);
            this.DataContext = new MainWindowViewModel() { CurrentRun = currentRun};

            InitializeTimerDisplay();

            logParser = new LogParser("C:\\Source\\PoESplitTool\\client.txt"); // Set the path to your PoE log file
            logParser.OnZoneChanged += LogParser_OnZoneChanged;
            logParser.StartMonitoring();

            timerManager.TimerTicked += UpdateTimerDisplay;
        }

        // Event handlers for UI elements (e.g., buttons for starting/stopping runs, file operations, etc.)
        private void InitializeTimerDisplay()
        {
            txtTimer.Text = "0:00:00"; // Setting the initial display to 0:00:00
        }

        private void LogParser_OnZoneChanged(string zoneName)
        {
            Dispatcher.Invoke(() =>
            {
                if (currentRun.IsRunning)
                {
                    currentRun.AddZone(zoneName);
                }
            });
        }

        private void UpdateTimerDisplay(TimeSpan elapsed)
        {
            //Update the timer display, HH:MM:SS:SS
            txtTimer.Text = $"{elapsed.Hours}:{elapsed.Minutes}:{elapsed.Seconds}:{elapsed.Milliseconds / 10}";

        }
        private void btnStartRun_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the start run event
            currentRun.Start();
            // Additional logic as needed
        }

        private void btnStopRun_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the stop run event
            currentRun.Stop();
            // Additional logic as needed
        }

        private void btnResumeRun_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the stop run event
            currentRun.Resume();
            // Additional logic as needed
        }

        private void btnResetRun_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the reset run event
            currentRun.Reset();
            // Additional logic as needed
        }

        private void btnSetPath_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle setting the log path
            // For example, opening a file dialog to select a file
        }

        private void btnSaveZones_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle saving zones
            // For example, saving zone data to a file
        }

        private void btnLoadZones_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle loading zones
            // For example, loading zone data from a file
        }
    }
}
