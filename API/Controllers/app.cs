using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class appController : ControllerBase
{
    private readonly DataContext _context;
    public appController(DataContext context)
    {
        _context= context;
    }

    [HttpPost("Register")]  // api/BaseApi/Register

    public async Task<ActionResult<AppUser>>Register(string username , string password )
    {

        using var hmac=new HMACSHA512(); ///for Hashing password  , using to dispose class after being used U

        var user = new AppUser
        {

            UserName=username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key

        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;

    }

}
