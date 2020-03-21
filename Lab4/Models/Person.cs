using KMA.ProgrammingInCSharp2020.Lab4.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace KMA.ProgrammingInCSharp2020.Lab4.Models
{
    [Serializable]
    internal class Person
    {
        #region Fields
        private readonly string _name;
        private readonly string _surname;
        private readonly string _email;
        private readonly DateTime _date;

        private readonly bool _isAdult;
        private readonly bool _isBirthday;
        private readonly string _sunSign;
        private readonly string _chineseSign;

        #endregion
        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
        }

        public string SunSign { 
            get
            {
                return _sunSign;
            }
        }

        public string ChineseSign { 
            get {
                return _chineseSign;
            }
            }
        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
        }
        #endregion
        #region Constructors
        internal Person(string name, string surname, string email, DateTime Date)
        {
            _name = name;
            _surname = surname;
            if (new EmailAddressAttribute().IsValid(email))
            {
                _email = email;
            }
            else
            {
                throw new InvalidEmailException("Error! Invalid email!");
            }
             _date = Date;
            _isAdult = ComputeAge() >= 18;
            _isBirthday = CheckBirthday();
            _sunSign = ComputeWesternZodiac();
            _chineseSign = ComputeChineseZodiac();
        }
        internal Person(string name, string surname, string email) :
            this(name, surname, email, DateTime.Today)
        {
        }
        internal Person(string name, string surname, DateTime Date):
            this(name, surname, "default@email.com", Date)
        {
        }
        #endregion
        private bool CheckBirthday()
        {
            return Date.Day == DateTime.Today.Day && Date.Month == DateTime.Today.Month;
            
        }

        private string ComputeWesternZodiac()
        {
            string westernZodiacSign = "";
            if ((Date.Month == 1 && Date.Day >= 21) || (Date.Month == 2 && Date.Day <= 19))
                westernZodiacSign = "Aquarius \u2652";
            else if ((Date.Month == 2 && Date.Day >= 20) || (Date.Month == 3 && Date.Day <= 20))
                westernZodiacSign = "Pisces \u2653";
            else if ((Date.Month == 3 && Date.Day >= 21) || (Date.Month == 4 && Date.Day <= 20))
                westernZodiacSign = "Aries \u2648";
            else if ((Date.Month == 4 && Date.Day >= 21) || (Date.Month == 5 && Date.Day <= 20))
                westernZodiacSign = "Taurus \u2649";
            else if ((Date.Month == 5 && Date.Day >= 21) || (Date.Month == 6 && Date.Day <= 20))
                westernZodiacSign = "Gemini \u264A";
            else if ((Date.Month == 6 && Date.Day >= 21) || (Date.Month == 7 && Date.Day <= 21))
                westernZodiacSign = "Cancer \u264B";
            else if ((Date.Month == 7 && Date.Day >= 22) || (Date.Month == 8 && Date.Day <= 21))
                westernZodiacSign = "Leo \u264C";
            else if ((Date.Month == 8 && Date.Day >= 22) || (Date.Month == 9 && Date.Day <= 21))
                westernZodiacSign = "Virgo \u264D";
            else if ((Date.Month == 9 && Date.Day >= 22) || (Date.Month == 10 && Date.Day <= 21))
                westernZodiacSign = "Libra \u264E";
            else if ((Date.Month == 10 && Date.Day >= 22) || (Date.Month == 11 && Date.Day <= 21))
                westernZodiacSign = "Scorpio \u264F";
            else if ((Date.Month == 11 && Date.Day >= 22) || (Date.Month == 12 && Date.Day <= 21))
                westernZodiacSign = "Sagittarius \u2650";
            else if ((Date.Month == 12 && Date.Day >= 22) || (Date.Month == 1 && Date.Day <= 20))
                westernZodiacSign = "Capricorn \u2651";
            return westernZodiacSign;
        }

        private string ComputeChineseZodiac()
        {
            int year = Date.Year;
            /*Chinese new year starts according to the moon phases, and it can be [Jan21;Feb21],
           we'll suppose that China was celebrating New Year at 21 of Jan*/
            if (Date.Month == 1 && Date.Day < 21) year -= 1;
           return ChineseZodiacElement(year % 10) +" "+ChineseZodiacAnimal(year % 12);

        }

        private string ChineseZodiacAnimal(int year)
        {
            return year switch
            {
                0 => "Monkey",
                1 => "Rooster",
                2 => "Dog",
                3 => "Pig",
                4 => "Rat",
                5 => "Ox",
                6 => "Tiger",
                7 => "Rabbit",
                8 => "Dragon",
                9 => "Snake",
                10 => "Horse",
                _ => "Goat"
            };
        }

        private string ChineseZodiacElement(int year)
        {
            switch (year)
            {
                case 0:
                case 1:
                    return "Metal";
                case 2:
                case 3:
                    return "Water";
                case 4:
                case 5:
                    return "Wood";
                case 6:
                case 7:
                    return "Fire";
                default:
                    return "Earth";
            }
        }

        private int ComputeAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Date.Year;
            if (today.Month < Date.Month || (today.Month == Date.Month && today.Day < Date.Day))
            {
                age -= 1;
            }
            if (age < 0)
            {
                throw new UnbornPersonException("Error!!! You can`t be born in the future!");
            }
            
            if (age > 135)
            {
                throw new TooOldPersonException("Error!!! You can`t be older than 135 years!");
            }
            return age;
        }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
