using MongoDB.Bson.Serialization.Attributes;

using MongoDB.Bson;

namespace lms_backend.Models
{
    public class Class
    {
        public Class(ObjectId subjectCode, int semesterNumber, bool active)
        {
            this.SubjectCode = subjectCode;
            SemesterNumber = semesterNumber;
            Active = active;

        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public ObjectId SubjectCode { get; set; }

        
        public int SemesterNumber { get; set; }
        
        public bool Active { get; set; }
        public List<ObjectId> StudentIds { get; set; }
        public List<ObjectId> TeacherIds { get; set; }
        public List<Period> Periods { get; set; }
    }
    public class Period
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ClassRoom {  get; set; }
        public string? ReplacementClassRoom {  get; set; }
        public List<ObjectId> ReplacementTeachers { get; set; }
    }
}
