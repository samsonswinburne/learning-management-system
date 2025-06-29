using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace lms_backend.Models
{
    public class Subject
    {
        public Subject(string subjectCode, string subjectName, string subjectDescription, string? subjectPictureLink, ObjectId schoolId)
        {
            SubjectCode = subjectCode.ToUpper().Trim();
            SubjectName = subjectName.Trim();
            ConvenorIds = new List<ObjectId>();
            TeacherIds = new List<ObjectId>();
            SubjectDescription = subjectDescription;
            SubjectPictureLink = subjectPictureLink;
            SchoolId = schoolId;
            SemesterIds = new List<ObjectId>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public List<ObjectId> ConvenorIds { get; set; }
        public List<ObjectId> TeacherIds { get; set; }
        public string SubjectDescription { get; set; }
        public string? SubjectPictureLink { get; set; }
        public ObjectId SchoolId {  get; set; }
        public List<ObjectId> SemesterIds { get; set; }

    }
    public class Semester
    {
        public Semester(int semesterNumber, ObjectId subjectId)
        {
            this.SemesterNumber = semesterNumber;
            ClassIds = new List<ObjectId>();
            TeacherIds = new List<ObjectId>();
            StudentIds = new List<ObjectId>();
            SubjectId = subjectId;
            AssignmentIds = new List<ObjectId>();
    



            //todo, check if the current school semester is this semester number, then set current accordingly

            // implemented in MongoDBService in CreateSemesterAsync
            Current = false;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId SemesterId { get; set; }
        public ObjectId SubjectId {  get; set; }
        public ObjectId? SchoolId { get; set; }
        public int SemesterNumber {  get; set; }
        public List<ObjectId> ClassIds { get; set; }
        public List<ObjectId> TeacherIds { get; set; }
        public List<ObjectId> StudentIds { get; set; }
        public bool Current {  get; set; }
        
        public List<ObjectId> AssignmentIds { get; set; }

    }

    public class Assignment
    {
        public Assignment(string assignmentTitle, string assignmentDescription, DateTime startTime, DateTime endTime)
        {
            AssignmentTitle = assignmentTitle;
            AssignmentDescription = assignmentDescription;
            StartTime = startTime;
            EndTime = endTime;
            if(DateTime.Now.Subtract(startTime) < TimeSpan.Zero && DateTime.Now.Subtract(endTime) > TimeSpan.Zero)
            {
                Active = true;
            }
            else
            {
                Active = false;
            }
            GradeResults = new List<GradeResult>();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId AssignmentId { get; set; }
        public string AssignmentTitle {  get; set; }
        public string AssignmentDescription { get; set; }
        public bool Active { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List <GradeResult> GradeResults { get; set; }
    }
    public class GradeResult
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public int SemesterNumber { get; set; }
        public int GradeNumber { get; set; }
        public string Feedback {  get; set; }

    }
}

