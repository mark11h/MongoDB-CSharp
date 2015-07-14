using System.ComponentModel;

namespace MongoDB_CSharp.Models
{
    public class Contact
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }
    }
}