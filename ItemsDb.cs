using System;
using Microsoft.EntityFrameworkCore;

namespace AdventureInventory;

public class ItemsDb : DbContext
{
    public ItemsDb(DbContextOptions<ItemsDb> options)
    : base(options) { }

    public DbSet<Item> Items => Set<Item>();
}
