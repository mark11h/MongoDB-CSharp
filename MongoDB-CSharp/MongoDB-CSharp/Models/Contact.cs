using System.ComponentModel;
using MongoDB.Bson;

namespace MongoDB_CSharp.Models
{
    public class Contact
    {
        public ObjectId Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }
    }
}