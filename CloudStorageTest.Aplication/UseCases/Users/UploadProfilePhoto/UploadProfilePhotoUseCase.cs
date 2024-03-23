using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Aplication.UseCases.Users.UploadProfilePhoto;
public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase

{

    private readonly IStorageService _storageService;

    //dependecy injection
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Excecute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        //regras de negócio
        // IFileType fileType = FileTypeValidator.GetFileType(fileStream);
        var isNotAnImage = !fileStream.Is<PortableNetworkGraphic>() && !fileStream.Is<JointPhotographicExpertsGroup>();

        if (isNotAnImage)
        {
            throw new Exception("The file is not an image.");
        }

        var user = GetUserFromDataBase();

        _storageService.Upload(file, user);

    }
        private User GetUserFromDataBase()
        {
        var user = new User
        {
            Id = 1,
            Name = "Ednei",
            Email = "fenderlopes@gmail.com"

        };

         return user;
        }
    }

    