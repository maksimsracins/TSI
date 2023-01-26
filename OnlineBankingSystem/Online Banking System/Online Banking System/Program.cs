
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles(); //show css files
//app.UseMvcWithDefaultRoute(); //trace url

app.MapGet("/", () => "Hello World!"); app.Run();
