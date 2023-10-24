using ListaDeCompromisso.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// configurar o Entity Framework
builder.AddEntityFrameworkConfiguration();
builder.AddJwt();

#region CORS - Cross Origin Resource Sharing

builder.Services.AddCors(
s => s.AddPolicy("DefaultPolicy",
builder =>
{
    builder.AllowAnyOrigin()//clientes de qualquer origem
    .AllowAnyMethod()  //qualquer método (POST, PUT, DELETE, GET, etc)
    .AllowAnyHeader(); //qualquer cabeçalho
})
);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();

#region CORS - Cross Origin Resource Sharing

app.UseCors("DefaultPolicy");

#endregion

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
