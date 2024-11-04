namespace Library.Models
{
    public record CreateStudentDto(string Name, int Age, string Email);
    public record CreateMarkDto(int MarkNumber, string MarkText, string Description, Guid StudentId);
}
