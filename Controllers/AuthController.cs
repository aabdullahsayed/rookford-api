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
    public async Task <IActionResult> Create(User user)
    {
        _context.Add(user);

       await _context.SaveChangesAsync();

       return CreatedAtAction(nameof(Read), new { id = user.ID }, user);

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