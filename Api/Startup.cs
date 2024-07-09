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
        // Configurações de Banco de Dados
        services.Configure<DatabaseConfig>(Configuration.GetSection(nameof(DatabaseConfig)));
        services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);

        // Registro de Repositórios
        services.AddScoped<IUserMongoDbRepository, UserRepository>();
        services.AddScoped<IRestaurantMongoDbRepository, RestaurantRepository>();

        // Registro de Serviços
        services.AddScoped<IUserSaveHandlerService, UserSaveCommandHandler>();
        services.AddScoped<IRestaurantSaveHandlerService, RestaurantsSaveCommandHandler>();
        services.AddScoped<IRestaurantService, RestaurantService>();

        // Registro de Validadores
        services.AddTransient<IValidator<UserSaveCommand>, UserSaveCommandValidator>();

        // Configuração do AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        IMapper mapper = new UserProfile().Configuration().CreateMapper();
        services.AddSingleton(mapper);

        IMapper mapperRest = new RestaurantProfile().Configuration().CreateMapper();
        services.AddSingleton(mapperRest);

        //services.AddTransient<IUserMongoDbRepository, UserRepository>();
        //services.AddTransient<IRestaurantMongoDbRepository, RestaurantRepository>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "MvpGrao.Api",
                Description = "This API is responsible for managing user and restaurants information.",
            });
        });

        //services.AddCors(options =>
        //{
        //    options.AddPolicy("AllowAll",
        //        policy =>
        //        {
        //            policy.WithOrigins("http://localhost:3000")
        //                  .AllowAnyMethod()
        //                  .AllowAnyHeader()
        //                  .AllowCredentials();
        //        });
        //});
        services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
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

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
