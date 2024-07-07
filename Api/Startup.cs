using AutoMapper;
using Domain.Interfaces.v1.Configurations;
using Domain.Interfaces.v1.Repositories.MongoDb.User;
using Domain.Interfaces.v1.Services.User;
using Domain.Profiles.v1.User;
using Domain.Services.v1.User;
using Infrastructure.Data.v1.MongoDb.Repositories.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<DatabaseConfig>(Configuration.GetSection(nameof(DatabaseConfig)));
        services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);

        var assemblies = new[]
        {
                Assembly.GetExecutingAssembly(),
                typeof(UserSaveCommand).Assembly // Assembly onde está UserSaveCommand
            };

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
        services.AddScoped<IUserMongoDbRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        IMapper mapper = new UserProfile().Configuration().CreateMapper();
        services.AddSingleton(mapper);

        services.AddTransient<IUserMongoDbRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "MvpGrao.Api",
                Description = "This API is responsible for managing user and restaurants information.",
            });
        });

        services.AddCors(options =>
        {
            options.AddPolicy(name: "development",
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                    policy.AllowCredentials();
                });
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseRouting();

        app.UseCors("development");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
