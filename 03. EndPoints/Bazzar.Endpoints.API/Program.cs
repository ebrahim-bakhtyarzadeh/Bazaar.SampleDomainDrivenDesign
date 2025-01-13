using Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers;
using Bazzar.Core.ApplicationServices.UserProfiles.CommandHandlers;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.UserProfiles.Data;
using Bazzar.Infrastructures.Data.InMemory.Advertisments;
using Bazzar.Infrastructures.Data.SqlServer;
using Bazzar.Infrastructures.Data.SqlServer.Advertisments;
using Bazzar.Infrastructures.Data.SqlServer.UserProfiles;
using Framework.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var services = builder.Services;
//builder.Services.AddSingleton<IAdvertisementsRepository, FakeAdvertisementsRepository>();

services.AddScoped<IAdvertisementsRepository, EfAdvertisementsRepository>();
services.AddScoped<IUserProfileRepository, EFUserProfileRepository>();
services.AddScoped<IUnitOfWork, AdvertismentUnitOfWork>();

services.AddScoped<CreateCommandHandler>();
services.AddScoped<RequestToPublishHandler>();
services.AddScoped<SetTitleHandler>();
services.AddScoped<UpdatePriceHandler>();
services.AddScoped<UpdateTextHandler>();

services.AddScoped<RegisterUserHandler>();
services.AddScoped<UpdateUserNameHandler>();
services.AddScoped<UpdateUserEmailHandler>();
services.AddScoped<UpdateUserDisplayNameHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddDbContext<AdvertismentDbContext>(c => c.UseSqlServer("Data Source =.; Initial Catalog=Bazzar; Integrated security =true; TrustServerCertificate=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
