namespace day3
{
    class Intersection
    {
        public Intersection(Coordinate coordinate, int wire1Dist, int wire2Dist)
        {
            Coordinate = coordinate;
            Wire1Dist = wire1Dist;
            Wire2Dist = wire2Dist;
        }

        public Coordinate Coordinate { get; }
        public int Wire1Dist { get; }
        public int Wire2Dist { get; }
        
        public int TotalWireDist
        {
            get
            {
                return Wire1Dist + Wire2Dist;
            }
        }
    }
}