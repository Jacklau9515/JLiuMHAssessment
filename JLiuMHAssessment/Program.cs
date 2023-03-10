using JLiuMHAssessment.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy(name: "AllowOrigin",
                  policy =>
                  {
                      policy.WithOrigins("http://localhost:3000"); // add the allowed origins  
                  });
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();

// Load Dependacy Services
builder.Services.AddScoped<ICalculatorRepository, CalculatorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();