using NTierArchTestProject.BusinessLogicLayer.Extensions;
using NTierArchTestProject.DataAccessLayer.Extensions;
using NTierArchTestProject.WebAPI.Extensions;
using NTierArchTestProject.WebAPI.Middleware;

//DI Container
var builder = WebApplication.CreateBuilder(args);

//Registirations (Dal,Bll,Presentation)
builder.Services.AddDalCustomService(builder.Configuration)
.AddBllCustomService(builder.Configuration)
.AddCustomApiService(builder.Configuration);


//Middleware
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
