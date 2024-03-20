using Hackathon.Manager.Api.Infra.Configurations;
using Hackathon.Manager.Api.Infra.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .ConfigContext(builder.Configuration)
    .ConfigDependencyInjection()
    .ConfigureCors();

var app = builder.Build();

app.Services.ExecuteMigration();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

await UserPoolUtils.SetValues(builder.Configuration);

app.Run();
