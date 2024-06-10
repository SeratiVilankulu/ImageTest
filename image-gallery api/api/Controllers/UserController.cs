using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Users;
using api.Interfaces;
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
    private readonly IUsersRepository _usersRepo;
    public UserController(ApplicationDBContext context, IUsersRepository usersRepo)
    {
      _usersRepo = usersRepo;
      _context = context;
    }  

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var users = await _usersRepo.GetAllAsync();
      
      var usersDto = users.Select(s => s.ToUserDto());

      return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var user = await _usersRepo.GetByIdAsync(id);
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
      await _usersRepo.CreateAsync(usersModel);
      return CreatedAtAction(nameof(GetById), new {id = usersModel.UserID}, usersModel.ToUserDto());
    }

    [HttpPut]
    [Route("{id}")]

    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUsersRequestDto updateDto)
    {
      var usersModel = await _usersRepo.UpdateAsync(id, updateDto);
      
      if(usersModel == null)
      {
        return NotFound();
      }

      return Ok(usersModel.ToUserDto());
    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var usersModel = await _usersRepo.DeleteAsync(id);

      if(usersModel == null)
      {
        return NotFound();
      }

      return NoContent();

    }
  }
}