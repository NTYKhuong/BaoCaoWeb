using System.Text;
using System.Text.Json;
using BanDoNoiThat.Data;
using BanDoNoiThat.HealthCheck;
using BanDoNoiThat.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//----------------------------------------
// Get connet string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Config DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
//----------------------------------------

// Register Serilog
builder.Host.UseSerilog((context, config) =>
{
    config.MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning).WriteTo.Console().WriteTo.Debug()
    .WriteTo.File("Logs\\log-.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, buffered: false)
    .WriteTo.MSSqlServer(connectionString,
    sinkOptions: new MSSqlServerSinkOptions
    {
        TableName = "Logs",
        AutoCreateSqlTable = true
    });
});

builder.Services.AddHttpClient<ApiHealthCheck>();
builder.Services.AddHealthChecks()
    .AddCheck("SQL Database", new SqlConnectionHealthCheck(connectionString))
    .AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck))
    .AddDbContextCheck<ApplicationDbContext>()
    .AddCheck<SystemHealthCheck>(nameof(SystemHealthCheck));
//

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add JWT authorization
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true, //kiểm tra token đã hết hạng hay chưa
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKeyQUIMUIITlaptrinhvacotsong")),
    };
});

builder.Services.AddScoped<AuthService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ADMIN", policy =>
        policy.RequireClaim("RoleName", "ADMIN")); // Yêu cầu roleID là ADMIN
});
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
//

//them dich vu Cross origin request sharing vào tất cả các url
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
//

var app = builder.Build();

// Register Serilog
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                exception = entry.Value.Exception?.Message,
                duration = entry.Value.Duration.ToString()
            })
        });
        await context.Response.WriteAsync(result);
    }
});
//

// Add Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    SeedData.SeedDingData(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add authorization
app.MapIdentityApi<IdentityUser>();
//

// Su dung CORS
app.UseCors("AllowAll");
//

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

// Add Auth
app.UseAuthentication();
app.UseAuthorization();
//

app.MapControllers();

app.Run();
