using api.Configurations;
using ConfigurationSubstitution;
using data;
using VeggieLink.Api.Configurations;
using VeggieLink.Api.Extensions;
using VeggieLink.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

InjectEnvironments.Load();
builder.Configuration.EnableSubstitutions();
RegisterDocumentMapping.RegisterDocumentsMapping();
builder.Services.AddDependencies(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AutoMapperServiceConfig(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerServiceConfig();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(ExceptionFilter));
    // opt.Filters.Add(typeof(ValidacaoUsuarioFilter));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AuthServiceConfig(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AuthAppConfig();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();


