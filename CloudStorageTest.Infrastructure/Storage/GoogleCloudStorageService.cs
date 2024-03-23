using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageTest.Infrastructure.Storage;
public class GoogleCloudStorageService : IStorageService
{

    private readonly GoogleAuthorizationCodeFlow _authorization;

    public GoogleCloudStorageService(GoogleAuthorizationCodeFlow authorization)
    {
        _authorization = authorization;
    }

    public string Upload(IFormFile file, User user)
    {
        var sercive = new DriveService();

        var driveFile = new Google.Apis.Drive.v3.Data.File
        {
            Name = file.Name,
            MimeType =  file.ContentType

        };

        var command =  sercive.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
        var response = command.Upload();

        if(response.Status is not Google.Apis.Upload.UploadStatus.Completed or Google.Apis.Upload.UploadStatus.NotStarted)
        {
            throw response.Exception;
        }

        return command.ResponseBody.;

    }
}
