using EnergyEfficiencyBE.Auth;
using EnergyEfficiencyBE.Context;
using EnergyEfficiencyBE.Context.Seeders;
using EnergyEfficiencyBE.MappingProfiles;
using EnergyEfficiencyBE.Models.Entities.Auth;
using EnergyEfficiencyBE.Repositories.Implementations.Auth;
using EnergyEfficiencyBE.Repositories.Implementations.EfficiencyAdvices;
using EnergyEfficiencyBE.Repositories.Implementations.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.Auth;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyAdvices;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using EnergyEfficiencyBE.Services.Implementations.Auth;
using EnergyEfficiencyBE.Services.Implementations.EfficiencyAdvices;
using EnergyEfficiencyBE.Services.Implementations.EfficiencyClass;
using EnergyEfficiencyBE.Services.Interfaces.Auth;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyAdvices;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RelationalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Relational")));

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Relational")));

builder.Services.AddIdentity<AuthUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPeakEnergyConsumptionRepository, PeakEnergyConsumptionRepository>();
builder.Services.AddScoped<IYearlyCoolingMachinesEfficiencyRepository, YearlyCoolingMachinesEfficiencyRepository>();
builder.Services.AddScoped<IAverageCoolingSystemFactorsRepository, AverageCoolingSubsystemFactorsRepository>();
builder.Services.AddScoped<ILinearHeatTransferFactorRepository, LinearHeatTransferFactorRepository>(); 
builder.Services.AddScoped<IHidraulicAdjustmentFactorRepository, HidraulicAdjustmentFactorRepository>();
builder.Services.AddScoped<IHeatingSystemEfficiencyComponentsRepository, HeatingSystemEfficiencyComponentsRepository>();
builder.Services.AddScoped<ISeasonalHeatGenerationEfficiencyFactorRepository, SeasonalHeatGenerationEfficiencyRepository>();
builder.Services.AddScoped<IAdviceRepository, AdviceRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICoolingEnergyConsumptionService, CoolingEnergyConsumptionService>();
builder.Services.AddScoped<IHeatingEnergyConsumptionService, HeatingEnergyConsumptionService>();
builder.Services.AddScoped<IEnergyEfficiencyClassService, EnergyEfficiencyClassService>();
builder.Services.AddScoped<IAdviceService, AdviceService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "EfficiencyCalculatorApi", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var applicationContext = services.GetRequiredService<RelationalContext>();
    var identityContext = services.GetRequiredService<IdentityContext>();

    if ((await applicationContext.Database.GetPendingMigrationsAsync()).Any())
    {
        applicationContext.Database.Migrate();
    }

    if ((await identityContext.Database.GetPendingMigrationsAsync()).Any())
    {
        await identityContext.Database.MigrateAsync();
    }

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<AuthUser>>();
    var peakEnergyRepository = services.GetRequiredService<IPeakEnergyConsumptionRepository>();
    var yearlyCoolingMachinesEfficiencyRepository = services.GetRequiredService<IYearlyCoolingMachinesEfficiencyRepository>();
    var averageCoolingFactorsRepository = services.GetRequiredService<IAverageCoolingSystemFactorsRepository>();
    var linearHeatTransferRepository = services.GetRequiredService<ILinearHeatTransferFactorRepository>();
    var hidraulicFactorRepository = services.GetRequiredService<IHidraulicAdjustmentFactorRepository>();
    var heatingSystemEficiencyComponentsRepository = services.GetRequiredService<IHeatingSystemEfficiencyComponentsRepository>();
    var seasonalRepository = services.GetRequiredService<ISeasonalHeatGenerationEfficiencyFactorRepository>();

    await RolesSeeder.SeedRolesAsync(roleManager);
    await TestUserSeeder.SeedTestUserAsync(applicationContext, userManager);
    await PeakEnergyConsumptionTableSeeder.SeedTableAsync(peakEnergyRepository);
    await YearlyCoolingMachinesEfficiencyTableSeeder.SeedTableAsync(yearlyCoolingMachinesEfficiencyRepository);
    await AverageCoolingSystemFactorsSeeder.SeedTableAsync(averageCoolingFactorsRepository);
    await LinearHeatTransferFactorSeeder.SeedTableAsync(linearHeatTransferRepository);
    await HidraulicAdjustmentFactorTableSeeder.SeedTableAsync(hidraulicFactorRepository);
    await HeatingSystemEfficiencyComponentsSeeder.SeedTableAsync(heatingSystemEficiencyComponentsRepository);
    await SeasonalHeatGenerationEfficiencyFactorSeeder.SeedTableAsync(seasonalRepository);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")),
//    RequestPath = "/Images"
//});

app.Run();

try
{
    Log.Information("Starting web host");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
