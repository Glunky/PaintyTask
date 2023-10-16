using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaintyTask.BusinessLogic.Implementation;
using PaintyTask.BusinessLogic.Interfaces;
using PaintyTask.DbProvider;
using PaintyTask.Mapping.Implementation;
using PaintyTask.Mapping.Interfaces;
using PaintyTask.Models.DB;
using WebBaraholkaAPI.Business.Commands.Implementations.Auth;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

services.AddIdentity<DbAppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


services.AddScoped<ISignUpCommand, SignUpCommand>();
services.AddScoped<ISignInCommand, SignInCommand>();

services.AddSingleton<ISignUpRequestToDbAppUserMapper, SignUpRequestToDbAppUserMapper>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
// TODO: подумать над надваниями контроллеров и правильным расположением файлов + rest