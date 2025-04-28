using System.Reflection;
using Api.Middlewares;
using Application.UseCases.CrearMateriasProfesor;
using Infrastructure.Configuration;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Configuration;
using Microsoft.OpenApi.Models;
using Application.UseCases.ValidarToken;
using Application.UseCases.RegistrarUsuarioEstudiante;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers()
        .AddJsonOptions(JsonOptions =>
                JsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Homework", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }

    });


    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(
        typeof(TokenValidationHadler).Assembly,
        typeof(UsuarioEstudianteHandler).Assembly
    );
});




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("*")
        .WithOrigins("http://localhost:4200")
        .WithOrigins("*")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddDbContext<PruebaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdEM"),
    sqlServerOptionsAction: options =>
    {
        options.EnableRetryOnFailure();
    });

});
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(typeof(MateriaProfesorHandler).GetTypeInfo().Assembly);
});
builder.Services.AddHealthChecks();
builder.Services.ConfigureRepository();
builder.Services.ConfigureServices();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseCors();
app.UseCors("AllowAngular");
app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("/health");
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
