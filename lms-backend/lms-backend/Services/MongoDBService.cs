using lms_backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace lms_backend.Services;
public class MongoDBService
{
    private readonly IMongoCollection<Student> _studentCollection;
    private readonly IMongoCollection<School> _schoolCollection;
    private readonly IMongoCollection<Subject> _subjectCollection;
    private readonly IMongoCollection<Semester> _semesterCollection;
    private readonly IMongoCollection<Subject> _classCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _studentCollection = database.GetCollection<Student>(mongoDBSettings.Value.CollectionName);
        _schoolCollection = database.GetCollection<School>("school");
        _subjectCollection = database.GetCollection<Subject>("subject");
        _semesterCollection = database.GetCollection<Semester>("semester");
        _classCollection = database.GetCollection<Subject>("class");

    }

    // students
    public async Task<List<Student>> GetAllStudentsAsync() { return null; }
    public async Task<Student> FetchStudentByEmailAsync(string email)
    {
        return await _studentCollection.Find(s => s.Email == email).FirstOrDefaultAsync();
    }
    public async Task CreateStudentAsync(Student student) {
    
        await _studentCollection.InsertOneAsync(student);
    }
    public async Task AddStudentToClassAsync(string id, string movieId) { }
    public async Task DeleteStudentAsync(string id) { }
    
    //classes


    //subjects
    public async Task<int> CreateSubjectAsync(Subject subject)
    {
        await _subjectCollection.InsertOneAsync(subject);
        return 200;
    }
    //semesters
    public async Task<int> CreateSemesterAsync(Semester semester)
    {
        await _semesterCollection.InsertOneAsync(semester);

        var filter = Builders<Subject>.Filter.Eq(subj => subj.Id, semester.SubjectId);
        var update = Builders<Subject>.Update.AddToSet(subj => subj.SemesterIds, semester.SemesterId);

        await _subjectCollection.UpdateOneAsync(filter, update);
        return 200;
    }
    //schools
    public async Task CreateSchoolAsync(School school, Student admin)
    {
        await _schoolCollection.InsertOneAsync(school);

        admin.SchoolId = school.Id;

        await _studentCollection.InsertOneAsync(admin);

        var filterBuilder = Builders<School>.Filter;


        var filter = filterBuilder.Eq(s => s.Id, school.Id);

        var updateBuilder = Builders<School>.Update;

        var update = updateBuilder.Combine(
            updateBuilder.AddToSet(s => s.AdminIds, admin.Id) 
            );


        await _schoolCollection.UpdateOneAsync(filter, update);
    }
    

}