using KMA.ProgrammingInCSharp2020.Lab4.ViewModels;
using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp2020.Lab4.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonListView.xaml
    /// </summary>
    public partial class PersonListView :UserControl
    {
        public PersonListView()
        {
            InitializeComponent();
            DataContext = new PersonListViewModel();
        }
    }
}
