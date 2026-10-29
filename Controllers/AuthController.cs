using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rookford.Data;
//using Rookford.DTOs;
using Rookford.Models;

namespace rookford_api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher = new();

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _context.Add(user);

        return Ok(_context.users);
    }
}