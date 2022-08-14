using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirtGrass : Block
{
    public BlockDirtGrass() : base("Dirt")
    {

    }

    public BlockDirtGrass(BlockDirtGrass block) : base(block.GetName())
    {

    }

    public override Texture2D GetBlockTexture()
    {
        return AssetManager.Instance.dirtGrassBlockTexture;
    }

    public override Block Copy()
    {
        return new BlockDirtGrass(this);
    }
}
