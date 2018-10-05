using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectCloud.Models
{
    public class Account
    {
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("account_id")]
        public string AccountId { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("city_name")]
        public string CityName { get; set; }

        [BsonElement("date_of_birth")]
        public string DateOfBirth { get; set; }

        [BsonElement("phone_number")]
        public int PhoneNumber { get; set; }

        [BsonElement("email_address")]
        public string EmailAddress { get; set; }

        [BsonElement("education")]
        public string Education { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        public Account()
        {

        }
    }
}
