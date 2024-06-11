using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class ImagesRepository : IImagesRepository
  {
    private readonly ApplicationDBContext _context;
    public ImagesRepository(ApplicationDBContext context)
    {
      _context = context;
    }
    public async Task<List<Images>> GetAllAsync()
    {
      return await _context.Images.ToListAsync();
    }
  }
}