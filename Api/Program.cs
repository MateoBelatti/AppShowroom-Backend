using Api.Middlewares;
using biblioteca;
using biblioteca.mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Services.Services.auth;
using Services.Services.carrito;
using Services.Services.categoria;
using Services.Services.detalleCarrito;
using Services.Services.producto;
using Services.Services.usuarios;
using Services.Services.vela;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Inyección de Interfaces y Servicios
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IDetalleCarritoService, DetalleCarritoService>();
builder.Services.AddScoped<ICarritoService, CarritoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IVelaService, VelaService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthGoogleService, AuthGoogleService>();
builder.Services.AddScoped<IJwtService, JwtService>();

// Inyeccion de Interfaces y Repositorios
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDetalleCarritoRepository, DetalleCarritoRepository>();
builder.Services.AddScoped<ICarritoRepository, CarritoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IVelaRepository, VelaRepository>();

// Inyeccion de Mappers
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CategoriaProfile>();
    cfg.AddProfile<ProductoProfile>();
    cfg.AddProfile<UsuarioProfile>();
    cfg.AddProfile<DetalleCarritoProfile>();
    cfg.AddProfile<CarritoProfile>();
    cfg.AddProfile<VelaProfile>();
});

// Inyeccion de base de datos
builder.Services.AddDbContext<CanelaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication

builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options => {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = builder.Configuration["Jwt:Issuer"],
          ValidAudience = builder.Configuration["Jwt:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)
        )
      };
  });

builder.Services.AddAuthorization();

// CORS — permitir el frontend
builder.Services.AddCors(options => {
    options.AddPolicy("Frontend", policy =>
      policy.WithOrigins("http://localhost:5173", "https://canelaartesanias.vercel.app")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CanelaContext>();

    // Aplica las migraciones pendientes al iniciar la aplicación
    // uso mientras esta en desarrollo
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // 👈 AGREGA ESTA LÍNEA
    app.UseSwaggerUI(); // 👈 AGREGA ESTA LÍNEA (Esta es la interfaz gráfica)
}


app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
