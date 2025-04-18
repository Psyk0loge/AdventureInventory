var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
//Todo: check if I need this
app.UseAuthorization();
app.UseRouting();

app.UseAntiforgery();

app.Run();