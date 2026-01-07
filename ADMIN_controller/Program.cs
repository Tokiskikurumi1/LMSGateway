using ADMIN.DAL.Interface;
using ADMIN.DbConnect;
using QLY_LMS.BLL.Admin_BLL.BLL_Implementations;
using QLY_LMS.BLL.Admin_BLL.BLL_Interfaces;
using QLY_LMS.DAL.Admin.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserDAL, DAL_UserTable>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<DBConnect>(); 
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
