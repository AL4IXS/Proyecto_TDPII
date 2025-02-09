using Microsoft.EntityFrameworkCore;
using Proyecto_TDPII.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Conexion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));*/

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    //ESTO ES UNA PRUEBA HECHA POR ALEXIS

    //ESTOS ES UNA SEGINDA PRUEBA 
    
    //HUIDA Masiva a ver youtube

    //ESTOS UNA PRUEBA DEFINITIVA

    //YA PORFAVOR!

    //HOLA COMO ESTÁN?

    //MUY BIEN Y TU?

    //Cuál es tu talla?

    // DE QUE ME HABLAS ??

    //buenas noches 

    //que onda panas
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
