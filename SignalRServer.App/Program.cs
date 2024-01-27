using SignalRServer.App.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(op => op.AddDefaultPolicy(pol =>
    pol.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(_ => true)));
builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<MyHub>("/myHub");
app.Run();
