using PoESplitTimer;
using System;
using System.ComponentModel;

namespace PoESplitTool
{
    public class MainWindowViewModel : ObservableObject
    {
        private Run currentRun;

        public Run CurrentRun
        {
            get => currentRun;
            set
            {
                currentRun = value;
                SetProperty(ref currentRun, value);
            }
        }
    }
}
