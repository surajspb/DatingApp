using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context; //priivate field 
public UsersController(DataContext context)
{
    _context = context ;
}
[HttpGet]

//public ActionResult<IEnumerable<AppUser>>GetUser()   //Synchronous Operation 
//{

  //  var users = _context.Users.ToList();
    //return users;
//}


public async Task<ActionResult<IEnumerable<AppUser>>>GetUser()  //Asynchronous operation using async await  
{

    var users = await _context.Users.ToListAsync();
    return users;
}

[HttpGet("{id}")]

//public ActionResult<AppUser>GetUser(int id)  //Synchronous 
//{
  //  var user=_context.Users.Find(id);
    //return user;
//}

public async Task<ActionResult<AppUser>>GetUser(int id)
{
    var user=await _context.Users.FindAsync(id);
    return user;
}


}

