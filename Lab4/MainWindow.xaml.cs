using KMA.ProgrammingInCSharp2020.Lab4.ViewModels;
using System.Windows;

namespace KMA.ProgrammingInCSharp2020.Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           DataContext = new MainWindowViewModel();
        }
    }
}
