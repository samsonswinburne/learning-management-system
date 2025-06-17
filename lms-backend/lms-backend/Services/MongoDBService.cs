using lms_backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using lms_backend.Models;
namespace lms_backend.Services;
public class MongoDBService
{
    private readonly IMongoCollection<Student> _studentCollection;
    private readonly IMongoCollection<School> _schoolCollection;
    private readonly IMongoCollection<Subject> _subjectCollection;
    private readonly IMongoCollection<Class> _classCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _studentCollection = database.GetCollection<Student>(mongoDBSettings.Value.CollectionName);
        _schoolCollection = database.GetCollection<School>("school");
        _subjectCollection = database.GetCollection<Subject>("subject");
        _classCollection = database.GetCollection<Class>("class");

    }
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
    public async Task CreateSchoolAsync(School school)
    {
        await _schoolCollection.InsertOneAsync(school);
    }

}