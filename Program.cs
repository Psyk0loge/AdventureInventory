
using AdventureInventory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ItemsDb>(opt =>
opt.UseInMemoryDatabase("ItemsList"));

//Ads nice logging for database erros that origin from entity framework
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Register services for Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Routes
app.MapGet("/items", async (ItemsDb db) =>
    await db.Items.ToListAsync());

app.MapGet("/items/{id}", async (int id, ItemsDb db) =>
    await db.Items.FindAsync(id)
        is Item item
            ? Results.Ok(item)
            : Results.NotFound());

app.MapPost("/item", async (Item item, ItemsDb db) =>{
    db.Items.Add(item);
    await db.SaveChangesAsync();

    return Results.Created($"/items/{item.Name}", item);
});

app.MapDelete("item", (string id, ItemsDb db) =>{
    var countItemsDeleted = db.Items.Where(x => x.Id == id).ExecuteDeleteAsync();
    return Results.Ok($"Deleted {countItemsDeleted} elements");
});

// Enable Swagger in development and optionally in production
app.UseSwagger();
app.UseSwaggerUI();

app.Run();