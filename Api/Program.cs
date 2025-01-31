using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGenCustomConfig();
builder.Services.AddPostgreSqlDbContext(builder.Configuration);
builder.Services.AddPostgreSqlIdentityContext();
builder.Services.AddConfigureIdentityOptions();
builder.Services.AddJwtTokenGenerator();
builder.Services.AddAuthenticationConfig(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddShoppingCartService();
builder.Services.AddOrdersService();
builder.Services.AddPaymentService();
builder.Services.AddFileStorageService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.UseCors(c =>
    c.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .WithExposedHeaders("*")
    );

app.UseAuthentication();
app.UseAuthorization();

await app.Services.InitializeRoleAsync();

app.Run();