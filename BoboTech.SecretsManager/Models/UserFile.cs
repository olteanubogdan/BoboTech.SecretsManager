using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BoboTech.SecretsManager.Models
{
    public class UserFile
    {
        //public const string CollectionName = "userfiles";

        public static class Properties
        {
            //public const string UserName = "username";
            public const string FileName = "filename";
            public const string FileType = "filetype";
            public const string InternalName = "internalname";
        }

        //[BsonId]
        //public ObjectId Id { get; set; }

        //[BsonElement(Properties.UserName)]
        //public string UserName { get; set; }

        [BsonElement(Properties.FileName)]
        public string FileName { get; set; }

        [BsonElement(Properties.FileType)]
        public string FileType { get; set; }

        [BsonElement(Properties.InternalName)]
        public string InternalName { get; set; }
    }
}