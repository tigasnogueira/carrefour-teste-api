using Carrefour.ClientApi.Interfaces;
using Carrefour.ClientApi.Models;
using Carrefour.TransactionApi.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Carrefour.TransactionApi.Services;

public class AccountService : IAccountService
{
    private readonly IClientRepository _clientRepository;
    private readonly IPasswordHasher<ClientModel> _passwordHasher;
    private readonly ITokenService _tokenService;

    public AccountService(IClientRepository clientRepository, IPasswordHasher<ClientModel> passwordHasher, ITokenService tokenService)
    {
        _clientRepository = clientRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<ClientModel> RegisterUser(string email, string password)
    {
        // Check if user with the given email already exists
        var existingUser = await _clientRepository.GetByEmail(email);
        if (existingUser != null)
        {
            throw new ArgumentException("User with the given email already exists");
        }

        // Hash the password
        var hashedPassword = _passwordHasher.HashPassword(new ClientModel(), password);

        // Create a new user object
        var client = new ClientModel
        {
            Contact.Email = email,
            PasswordHash = hashedPassword
        };

        // Add the user to the database
        await _clientRepository.Create(client);

        return client;
    }

    public async Task<string> Login(string email, string password)
    {
        // Get the user with the given email
        var user = await _clientRepository.GetByEmail(email);
        if (user == null)
        {
            throw new ArgumentException("Invalid email or password");
        }

        // Verify the password
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            throw new ArgumentException("Invalid email or password");
        }

        // Generate a JWT token for the user
        var token = _tokenService.GenerateToken(user);

        return token;
    }
}
