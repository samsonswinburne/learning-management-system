using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lms_backend.Models
{
    public class School
    {
        public School(string name, string? profilePictureLink)
        {
            Name = name;
            ProfilePictureLink = profilePictureLink;
            TeacherIds = new List<ObjectId>();
            StudentIds = new List<ObjectId>();
            SubjectIds = new List<ObjectId>();
            AdminIds = new List<ObjectId>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonRequired]
        public string Name {  get; set; }
        public string? ProfilePictureLink {  get; set; }
        public List<ObjectId> AdminIds { get; set; }
        public List<ObjectId> TeacherIds { get; set; }
        
        public List<ObjectId> StudentIds { get; set; }
        
        public List<ObjectId> SubjectIds { get; set; }
        
    }
}
