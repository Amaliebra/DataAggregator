var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
