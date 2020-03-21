using KMA.ProgrammingInCSharp2020.Lab4.Models;

namespace KMA.ProgrammingInCSharp2020.Lab4.Tools.Managers
{
    internal static class SelectionManager
    {
        private static Person _selectedPerson;


        internal static Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; }
        }
       

    }
}
