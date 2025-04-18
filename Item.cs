using System;

namespace AdventureInventory;

public class Item
{
    public string Id {get; set;}
    public string Name {get; set;}
    public float SpawnProability {get; set;}
    public Item(string Id, string Name, float SpawnProability){
        this.Id = Id;
        this.Name = Name;
        this.SpawnProability = SpawnProability;
    }

}
