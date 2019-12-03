namespace day3
{
    class PathInstruction
    {
        public PathInstruction(Direction direction, int length)
        {
            Direction = direction;
            Length = length;
        }

        public Direction Direction { get; }
        public int Length { get; }
    }
}
