using JsonWebToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUAuditoria;
using Obligatorio.LogicaAplicacion.CasosUso.CUEquipo;
using Obligatorio.LogicaAplicacion.CasosUso.CUGasto;
using Obligatorio.LogicaAplicacion.CasosUso.CULogin;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUServicios;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.iCULogin;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString =
           builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection

// Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT
//La clave está en el appsettings.json
var jwt = builder.Configuration["Jwt:Key"]!;
var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        //Definir las verificaciones a realizar
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = claveCodificada
    };
});

//ID REPOSITORIOS
builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
builder.Services.AddScoped<IRepositorioGasto, RepositorioGasto>();
builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();

//ID de los casos de uso
builder.Services.AddScoped<ICUObtenerPago, CUObtenerPago>();
builder.Services.AddScoped<ICUObtenerPagosPorUsuario, CUObtenerPagosPorUsuario>();
builder.Services.AddScoped<ICUObtenerEquiposPagosUnicosPorMonto, CUObtenerEquiposPagosUnicosPorMonto>();
builder.Services.AddScoped<ICULogin, CULogin>();
builder.Services.AddScoped<ICUResetearPassword, CUResetearPassword>();
builder.Services.AddScoped<ICUAltaPago, CUAltaPago>();
builder.Services.AddScoped<ICUObtenerAuditoriasPorGasto, CUObtenerAuditoriaPorGasto>();
builder.Services.AddScoped<ICUObtenerGastosActivos, CUObtenerGastosActivos>();
builder.Services.AddScoped<IServicioMetodoPago, ServicioMetodoPago>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //esto tiene q estar antes de authorization pq sino no funciona, le pregunta por el token, lo valida y genera los claims del usuario

app.UseAuthorization(); //esto es para verificar si el usuario tiene rol correcto para acceder a un recurso

app.MapControllers();

app.Run();
