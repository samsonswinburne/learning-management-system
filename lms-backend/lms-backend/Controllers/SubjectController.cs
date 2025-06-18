using lms_backend.Models;
using lms_backend.Models.DTOs;
using lms_backend.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace lms_backend.Controllers
{
    [ApiController]
    [Route("/api/subject")]
    public class SubjectController
    {
        private readonly MongoDBService DB;
        public SubjectController(MongoDBService _db)
        {
            DB = _db;
        }
        [HttpPost("create", Name = "Create a subject")]
        public async Task<int> CreateSubject([FromBody] CreateSubjectRequest request)
        {
            Subject subject = new Subject(request.SubjectCode.ToLower().Trim(), request.SubjectName, request.SubjectDescription, request.subjectPictureLink, new ObjectId(request.SchoolId));

            List<ObjectId> teacherIds = new List<ObjectId>();
            try
            {
                teacherIds = request.TeacherIds.Select(id => new ObjectId(id)).ToList();
            }catch(FormatException ex)
            {
                return 400;
            }
            subject.TeacherIds = subject.TeacherIds.Concat(teacherIds).ToList();

            await DB.CreateSubjectAsync(subject);
            return 200;
        }
    }
}
