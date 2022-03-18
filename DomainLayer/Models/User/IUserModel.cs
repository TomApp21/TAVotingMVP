namespace DomainLayer.Models.User
{
    public interface IUserModel
    {
        string ConfirmPassword { get; set; }
        bool IsAdmin { get; set; }
        bool IsAuditor { get; set; }
        bool IsVoter { get; set; }
        string Password { get; set; }
        int UserId { get; set; }
        string Username { get; set; }
    }
}