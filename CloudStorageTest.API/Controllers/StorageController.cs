using CloudStorageTest.Aplication.UseCases.Users.UploadProfilePhoto;
using CloudStorageTest.Domain.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorageTest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{

    [HttpPost]
    public IActionResult UploadImage([FromServices] IUploadProfilePhotoUseCase useCase, IFormFile file)
    {
        
        useCase.Excecute(file);
        return Created();
    }

   
}
