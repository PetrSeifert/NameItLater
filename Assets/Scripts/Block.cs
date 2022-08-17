using UnityEngine;

public abstract class Block
{
    private string name;
    public string localizedName;
    public int maxStackAmount = 64;
    public int currentStackAmount = 1;
    public int dropAmount = 1;
    public int durability = 3;
    public Texture2D blockTexture;
    public Sprite iconSprite;

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
        blockTexture = block.blockTexture;
        durability = block.durability;
        iconSprite = block.iconSprite;
    }

    public abstract Block Copy();

    public string GetName() { return name; }
}
