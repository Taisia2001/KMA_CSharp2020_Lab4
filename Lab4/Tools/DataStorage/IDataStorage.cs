using KMA.ProgrammingInCSharp2020.Lab4.Models;
using System.Collections.Generic;

namespace KMA.ProgrammingInCSharp2020.Lab4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddPerson(Person person);
        void DeletePerson(Person person);
        void EditPerson( Person person, Person resPerson);
        List<Person> PersonsList { get;}
    }
}
