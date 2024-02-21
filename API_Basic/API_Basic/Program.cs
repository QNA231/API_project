using API_Basic.Entities;

var builder = WebApplication.CreateBuilder(args);

var dbContext = new AppDbContext();

//seed data
if(dbContext.HocSinh.Count() == 0)
{
    for (int i = 0; i < 1000; i++)
    {
        var newhs = new HocSinh()
        {
            LopId = 5,
            HoTen = $"Hoc sinh {i}",
            NgaySinh = new DateTime(2000, 1, 1),
            QueQuan = "ABC"
        };
        dbContext.HocSinh.Add(newhs);
    }
    dbContext.SaveChanges();
}

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
