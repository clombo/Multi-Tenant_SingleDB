using MTA.API.Middleware;
using MTA.API.Services;
using MTA.API.Swagger;
using MTA.Data;
using MTA.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddData(builder.Configuration);

// Current tenant service with scoped lifetime (created per each request)
builder.Services.AddScoped<ICurrentTenant, CurrentTenant>();

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    config =>
        config.OperationFilter<TenantHeaderFilter>()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseMiddleware<TenantHeaderResolver>();

app.MapControllers();

app.Run();