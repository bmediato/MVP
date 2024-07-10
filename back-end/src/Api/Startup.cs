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
        services.Configure<JwtSettings>(Configuration.GetSection(nameof(JwtSettings)));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);


        var key = Encoding.ASCII.GetBytes(Configuration["JwtSettings:Secret"]);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
 
        services.Configure<DatabaseConfig>(Configuration.GetSection(nameof(AppSettings.DatabaseConfig)));
        services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);


        services.AddScoped<IUserMongoDbRepository, UserRepository>();
        services.AddScoped<IRestaurantMongoDbRepository, RestaurantRepository>();


        services.AddTransient<IValidator<UserSaveCommand>, UserSaveCommandValidator>();
        services.AddTransient<IValidator<RestaurantsSaveCommand>, RestaurantsSaveCommandValidator>();


        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RestaurantsSaveCommandHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserSaveCommandHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RestaurantsGetQueryHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RestaurantsGetByIdQueryHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserQueryHandler).Assembly));
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "MvpGrao.Api",
                Description = "This API is responsible for managing user and restaurants information.",
            });
        });

        services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://localhost:4200");
        }));

        services.AddControllers();
        services.AddEndpointsApiExplorer();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MvpGrao.Api v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.UseCors("CorsPolicy");

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
