namespace SmartPayMobileApp_Backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int> SignupAsync(string name, string phoneNumber, string email, string password);
        Task<bool> ValidateUserAsync(string email, string password);
    }
}


