using LOOKAZ_WEB_API.SignalR;
//using LOOKAZ_WEB_API.WorkerManagers;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//
builder.Services.AddSignalR(option =>
{
    option.HandshakeTimeout = new TimeSpan(0, 1, 0);
    option.KeepAliveInterval = new TimeSpan(0, 1, 0);
    option.EnableDetailedErrors = true;
});

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new string[] { "application/octet-stream" });
});
//

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<LOOKAZ>("/LOOKAZ");

app.Run();

//new DeviceWorker().TestStart("Test");
