using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MongoDB_CSharp.Controllers
{
    public class ContactsController : Controller
    {
        private const string DatabaseName = "contacts";

        private const string CollectionName = "contacts";

        private IMongoDatabase RetreiveMongohqDb()
        {
            MongoClient mongoClient = new MongoClient(new MongoUrl(ConfigurationManager.AppSettings["MongoLabUri"]));
            
            return mongoClient.GetDatabase(DatabaseName);
        }
        
        public async Task<ActionResult> Index()
        {
            var contactsCollection = RetreiveMongohqDb().GetCollection<BsonDocument>(CollectionName);

            var allContacts = await contactsCollection.Find(new BsonDocument()).ToListAsync();

            var contacts = new List<Models.Contact>();

            foreach (var item in allContacts)
            {
                contacts.Add(new Models.Contact
                {
                    FirstName = item["firstname"].AsString,
                    Surname = item["surname"].AsString
                });
            }

            return View(contacts);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var contactsCollection = RetreiveMongohqDb().GetCollection<BsonDocument>(CollectionName);

                var contact = new BsonDocument
                {
                    { "firstname", collection["FirstName"] },
                    { "surname", collection["Surname"] }
                };
                
                contactsCollection.InsertOneAsync(contact);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}