namespace lms_backend.Models.DTOs
{
    public readonly record struct CreateSubjectRequest(string SubjectCode, string SubjectName, string SubjectDescription, string subjectPictureLink, List<string> TeacherIds, string SchoolId);
}
