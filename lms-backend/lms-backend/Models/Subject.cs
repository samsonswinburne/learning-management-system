using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace lms_backend.Models
{
    public class Subject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId SubjectCode { get; set; }
        
        public List<ObjectId> ClassIds { get; set; }


        public List<ObjectId> StudentIds { get; set; }

    }

    public class SubjectEnrolment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId StudentId { get; set; }
        public int SemesterNumber { get; set; }

        public List<GradeResult> GradeResults { get; set; }
    }
    public class Assignment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId AssignmentId { get; set; }
        public string AssignmentTitle {  get; set; }
        public string AssignmentDescription { get; set; }
        public bool Active { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
    public class GradeResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public ObjectId AssignmentId { get; set; }
        public int GradeNumber { get; set; }
        public string Feedback {  get; set; }

    }
}

