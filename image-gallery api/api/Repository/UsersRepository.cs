using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Users;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class UsersRepository : IUsersRepository
  {
    private readonly ApplicationDBContext _context;

    public UsersRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<Users> CreateAsync(Users usersModel)
    {
      await _context.Users.AddAsync(usersModel);
      await _context.SaveChangesAsync();
      return usersModel;
    }

    public async Task<Users?> DeleteAsync(int id)
    {
      var usersModel = await _context.Users.FirstOrDefaultAsync(x => x.UserID == id);

      if(usersModel == null)
      {
        return null;
      }

      _context.Users.Remove(usersModel);
      await _context.SaveChangesAsync();
      return usersModel;
    }

    public async Task<List<Users>> GetAllAsync()
    {;
      return await _context.Users.ToListAsync();
    }

    public async Task<Users?> GetByIdAsync(int id)
    {
      return await _context.Users.FindAsync(id);
    }

    public async Task<Users?> UpdateAsync(int id, UpdateUsersRequestDto usersDto)
    {
      var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.UserID == id);

      if(existingUser == null)
      {
        return null;
      }

      existingUser.FirstName = usersDto.FirstName;
      existingUser.LastName = usersDto.LastName;
      existingUser.UserName = usersDto.UserName;
      existingUser.Email = usersDto.Email;
      existingUser.Password = usersDto.Password;
      existingUser.Salt = usersDto.Salt;
      existingUser.ProfileCreateDate = usersDto.ProfileCreateDate;
      existingUser.PasswordChangeDate = usersDto.PasswordChangeDate;

      await _context.SaveChangesAsync();

      return existingUser;
    }
 }
}