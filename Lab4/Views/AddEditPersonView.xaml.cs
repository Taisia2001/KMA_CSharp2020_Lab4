using KMA.ProgrammingInCSharp2020.Lab4.Tools;
using KMA.ProgrammingInCSharp2020.Lab4.ViewModels;
using System.Windows;

namespace KMA.ProgrammingInCSharp2020.Lab4.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditPersonView.xaml
    /// </summary>
    public partial class AddEditPersonView : Window, ICloseable
    {
        public AddEditPersonView()
        {
            InitializeComponent();
            DataContext = new AddEditPersonViewModel();

        }

    }
}
