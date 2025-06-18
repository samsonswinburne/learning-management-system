namespace lms_backend.Models.DTOs
{
    public readonly record struct CreateSchoolRequest(string SchoolName, string AdminEmail, string AdminPassword, string? ProfilePictureLink);
}
