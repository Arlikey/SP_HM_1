using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _refreshTimer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            RefreshProcessList();
        }

        private void InitializeTimer()
        {
            _refreshTimer = new DispatcherTimer();
            _refreshTimer.Tick += (s, e) => RefreshProcessList();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IntervalTextBox.Text, out int interval) && interval > 0)
            {
                _refreshTimer.Interval = TimeSpan.FromSeconds(interval);
                _refreshTimer.Start();
            }
            RefreshProcessList();
        }

        private void RefreshProcessList()
        {
            var processes = Process.GetProcesses()
                                   .OrderBy(p => p.ProcessName)
                                   .Select(p => new { p.ProcessName, p.Id })
                                   .ToList();
            ProcessListView.ItemsSource = processes;
        }

        private void ProcessListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Process process = Process.GetProcessById((ProcessListView.SelectedItem as dynamic).Id);
            var details = new StringBuilder();

            details.AppendLine($"ID: {process.Id}");
            details.AppendLine($"Start Time: {process.StartTime}");
            details.AppendLine($"Total Processor Time: {process.TotalProcessorTime}");
            details.AppendLine($"Thread Count: {process.Threads.Count}");
            details.AppendLine($"Instance Count: {Process.GetProcessesByName(process.ProcessName).Length}");

            ProcessDetailsTextBlock.Text = details.ToString();
        }
    }
}