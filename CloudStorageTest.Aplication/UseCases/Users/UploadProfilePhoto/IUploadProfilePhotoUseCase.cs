using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageTest.Aplication.UseCases.Users.UploadProfilePhoto;
public interface IUploadProfilePhotoUseCase
{

    public void Excecute(IFormFile file);
}
