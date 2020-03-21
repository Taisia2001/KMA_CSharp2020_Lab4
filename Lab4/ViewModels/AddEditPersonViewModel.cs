using KMA.ProgrammingInCSharp2020.Lab4.Models;
using KMA.ProgrammingInCSharp2020.Lab4.Tools;
using KMA.ProgrammingInCSharp2020.Lab4.Tools.Managers;
using KMA.ProgrammingInCSharp2020.Lab4.Tools.MVVM;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.ProgrammingInCSharp2020.Lab4.ViewModels
{
    class AddEditPersonViewModel : BaseViewModel
    {
        #region Fields
        private Person _person = null;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _date;
        private RelayCommand<ICloseable> _submitCommand;
        private RelayCommand<ICloseable> _cancelCommand;
        #endregion

        #region Properties

        public DateTime? Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
 
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }



        public RelayCommand<ICloseable> SubmitCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand<ICloseable>(
                           SubmitImplementation, o => CanExecuteCommand()));
            }
        }
        public RelayCommand<ICloseable> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<ICloseable>(CancelImplementation));
            }
            private set
            {
                _cancelCommand = value;
            }
                
        }

        private void CancelImplementation(ICloseable obj)
        {
            if (obj != null)
            {
               obj.Close();
            }
        }
        #endregion

        

        internal AddEditPersonViewModel()
        {
            if (SelectionManager.SelectedPerson != null)
            {
                Person = SelectionManager.SelectedPerson;
                Name = _person.Name;
                Surname = _person.Surname;
                Email = _person.Email;
                Date = _person.Date;
            }
        }


        private async void SubmitImplementation(ICloseable obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool happen = false;
            await Task.Run(() =>
            {
                try
                {
                    if (MessageBox.Show("Submit changes?", "Save?",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        Person res = new Person(Name, Surname, Email, (DateTime)Date);
                        if (_person == null)
                        {
                            StationManager.DataStorage.AddPerson(ref res);
                        }
                        else
                        {
                            StationManager.DataStorage.EditPerson(ref _person, ref res);
                        }
                        
                    }
                    happen = true;
                    LoaderManager.Instance.HideLoader();              
                }
                catch (Exception e)
                {
                    LoaderManager.Instance.HideLoader();
                    MessageBox.Show(e.Message);
                }

            });
            if(happen)
            obj.Close();

        }
        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname)&& Date !=null;
        }
    }
}
