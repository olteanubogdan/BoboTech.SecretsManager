using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoboTech.SecretsManager.Models
{
    public class User
    {
        public const string CollectionName = "users";

        public static class Properties
        {
            public const string UserName = "username";
            public const string Email = "email";
            public const string Password = "password";
            public const string Salt = "salt";
            public const string IsEnabled = "isEnabled";
            public const string Files = "files";
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement(Properties.UserName)]
        public string UserName { get; set; }

        [BsonElement(Properties.Email)]
        public string Email { get; set; }

        [BsonElement(Properties.Password)]
        public string Password { get; set; }

        [BsonElement(Properties.Salt)]
        public string Salt { get; set; }

        [BsonElement(Properties.IsEnabled)]
        public bool? IsEnabled { get; set; }

        [BsonElement(Properties.Files)]
        public List<UserFile> Files { get; set; }
    }
}