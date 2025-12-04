using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUEquipo;
using Obligatorio.LogicaAplicacion.CasosUso.CUGasto;
using Obligatorio.LogicaAplicacion.CasosUso.CULogin;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUServicios;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.iCULogin;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUServicios;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar la cadena de conexión (desde appsettings.json)
            var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection

            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            //ID REPOSITORIOS
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioGasto, RepositorioGasto>();
            builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();

            //ID de los casos de uso
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUAltaGasto, CUAltaGasto>();
            builder.Services.AddScoped<ICUObtenerGasto, CUObtenerGasto>();
            builder.Services.AddScoped<ICUEditarGasto, CUEditarGasto>();
            builder.Services.AddScoped<ICUObtenerGastos, CUObtenerGastos>();
            builder.Services.AddScoped<ICUObtenerGastosActivos, CUObtenerGastosActivos>();
            builder.Services.AddScoped<IServicioAuditoria, ServicioAuditoria>();
            builder.Services.AddScoped<IServicioMetodoPago, ServicioMetodoPago>();
            builder.Services.AddScoped<ICUEliminarGasto, CUEliminarGasto>();
            builder.Services.AddScoped<ICUAltaPago, CUAltaPago>();
            builder.Services.AddScoped<ICUObtenerPagosPorMesAnio, CUObtenerPagosPorMesAnio>();
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUObtenerEquipos, CUObtenerEquipos>();
            builder.Services.AddScoped<ICUObtenerPago, CUObtenerPago>();
            builder.Services.AddScoped<ICUObtenerUsuarioPorMonto, CUObtenerUsuarioPorMonto>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
