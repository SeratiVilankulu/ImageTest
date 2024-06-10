using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Users;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    public UserController(ApplicationDBContext context)
    {
      _context = context;
    }  

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var users = await _context.Users.ToListAsync();
      
      var usersDto = users.Select(s => s.ToUserDto());

      return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var user = await _context.Users.FindAsync(id);

      if(user == null)
      {
        return NotFound();
      }
      
      return Ok(user.ToUserDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUsersRequestDto usersDto)
    {
      var  usersModel = usersDto.ToUsersFromCreateDTO();
      await _context.Users.AddAsync(usersModel);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new {id = usersModel.UserID}, usersModel.ToUserDto());
    }

    [HttpPut]
    [Route("{id}")]

    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsersRequestDto updateDto)
    {
      var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.UserID == id);
      
      if(usersModel == null)
      {
        return NotFound();
      }

      usersModel.FirstName = updateDto.FirstName;
      usersModel.LastName = updateDto.LastName;
      usersModel.UserName = updateDto.UserName;
      usersModel.Email = updateDto.Email;
      usersModel.Password = updateDto.Password;
      usersModel.Salt = updateDto.Salt;
      usersModel.ProfileCreateDate = updateDto.ProfileCreateDate;
      usersModel.PasswordChangeDate = updateDto.PasswordChangeDate;

      await _context.SaveChangesAsync();

      return Ok(usersModel.ToUserDto());
    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var usersModel = await _context.Users.FirstOrDefaultAsync(X => X.UserID == id);

      if(usersModel == null)
      {
        return NotFound();
      }

      _context.Users.Remove(usersModel);

      await _context.SaveChangesAsync();

      return NoContent();

    }
  }
}