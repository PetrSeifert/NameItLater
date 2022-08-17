public class BlockOakWood : Block
{
    public BlockOakWood() : base("OakWood")
    {
        durability = 6;
    }

    public BlockOakWood(BlockOakWood block) : base(block)
    {
    }

    public override Block Copy()
    {
        return new BlockOakWood(this);
    }
}
