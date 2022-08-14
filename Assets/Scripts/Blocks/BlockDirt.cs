using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirt : Block
{
    public BlockDirt() : base("Dirt")
    {

    }

    public BlockDirt(BlockDirt block) : base(block.GetName())
    {

    }

    public override Texture2D GetBlockTexture()
    {
        return AssetManager.Instance.dirtBlockTexture;
    }

    public override Block Copy()
    {
        return new BlockDirt(this);
    }
}
