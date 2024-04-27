using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BusinessPerson
    {
        public List<Person> GetPeople() 
        {
            List<Person> people = new List<Person>();
            PersonData data = new PersonData();
            people = data.GetPeople();
            return people;
        }

        //public List<Person> GetPeople18() 
        //{
        //    List<Person> people = new List<Person>();
        //    PersonData data = new PersonData();
        //    people = data.GetPeople();
        //    var result = people.Where(x=> x.Age > 18).ToList();
        //    return people;
        //}

        public List<Person> GetPeopleByName(string name) 
        {
            List<Person> people = new List<Person>();
            PersonData data = new PersonData();
            people = data.GetPeople();
            var filteredPeople = people.Where(person => person.Name.Contains(name)).ToList();
            return filteredPeople.Take(1).ToList();
        }


    }
}
