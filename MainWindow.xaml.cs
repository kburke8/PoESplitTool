using PoESplitTool;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using Microsoft.Win32;
using System.Text.Json;
using System.IO;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PoESplitTimer
{
    public partial class MainWindow : Window
    {
        public Run currentRun;
        private Build currentBuild;
        public Build CurrentBuild
        {
            get => currentBuild;
            //override set to handle historical data for runs
            set
            {
                currentBuild = value;
                foreach (var run in currentBuild.Act1Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act2Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act3Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act4Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act5Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act6Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act7Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act8Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime);
                    }
                }
                foreach (var run in currentBuild.Act9Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime); 
                    }
                }
                foreach (var run in currentBuild.Act10Runs)
                {
                    foreach (var zoneTime in run.ZoneTimes)
                    {
                        currentRun.HistoricalZoneTimes.Add(zoneTime.ZoneName, zoneTime); 
                    }
                }
            }
        }
        private TimerManager timerManager;
        private LogParser logParser;

        public MainWindow()
        {
            InitializeComponent();
            timerManager = new TimerManager();
            currentRun = new Run(timerManager);
            CurrentBuild = Builds.LADeadeye;
            this.DataContext = new MainWindowViewModel() { CurrentRun = currentRun };

            InitializeTimerDisplay();

            logParser = new LogParser("C:\\Source\\PoESplitTool\\client.txt"); // Set the path to your PoE log file
            //logParser = new LogParser("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Path of Exile\\logs\\client.txt"); // Set the path to your PoE log file
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
                if (ShouldAddZoneTime(zoneName))
                {
                    currentRun.AddZone(zoneName);
                }
                if (zoneName == ZoneData.Act2Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act1Runs);
                }
                else if (zoneName == ZoneData.Act3Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act2Runs);
                }
                else if (zoneName == ZoneData.Act4Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act3Runs);
                }
                else if (zoneName == ZoneData.Act5Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act4Runs);
                }
                else if (zoneName == ZoneData.Act6Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act5Runs);
                }
                else if (zoneName == ZoneData.Act7Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act6Runs);
                }
                else if (zoneName == ZoneData.Act8Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act7Runs);
                }
                else if (zoneName == ZoneData.Act9Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act8Runs);
                }
                else if (zoneName == ZoneData.Act10Zones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act9Runs);
                }
                else if (zoneName == ZoneData.EpilogueZones[0].Name)
                {
                    CurrentBuild.AddRun(currentRun, CurrentBuild.Act10Runs);
                }

                bool ShouldAddZoneTime(string zoneName)
                {
                    var zone = ZoneData.Zones.FirstOrDefault(z => z.Name == zoneName
                        && (z.Act == currentRun.CurrentAct || z.Act == currentRun.CurrentAct + 1 || z.Act == currentRun.CurrentAct - 1));

                    return zone != null
                    && currentRun.IsRunning
                    && !currentRun.ZoneTimes.Any(x => x.ZoneName == zone.Name);
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
            // Additional logic as needed
            StartRun();
        }

        private void btnStopRun_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the stop run event
            // Additional logic as needed
            StopRun();
        }

        private void btnResumeRun_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the stop run event
            // Additional logic as needed
            ResumeRun();
        }

        private void btnResetRun_Click(object sender, RoutedEventArgs e)
        {
            // Logic to handle the reset run event
            currentRun.Reset();
            // Additional logic as needed
        }

        private void btnSetPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Set the filter for log files
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86); // Starting directory

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                logParser.SetLogFilePath(selectedFilePath);
            }
        }
        private void btnSaveZones_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = $"{CurrentBuild.Name}-v1.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                // Logic to save the zone data to the file
                // This might involve serializing your zone data and writing it to the file
                SaveZoneDataToFile(filePath);
            }
        }

        private void SaveZoneDataToFile(string filePath)
        {
            string jsonData = JsonConvert.SerializeObject(CurrentBuild);
            File.WriteAllText(filePath, jsonData);
        }
        private void btnLoadZones_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.FileName = $"{CurrentBuild.Name}-v1.json";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                // Logic to load the zone data from the file
                LoadZoneDataFromFile(filePath);
            }
        }

        private void LoadZoneDataFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                try
                {
                    CurrentBuild = JsonConvert.DeserializeObject<Build>(jsonData);
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }


        private void StartRun()
        {
            // Logic for starting the run
            currentRun.Start();
        }

        private void StopRun()
        {
            // Logic for stopping the run
            currentRun.Stop();
        }

        private void ResumeRun()
        {
            // Logic for resuming the run
            currentRun.Resume();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (!currentRun.IsRunning && currentRun.Elapsed.TotalSeconds == 0)
                {
                    StartRun();
                }
                else if (currentRun.IsRunning)
                {
                    StopRun();
                }
                else if (!currentRun.IsRunning && currentRun.Elapsed.TotalSeconds > 0)
                {
                    ResumeRun();
                }
            }
        }

    }
}
