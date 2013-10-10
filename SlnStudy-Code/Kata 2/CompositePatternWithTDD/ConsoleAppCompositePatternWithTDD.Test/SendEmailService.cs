using System;
using System.Collections.Generic;

namespace ConsoleAppVisitorPatternWithTDD.Test
{
    public class SendEmailService
    {
        public void Send(Person person)
        {
            PersonStaticClass.PersonStatic = person;
        }

        public void Send(List<Person> people)
        {
            PersonStaticClass.PeopleStatic = people;
        }

        public void Send(string email)
        {
            PersonStaticClass.Emails.Add(email);
        }
    }
}