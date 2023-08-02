﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Novin.FoodApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Infrastructure.Security
{
    public static class SecurityServices
    {
        public static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<NovinFoodAppDB>(options =>
            {
                options.UseSqlServer
                       (builder.Configuration
                               .GetConnectionString("MainDB"));
            });

            builder.Services.AddCors(options
                => options.AddDefaultPolicy(builder =>
                builder
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod())
                );

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddAuthorization();
        }
        public static void UseServices(WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
        }
    }
}
