using KMA.ProgrammingInCSharp2020.Lab4.Models;
using System.Collections.Generic;

namespace KMA.ProgrammingInCSharp2020.Lab4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddPerson(ref Person person);
        void DeletePerson(ref Person person);
        void EditPerson(ref Person person, ref Person resPerson);
        List<Person> PersonsList { get;}
    }
}
