using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace lms_backend.Models
{
    public class Student
    {
        public Student(string email, string password, string? phoneNumber, string firstName, string? lastName, DateOnly birthDate, bool teacher, string? profilePictureLink, ObjectId? schoolId)
        {
            Email = email;

            Password = password;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Teacher = teacher;
            ProfilePictureLink = profilePictureLink;


            SchoolId = schoolId;
            SubjectIds = new List<ObjectId>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonRequired]
        public string Email { get; set; }

        [BsonRequired]
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        [BsonRequired]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [BsonRequired]
        public DateOnly BirthDate { get; set; }
        [BsonRequired]
        public bool Teacher {  get; set; }
        public string? ProfilePictureLink {  get; set; }

        
        public ObjectId? SchoolId { get; set; }
        public List<ObjectId> SubjectIds { get; set; }

    }
}
