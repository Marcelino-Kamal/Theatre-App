using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using TheatreApp.DTO;
using TheatreApp.Helpers;
using TheatreApp.Models;
using TheatreApp.Repositories;
using TheatreApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _repo;

    public UserService(IUserRepo repo)
    {
        _repo = repo;
    }

    public TokenDTO Login(UserDTO dto, out string errorMessage)
    {
        errorMessage = null;

        if (string.IsNullOrWhiteSpace(dto.PhoneNumber) || string.IsNullOrWhiteSpace(dto.Password))
        {
            errorMessage = "Both fields are required.";
            return null;
        }

        string trimmedPhone = dto.PhoneNumber.Trim();
        var user = _repo.GetByNumber(trimmedPhone);

        if (user == null)
        {
            errorMessage = "Invalid phone number or password.";
            return null;
        }

        var result = new PasswordHasher<object>().VerifyHashedPassword(null, user.password, dto.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            errorMessage = "Invalid phone number or password.";
            return null;
        }

        string token = JwtTokenHelper.GenerateToken(trimmedPhone);

        return new TokenDTO
        {
            Token = token,
            FullName = user.fullName,
            PhoneNumber = trimmedPhone
        };
    }

    public TokenDTO Register(UserDTO dto, out string errorMessage)
    {
        errorMessage = null;

        if (string.IsNullOrWhiteSpace(dto.FullName) ||
            string.IsNullOrWhiteSpace(dto.PhoneNumber) ||
            string.IsNullOrWhiteSpace(dto.Password))
        {
            errorMessage = "All fields must be filled.";
            return null;
        }

        string trimmedPhone = dto.PhoneNumber.Trim();

        if (!Regex.IsMatch(trimmedPhone, @"^\+?\d{8,13}$"))
        {
            errorMessage = "Invalid phone number format.";
            return null;
        }
        
        if (_repo.GetByNumber(trimmedPhone) != null )
        {
            errorMessage = "This phone number is already registered.";
            return null;
        }

        string hashed = new PasswordHasher<object>().HashPassword(null, dto.Password);

        var user = new UserModel
        {
            fullName = dto.FullName,
            phoneNumber = trimmedPhone,
            password = hashed
        };

        _repo.AddUser(user);

        string token = JwtTokenHelper.GenerateToken(trimmedPhone);

        return new TokenDTO
        {
            Token = token,
            FullName = user.fullName,
            PhoneNumber = trimmedPhone
        };
    }
}