using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block
{
    private string name;
    public string localizedName;
    public int maxStackAmount = 64;
    public int currentStackAmount = 1;
    public int dropAmount = 1;

    public Block(string name)
    {
        this.name = name;
        this.localizedName = name;
    }

    public Block(Block block)
    {
        name = block.name;
        localizedName = block.localizedName;
        maxStackAmount = block.maxStackAmount;
        currentStackAmount = 1; 
        dropAmount = block.dropAmount;
    }

    public abstract Texture2D GetBlockTexture();
    public abstract Block Copy();

    public string GetName() { return name; }

    public void SetLocalizedName(string name)
    {
        localizedName = name;
    }

    public void SetMaxStackAmount(int amount)
    {
        maxStackAmount = amount;
    }

    public void SetCurrentStackAmount(int amount)
    {
        currentStackAmount = amount;
    }

    public void SetDropAmount(int amount)
    {
        dropAmount = amount;
    }
}
