namespace lms_backend.Models.DTOs
{
    public readonly record struct CreateSemesterRequest(int SemesterNumber, string SubjectId);
}
