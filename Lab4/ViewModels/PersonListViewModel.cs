using KMA.ProgrammingInCSharp2020.Lab4.Exceptions;
using KMA.ProgrammingInCSharp2020.Lab4.Models;
using KMA.ProgrammingInCSharp2020.Lab4.Tools;
using KMA.ProgrammingInCSharp2020.Lab4.Tools.DataStorage;
using KMA.ProgrammingInCSharp2020.Lab4.Tools.Managers;
using KMA.ProgrammingInCSharp2020.Lab4.Tools.MVVM;
using KMA.ProgrammingInCSharp2020.Lab4.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.ProgrammingInCSharp2020.Lab4.ViewModels
{
    class PersonListViewModel: BaseViewModel
    {
        #region Fields
        private ObservableCollection<Person> _persons;
        private Person _selectedPerson;
        #endregion

        #region Commands
        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _editCommand;
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _saveCommand;
        private RelayCommand<object> _sortName;
        private RelayCommand<object> _sortSurname;
        private RelayCommand<object> _sortEmail;
        private RelayCommand<object> _sortBirthday;
        private RelayCommand<object> _sortIsAdult;
        private RelayCommand<object> _sortIsBirthday;
        private RelayCommand<object> _sortSunSign;
        private RelayCommand<object> _sortChineseSign;
        #endregion

        #region FilterFields

        bool _adult;
        bool _child;
        bool _birthdayToday;
        bool _birthdayNotToday;
        bool _aquarius;
        bool _pisces;
        bool _aries;
        bool _taurus;
        bool _gemini;
        bool _cancer;
        bool _leo;
        bool _virgo;
        bool _libra;
        bool _scorpio;
        bool _sagittarius;
        bool _capricorn;
        bool _monkey;
        bool _rooster;
        bool _dog;
        bool _pig;
        bool _rat;
        bool _ox;
        bool _tiger;
        bool _rabbit;
        bool _dragon;
        bool _snake;
        bool _horse;
        bool _goat;
        bool _metal;
        bool _water;
        bool _wood;
        bool _fire;
        bool _earth;
        DateTime _dateFrom = DateTime.MinValue;
        DateTime _dateTo = DateTime.MaxValue;
        #endregion

        #region Properties
        public ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
            }
        }
         public RelayCommand<object> AddCommand
         {
             get
             {
                 return _addCommand ?? (_addCommand = new RelayCommand<object>(
                            AddCommandImplementation));
             }
         }

        

        public RelayCommand<object> EditCommand
         {
             get
             {
                 return _editCommand ?? (_editCommand = new RelayCommand<object>(
                            EditCommandImplementation, o => CanExecuteCommand()));
             }
         }


        public RelayCommand<object> DeleteCommand
         {
             get
             {
                 return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(
                            DeleteCommandImplementation, o => CanExecuteCommand()));
             }
         }

        

        public RelayCommand<object> SaveCommand
         {
             get
             {
                 return _saveCommand ?? (_saveCommand = new RelayCommand<object>(
                            SaveCommandImplementation));
             }
         }

      

        public RelayCommand<object> SortName
        {
            get
            {
                return _sortName ?? (_sortName = new RelayCommand<object>(o =>
                    SortImplementation(o, 0)));
            }
        }
        public RelayCommand<object> SortSurname
        {
            get
            {
                return _sortSurname ?? (_sortSurname = new RelayCommand<object>(o =>
                           SortImplementation(o, 1)));
            }
        }
        public RelayCommand<object> SortEmail
        {
            get
            {
                return _sortEmail ?? (_sortEmail = new RelayCommand<object>(o =>
                           SortImplementation(o, 2)));
            }
        }
        public RelayCommand<object> SortBirthday
        {
            get
            {
                return _sortBirthday ?? (_sortBirthday = new RelayCommand<object>(o =>
                           SortImplementation(o, 3)));
            }
        }
        public RelayCommand<object> SortSunSign
        {
            get
            {
                return _sortSunSign ?? (_sortSunSign = new RelayCommand<object>(o =>
                           SortImplementation(o, 4)));
            }
        }
        public RelayCommand<object> SortChineseSign
        {
            get
            {
                return _sortChineseSign ?? (_sortChineseSign = new RelayCommand<object>(o =>
                           SortImplementation(o, 5)));
            }
        }
        public RelayCommand<object> SortIsAdult
        {
            get
            {
                return _sortIsAdult ?? (_sortIsAdult = new RelayCommand<object>(o =>
                           SortImplementation(o, 6)));
            }
        }

       

        public RelayCommand<object> SortIsBirthday
        {
            get
            {
                return _sortIsBirthday ?? (_sortIsBirthday = new RelayCommand<object>(o =>
                           SortImplementation(o, 7)));
            }
        }
        #endregion

        #region FilterProperties

        public bool Adult
        {
            get
            {
                return _adult; 
            }
            set
            {
                _adult = value;
                FilterImplementation();
            }
        }

      

        public bool Child
        {
            get
            {
                return _child;
            }
            set
            {
                _child = value;
                FilterImplementation();
            }
        }

        public bool BirthdayToday
        {
            get
            {
                return _birthdayToday;
            }
            set
            {
                _birthdayToday = value;
                FilterImplementation();
            }
        }
        public bool BirthdayNotToday
        {
            get
            {
                return _birthdayNotToday;
            }
            set
            {
                _birthdayNotToday = value;
                FilterImplementation();
            }
        }
        public bool Aquarius
        {
            get
            {
                return _aquarius;
            }
            set
            {
                _aquarius = value;
                FilterImplementation();
            }
        }
        public bool Pisces
        {
            get
            {
                return _pisces;
            }
            set
            {
                _pisces = value;
                FilterImplementation();
            }
        }
        public bool Aries
        {
            get
            {
                return _aries;
            }
            set
            {
                _aries = value;
                FilterImplementation();
            }
        }
        public bool Taurus
        {
            get
            {
                return _taurus;
            }
            set
            {
                _taurus = value;
                FilterImplementation();
            }
        }
        public bool Gemini
        {
            get
            {
                return _gemini;
            }
            set
            {
                _gemini = value;
                FilterImplementation();
            }
        }
        public bool Cancer
        {
            get
            {
                return _cancer;
            }
            set
            {
                _cancer = value;
                FilterImplementation();
            }
        }
        public bool Leo
        {
            get
            {
                return _leo;
            }
            set
            {
                _leo = value;
                FilterImplementation();
            }
        }
        public bool Virgo
        {
            get
            {
                return _virgo;
            }
            set
            {
                _virgo = value;
                FilterImplementation();
            }
        }
        public bool Libra
        {
            get
            {
                return _libra;
            }
            set
            {
                _libra = value;
                FilterImplementation();
            }
        }
        public bool Scorpio
        {
            get
            {
                return _scorpio;
            }
            set
            {
                _scorpio = value;
                FilterImplementation();
            }
        }
        public bool Sagittarius
        {
            get
            {
                return _sagittarius;
            }
            set
            {
                _sagittarius = value;
                FilterImplementation();
            }
        }
        public bool Capricorn
        {
            get
            {
                return _capricorn;
            }
            set
            {
                _capricorn = value;
                FilterImplementation();
            }
        }
        public bool Monkey
        {
            get
            {
                return _monkey;
            }
            set
            {
                _monkey = value;
                FilterImplementation();
            }
        }
        public bool Rooster
        {
            get
            {
                return _rooster;
            }
            set
            {
                _rooster = value;
                FilterImplementation();
            }
        }
        public bool Dog
        {
            get
            {
                return _dog;
            }
            set
            {
                _dog = value;
                FilterImplementation();
            }
        }
        public bool Pig
        {
            get
            {
                return _pig;
            }
            set
            {
                _pig = value;
                FilterImplementation();
            }
        }
        public bool Rat
        {
            get
            {
                return _rat;
            }
            set
            {
                _rat = value;
                FilterImplementation();
            }
        }
        public bool Ox
        {
            get
            {
                return _ox;
            }
            set
            {
                _ox = value;
                FilterImplementation();
            }
        }
        public bool Tiger
        {
            get
            {
                return _tiger;
            }
            set
            {
                _tiger = value;
                FilterImplementation();
            }
        }
        public bool Rabbit
        {
            get
            {
                return _rabbit;
            }
            set
            {
                _rabbit = value;
                FilterImplementation();
            }
        }
        public bool Dragon
        {
            get
            {
                return _dragon;
            }
            set
            {
                _dragon = value;
                FilterImplementation();
            }
        }
        public bool Snake
        {
            get
            {
                return _snake;
            }
            set
            {
                _snake = value;
                FilterImplementation();
            }
        }
        public bool Horse
        {
            get
            {
                return _horse;
            }
            set
            {
                _horse = value;
                FilterImplementation();
            }
        }
        public bool Goat
        {
            get
            {
                return _goat;
            }
            set
            {
                _goat = value;
                FilterImplementation();
            }
        }
        public bool Metal
        {
            get
            {
                return _metal;
            }
            set
            {
                _metal = value;
                FilterImplementation();
            }
        }
        public bool Water
        {
            get
            {
                return _water;
            }
            set
            {
                _water = value;
                FilterImplementation();
            }
        }
        public bool Wood
        {
            get
            {
                return _wood;
            }
            set
            {
                _wood = value;
                FilterImplementation();
            }
        }
        public bool Fire
        {
            get
            {
                return _fire;
            }
            set
            {
                _fire = value;
                FilterImplementation();
            }
        }
        public bool Earth
        {
            get
            {
                return _earth;
            }
            set
            {
                _earth = value;
                FilterImplementation();
            }
        }
        public DateTime DateTo
        {
            get
            {
                return _dateTo;
            }
            set
            {
                try
                {
                    if (value < _dateFrom)
                        throw new InvalidDateFilterBordersException("Date To can`t be less than Date From!!!");
                    _dateTo = value;
                }catch(InvalidDateFilterBordersException e)
                {
                    _dateTo = DateTime.MaxValue;
                    MessageBox.Show(e.Message);
                }
                FilterImplementation();
            }
        }
        public DateTime DateFrom
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                try
                {
                    if (value > _dateTo)
                        throw new InvalidDateFilterBordersException("Date From can`t be more than Date To!!!");
                    _dateFrom = value;
                }catch(InvalidDateFilterBordersException e)
                {
                    _dateFrom = DateTime.MinValue;
                    MessageBox.Show(e.Message);
                }
                FilterImplementation();
            }
        }
        #endregion

        public PersonListViewModel()
        {

            StationManager.Initialize(new SerializedDataStorage());
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            
        }

        private async void SaveCommandImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                StationManager.DataStorage.PersonsList = _persons.ToList();
                StationManager.DataStorage.SaveList();
                
            });
            LoaderManager.Instance.HideLoader();
        }

        private async void SortImplementation(object o, int i)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                IOrderedEnumerable<Person> sortedPersons;
                switch (i)
                {
                    case 0:
                        sortedPersons = from p in _persons
                                        orderby p.Name.ToUpper()
                                        select p;
                        break;
                    case 1:
                        sortedPersons = from p in _persons
                                        orderby p.Surname.ToUpper()
                                        select p;
                        break;
                    case 2:
                        sortedPersons = from p in _persons
                                        orderby p.Email.ToUpper()
                                        select p;
                        break;
                    case 3:
                        sortedPersons = from p in _persons
                                        orderby p.Date
                                        select p;
                        break;
                    case 4:
                        sortedPersons = from p in _persons
                                        orderby p.SunSign
                                        select p;
                        break;
                    case 5:
                        sortedPersons = from p in _persons
                                        orderby p.ChineseSign
                                        select p;
                        break;
                    case 6:
                        sortedPersons = from p in _persons
                                        orderby p.IsAdult
                                        select p;
                        break;
                    default:
                        sortedPersons = from p in _persons
                                        orderby p.IsBirthday
                                        select p;
                        break;
                }
                Persons = new ObservableCollection<Person>(sortedPersons);
                
            });
            LoaderManager.Instance.HideLoader();
        }
        private async void FilterImplementation()
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                IEnumerable<Person> filteredPersons;
                filteredPersons = from p in _persons
                                  where p.IsAdult == _adult || p.IsAdult != _child || _adult == _child
                                  where p.IsBirthday == _birthdayToday || p.IsBirthday != _birthdayNotToday || _birthdayToday == _birthdayNotToday
                                  where (_metal == _water && _water == _wood && _wood == _fire && _fire == _earth) || (_metal && p.ChineseSign.ToLower().Contains("metal")) ||
                                  (_fire && p.ChineseSign.ToLower().Contains("fire")) || (_water && p.ChineseSign.ToLower().Contains("water")) ||
                                  (_earth && p.ChineseSign.ToLower().Contains("earth")) || (_wood && p.ChineseSign.ToLower().Contains("wood"))
                                  where (_monkey && p.ChineseSign.ToLower().Contains("monkey")) || (_rooster && p.ChineseSign.ToLower().Contains("rooster")) || (_dog && p.ChineseSign.ToLower().Contains("dog")) ||
                                  (_pig && p.ChineseSign.ToLower().Contains("pig")) || (_rat && p.ChineseSign.ToLower().Contains("rat")) || (_ox && p.ChineseSign.ToLower().Contains("ox")) ||
                                  (_tiger && p.ChineseSign.ToLower().Contains("tiger")) || (_rabbit && p.ChineseSign.ToLower().Contains("rabbit")) || (_dragon && p.ChineseSign.ToLower().Contains("dragon")) ||
                                  (_snake && p.ChineseSign.ToLower().Contains("snake")) || (_horse && p.ChineseSign.ToLower().Contains("horse")) || (_goat && p.ChineseSign.ToLower().Contains("goat")) ||
                                  (_monkey == _rooster && _rooster == _dog && _dog == _pig && _pig == _rat && _rat == _ox && _ox == _tiger && _tiger == _rabbit && _rabbit == _dragon && _dragon == _snake && _snake == _horse && _horse == _goat)
                                  where (_aquarius && p.SunSign.ToLower().Contains("aquarius")) || (_pisces && p.SunSign.ToLower().Contains("pisces")) || (_aries && p.SunSign.ToLower().Contains("aries")) ||
                                   (_taurus && p.SunSign.ToLower().Contains("taurus")) || (_gemini && p.SunSign.ToLower().Contains("gemini")) || (_cancer && p.SunSign.ToLower().Contains("cancer")) ||
                                   (_leo && p.SunSign.ToLower().Contains("leo")) || (_virgo && p.SunSign.ToLower().Contains("virgo")) || (_libra && p.SunSign.ToLower().Contains("libra")) ||
                                   (_scorpio && p.SunSign.ToLower().Contains("scorpio")) || (_sagittarius && p.SunSign.ToLower().Contains("sagittarius")) || (_capricorn && p.SunSign.ToLower().Contains("capricorn")) 
                                   ||(_aquarius==_pisces&&_pisces==_aries&&_aries==_taurus&&_taurus==_gemini&&_gemini==_cancer&&_cancer==_leo&&_leo==_virgo&&_virgo==_libra&&_libra==_scorpio&&_scorpio==_sagittarius&&_sagittarius==_capricorn)
                                  where p.Date>=_dateFrom&&p.Date<=_dateTo   
                                  select p;
              Persons = new ObservableCollection<Person>(filteredPersons);
            });
            LoaderManager.Instance.HideLoader();
        }
        private void AddCommandImplementation(object obj)
        {
            SelectionManager.SelectedPerson = null;
            AddEditPersonView window = new AddEditPersonView();
            window.ShowDialog();
            Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            FilterImplementation();
        }
        private void EditCommandImplementation(object obj)
        {
            SelectionManager.SelectedPerson = _selectedPerson;
            AddEditPersonView window = new AddEditPersonView();
            window.ShowDialog();
            Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            FilterImplementation();
        }
        private async void DeleteCommandImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                if (MessageBox.Show($"Delete {_selectedPerson}?",
                "Delete?",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    StationManager.DataStorage.DeletePerson(_selectedPerson);
                    _selectedPerson = null;
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                    FilterImplementation();
                }
            });
            LoaderManager.Instance.HideLoader();            
        }
        private bool CanExecuteCommand()
        {
            return _selectedPerson != null;
        }
      
    }
}
