using CloudStorageTest.Aplication.UseCases.Users.UploadProfilePhoto;
using CloudStorageTest.Domain.Storage;
using CloudStorageTest.Infrastructure.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUploadProfilePhotoUseCase, UploadProfilePhotoUseCase>();

builder.Services.AddScoped<IStorageService>(options =>
{
    IEnumerable<string> Scopes = [Google.Apis.Drive.v3.DriveService.Scope.Drive];

    GoogleAuthorizationCodeFlow initializer = new(new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new ClientSecrets
        {
            ClientId = builder.Configuration.GetValue<string>("CloudStorage:ClientId"),
            ClientSecret = builder.Configuration.GetValue<string>("CloudStorage:ClientSecret"),


        },
        Scopes = Scopes,
        DataStore = new FileDataStore("GoogleStorageTest")
        // DataStore = new FileDataStore("Store"),
    }); ;

    return new GoogleCloudStorageService(initializer);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
