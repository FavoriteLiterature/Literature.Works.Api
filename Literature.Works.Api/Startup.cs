﻿using Hellang.Middleware.ProblemDetails;
using Literature.Works.Api.Infrastructure;
using Literature.Works.Api.Infrastructure.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        services.AddProblemDetails(options =>
        {
            options.Map<ArgumentException>(exception => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = exception.Message,
            });
        });
        
        services
            .AddMediatR(typeof(Startup))
            .AddAutoMapper(typeof(Startup));

        services
            .AddDbContext<DataContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<IRepository, DataContext>();

        services.AddSwaggerGen();

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseProblemDetails();
            
            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
        }

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}