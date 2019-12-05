namespace day3
{
    class CoordinateOnWire
    {

        public CoordinateOnWire(Coordinate coordinate, int wireDist)
        {
            Coordinate = coordinate;
            WireDist = wireDist;
        }

        public Coordinate Coordinate { get; }

        public int WireDist { get; }
    }
}