using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/images")]
  [ApiController]
  public class ImagesController : ControllerBase
  {
    private readonly IImagesRepository _imagesRepo;

    public ImagesController( IImagesRepository imagesRepo)
    {
      _imagesRepo = imagesRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var images = await _imagesRepo.GetAllAsync();

      var imageDto = images.Select(s => s.ToImagesDto());

      return Ok(imageDto);
      
    }
  }
}