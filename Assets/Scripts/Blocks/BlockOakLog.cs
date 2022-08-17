public class BlockOakLog : Block
{
    public BlockOakLog() : base("OakLog")
    {
        durability = 6;
    }

    public BlockOakLog(BlockOakLog block) : base(block)
    {
    }

    public override Block Copy()
    {
        return new BlockOakLog(this);
    }
}
