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

        services.AddScoped<IUserMongoDbRepository, UserRepository>();
        services.AddScoped<IRestaurantMongoDbRepository, RestaurantRepository>();
        services.AddScoped<IUserSaveHandlerService, UserSaveCommandHandler>();
        services.AddScoped<IRestaurantSaveHandlerService, RestaurantsSaveCommandHandler>();
        services.AddTransient<IValidator<UserSaveCommand>, UserSaveCommandValidator>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        IMapper mapper = new UserProfile().Configuration().CreateMapper();
        services.AddSingleton(mapper);

        IMapper mapperRest = new RestaurantProfile().Configuration().CreateMapper();
        services.AddSingleton(mapperRest);

        services.AddTransient<IUserMongoDbRepository, UserRepository>();
        services.AddTransient<IRestaurantMongoDbRepository, RestaurantRepository>();

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
