using SistemaDeClinicas.Entidades;
using Microsoft.EntityFrameworkCore;
using SistemaDeClinicas.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ClinicaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));
builder.Services.AddTransient<IMedicoServicio,MedicoServicio>();
builder.Services.AddTransient<IPacienteServicio,PacienteServicio>();
builder.Services.AddTransient<IConsultaServicio,ConsultaServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
