using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Images;
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
    private readonly IUsersRepository _usersRepo;

    public ImagesController( IImagesRepository imagesRepo, IUsersRepository usersRepo)
    {
      _imagesRepo = imagesRepo;
      _usersRepo = usersRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var images = await _imagesRepo.GetAllAsync();

      var imageDto = images.Select(s => s.ToImagesDto());

      return Ok(imageDto);
      
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var images = await _imagesRepo.GetByIdAsync(id);

      if(images == null)
      {
        return NotFound();
      }

      return Ok(images.ToImagesDto());
    }

    [HttpPost("{userID}")]
    public async Task<IActionResult> Create([FromRoute] int userID, CreateImagesDto imagesDto)
    {
      if(!await _usersRepo.UserExists(userID))
      {
        return BadRequest("User does not exist");
      }

      var imagesModel = imagesDto.ToImagesFromCreate(userID);
      await _imagesRepo.CreateAsync(imagesModel);
      return CreatedAtAction(nameof(GetById), new {id = imagesModel.ImageID}, imagesModel.ToImagesDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateImagesRequestDto updateDto)
    {
      var images = await _imagesRepo.UpdateAsync(id, updateDto.ToImagesFromUpdate());

      if(images == null)
      {
        return NotFound("Image not found");
      }

      return Ok(images.ToImagesDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var imagesModel = await _imagesRepo.DeleteAsync(id);

      if(imagesModel == null)
      {
        return NotFound("Image does not exist");
      }

      return Ok(imagesModel);
    }
  }
}