using ApiProdutos.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Configurações do projeto AspNet

AutoMapperConfiguration.AddAutoMapper(builder);
CorsConfiguration.AddCors(builder);
EntityFrameworkConfiguration.AddEntityFramework(builder);
SwaggerConfiguration.AddSwagger(builder);
JwtConfiguration.AddJwt(builder);

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

CorsConfiguration.UseCors(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();