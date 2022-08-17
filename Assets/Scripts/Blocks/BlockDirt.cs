public class BlockDirt : Block
{
    public BlockDirt() : base("Dirt")
    {

    }

    public BlockDirt(BlockDirt block) : base(block)
    {
    }

    public override Block Copy()
    {
        return new BlockDirt(this);
    }
}
