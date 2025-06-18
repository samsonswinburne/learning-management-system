using lms_backend.Models;
using lms_backend.Models.DTOs;
using lms_backend.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace lms_backend.Controllers
{
    [ApiController]
    [Route("/api/semester")]
    public class SemesterController
    {
        MongoDBService DB;
        public SemesterController(MongoDBService _db)
        {
            DB = _db;
        }
        [HttpPost("create", Name = "create semester")]
        public async Task<int> CreateSemester([FromBody] CreateSemesterRequest request)
        {
            Semester semester = new Semester(request.SemesterNumber, new ObjectId(request.SubjectId));
            await DB.CreateSemesterAsync(semester);
            return 200;
        }
    }
}
