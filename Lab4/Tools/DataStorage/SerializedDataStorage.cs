using KMA.ProgrammingInCSharp2020.Lab4.Models;
using KMA.ProgrammingInCSharp2020.Lab4.Tools.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KMA.ProgrammingInCSharp2020.Lab4.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private List<Person> _persons;
        

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                InitializePersonList();
                SaveList();
            }
        }

        private void InitializePersonList()
        {
            Random rand = new Random();
            for (int i = 0; i < 50; ++i)
            {
                _persons.Add(new Person($"Name{i}", $"Surname{i}",$"email{i}@test.com",new DateTime(rand.Next(1900,2020),rand.Next(1,13),rand.Next(1,29))));
            }
        }

        public void SaveList()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }
         
        public List<Person> PersonsList 
        {
            get { return _persons.ToList(); }
            set { _persons = value; }
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveList();
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
            SaveList();
        }

        public void EditPerson(Person person, Person resPerson)
        {
            _persons[_persons.IndexOf(person)] = resPerson;
            SaveList();
        }

    }
}
