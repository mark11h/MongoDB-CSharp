using System.ComponentModel;

namespace MongoDB_CSharp.Models
{
    public class Contact
    {
        [DisplayName("First Name")]
        public string FirstName { get; private set; }

        public string Surname { get; private set; }

        public Contact(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }
    }
}