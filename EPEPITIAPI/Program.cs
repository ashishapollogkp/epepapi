using EPEPITIAPI.DBHelper;
using EPEPITIAPI.EPEPDbContext;
using EPEPITIAPI.Interfaces;
using EPEPITIAPI.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EPEPITIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSingleton<BindDropDownListDAL>();
builder.Services.AddSingleton<JobProfileListDAL>();
builder.Services.AddSingleton<PartnerListDAL>();
builder.Services.AddSingleton<SectorListDAL>();
builder.Services.AddSingleton<UserListDAL>();
builder.Services.AddSingleton<CandidateListDAL>();
builder.Services.AddSingleton<TrainingCenterListDAL>();
builder.Services.AddSingleton<BatchListDAL>();
builder.Services.AddSingleton<AttendanceListDAL>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddTransient<IShared, SharedService>();


builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 52428800; // 50 MB
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 52428800; // 50 MB
});

var app = builder.Build();

// Enable Swagger
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

// Apply CORS policy
app.UseCors("AllowAll");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
