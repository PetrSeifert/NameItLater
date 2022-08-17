public class BlockDirtGrass : Block
{
    public BlockDirtGrass() : base("DirtGrass")
    {

    }

    public BlockDirtGrass(BlockDirtGrass block) : base(block)
    {
    }

    public override Block Copy()
    {
        return new BlockDirtGrass(this);
    }
}
