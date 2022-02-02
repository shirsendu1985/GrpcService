using GrpcService.Models;
using GrpcService.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();


//builder.Services.AddDbContext<BlazorContext>(options => {
//    options.
//           UseSqlServer(Configuration
//                         .GetConnectionString("AppDbContext"));
//});

builder.Services.AddDbContext<BlazorContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("BlazorContext")));
builder.Services.AddCors(options => {
    options.AddPolicy("cors",
     policy => {
         policy
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .WithExposedHeaders("Grpc-Status",
                                      "Grpc-Message", "Grpc-Encoding",
                                      "Grpc-Accept-Encoding");
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ProductsAppService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
