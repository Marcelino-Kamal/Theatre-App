using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Data;
namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountsContext _context;

        public AccountController(AccountsContext context)
        {
            _context = context;
        }
        //hashes password
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashBytes);
        }
//shows signup view
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserModel user)
        {
            //checks for missing information
            if (string.IsNullOrWhiteSpace(user.fullName) || string.IsNullOrWhiteSpace(user.phoneNumber) || string.IsNullOrWhiteSpace(user.password))
            {
                ViewBag.ErrorMessage = "All fields must be filled.";
                return View();
            }
            //removes extra white spaces and checks if phone number is valid, checks if length between 8 for landlines and 14 for longer area codes and + sign
            string trimmed = user.phoneNumber.Trim();
            if (!Regex.IsMatch(trimmed, @"^\+?\d{8,13}$"))
            {
                ViewBag.ErrorMessage = "Invalid phone number.";
                return View();
            }

            //checks if phone number is already registered
            bool numberRegistered = _context.Users.Any(u => u.phoneNumber == trimmed);
            if (numberRegistered)
            {
                ViewBag.ErrorMessage = "This phone number is already registered.";
                return View();
            }

            string hash = HashPassword(user.password);

            //adds information to db
            var newUser = new UserModel
            {
                phoneNumber = trimmed,
                password = hash,
                fullName = user.fullName
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
//shows log in view
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            //checks that fields are filled
            if (string.IsNullOrWhiteSpace(user.phoneNumber) || string.IsNullOrWhiteSpace(user.password))
            {
                ViewBag.ErrorMessage = "Both fields are required.";
                return View();
            }
            //removes whitespacees from number and hashes password
            string trimmedPhone = user.phoneNumber.Trim();
            string hash = HashPassword(user.password);
            //checks if user is registered
            bool userExists = _context.Users
                .Any(u => u.phoneNumber == trimmedPhone && u.password == hash);


            if (userExists)
            {
                // sends to main page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //throws error message
                ViewBag.ErrorMessage = "Invalid phone number or password.";
                return View();
            }
        }
    }
}