using
    System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PersonSamples
/// </summary>
public static class PersonSamples
{
    public static void RunSamples(ref List<Person> lstAllPeople)
    {
        // Create a person
        Person person = CreatePerson();

        //Update that person
        UpdatePerson(person);


        // Delete the person
        DeletePerson(person.Id.Value);

        lstAllPeople= GetAllPeople();
    }

    private static Person CreatePerson()
    {
        PersonService personService = new PersonService();
        Person person = GetNewPerson();

        personService.Create(ref person);

        return person;
    }

    private static void UpdatePerson(Person person)
    {
        person.FirstName = "NewFirstName";
        person.LastName = "NewLastName";

        PersonService personService = new PersonService();
        personService.Update(ref person);
    }

    private static void DeletePerson(int id)
    {
        PersonService personService = new PersonService();
        personService.Delete(id);
    }

    private static Person GetNewPerson()
    {
        return new Person
        {
            FirstName = "OldFirstName",
            LastName = "OldLastName",
            Email = "my1@name.com"
        };
    }
    private static List<Person> GetAllPeople()
    {
        PersonService p = new PersonService();
        return p.GetAllPeople();
    }
}