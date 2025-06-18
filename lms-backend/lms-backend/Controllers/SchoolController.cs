using lms_backend.Models;
using lms_backend.Models.DTOs;
using lms_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace lms_backend.Controllers
{
    [ApiController]
    [Route("/api/school")]
    public class SchoolController
    {
        private readonly MongoDBService DB;

        public SchoolController(MongoDBService DB)
        {
            this.DB = DB;
        }

        [HttpPost("create", Name ="Create School")]
        public async Task<int> CreateSchool([FromBody] CreateSchoolRequest request)
        {
            School schoolToCreate = new School(request.SchoolName, request.ProfilePictureLink);
            Student adminToCreate = new Student(request.AdminEmail, request.AdminPassword, null, "admin", null, DateOnly.FromDateTime(DateTime.Now), false, null, null);

            await DB.CreateSchoolAsync(schoolToCreate, adminToCreate);
            return 0;
        }
    }
}
