public class BlockBedrock : Block
{
    public BlockBedrock() : base("Bedrock")
    {
        durability = 1000;
    }

    public BlockBedrock(BlockBedrock block) : base(block)
    {
    }

    public override Block Copy()
    {
        return new BlockBedrock(this);
    }
}
