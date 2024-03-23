using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageTest.Infrastructure.Storage;
public class DroBoxtorageService : IStorageService
{
    public string Upload(IFormFile file, User user)
    {
        throw new NotImplementedException();
    }
}
