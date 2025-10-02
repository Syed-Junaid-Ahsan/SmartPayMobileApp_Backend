using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using SmartPayMobileApp_Backend.Models.Entities;
using SmartPayMobileApp_Backend.Repositories.Interfaces;
using SmartPayMobileApp_Backend.Services.Interfaces;

namespace SmartPayMobileApp_Backend.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<int> SignupAsync(string name, string phoneNumber, string email, string password)
        {
            var existing = await _userRepository.GetByEmailAsync(email);
            if (existing != null)
                throw new InvalidOperationException("Email already exists");

            var passwordHash = HashPassword(password);

            var user = new User
            {
                Name = name,
                PhoneNumber = phoneNumber,
                Email = email,
                PasswordHash = passwordHash
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !user.IsActive)
                return false;

            return VerifyPassword(password, user.PasswordHash);
        }

        private static string HashPassword(string password)
        {
            // PBKDF2 with HMACSHA256
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[16];
            rng.GetBytes(salt);

            const int iterations = 100000;
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);

            // store as: iterations.saltBase64.hashBase64
            var result = $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
            return result;
        }

        private static bool VerifyPassword(string password, string stored)
        {
            var parts = stored.Split('.', 3);
            if (parts.Length != 3) return false;

            var iterations = int.Parse(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var expectedHash = Convert.FromBase64String(parts[2]);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);
            return CryptographicOperations.FixedTimeEquals(hash, expectedHash);
        }
    }
}
