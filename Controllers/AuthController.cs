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

        _context.SaveChanges();

        return Ok(_context.users);
    }

    [HttpGet]
    public IActionResult Read(int id)
    {
        var user = _context.users.Find(id);

        if (user == null)
        {
            return NotFound("The User is not Available");
        }

        return Ok(user.Name);
    }
}