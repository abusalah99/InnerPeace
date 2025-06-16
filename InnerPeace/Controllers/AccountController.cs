using System.Security.Claims;
using InnerPeace.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace InnerPeace.Controllers;

public class AccountController(ApplicationDbContext context) : Controller
{
    [HttpGet("account/register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("account/register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(
        string name,
        string email,
        string password,
        string phone,
        DateTime birthday,
        bool isMale)
    {
        if (string.IsNullOrEmpty(name) || 
            string.IsNullOrEmpty(email) || 
            string.IsNullOrEmpty(password) || 
            string.IsNullOrEmpty(phone) ||
            birthday == default)
        {
            ModelState.AddModelError("", "Please fill all required fields.");
            return View();
        }

        if (await context.Users.AnyAsync(u => u.Email == email))
        {
            ModelState.AddModelError(nameof(email), "Email is already registered");
            return View();
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            Password = password.HashPassword(),
            Phone = phone,
            Birthday = birthday,
            IsMale = isMale
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "User")
        };

        var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        await HttpContext.SignInAsync(
            "MyCookieAuth",
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("account/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("account/login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var hashedPassword = password.HashPassword();
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);

        if (user == null)
        {
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "User")
        };

        var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        await HttpContext.SignInAsync(
            "MyCookieAuth",
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return RedirectToAction("Index", "Home");
    }
    [Authorize]
    [HttpGet("account/logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("MyCookieAuth");
        
        return RedirectToAction("Index", "Home");
    }
}
