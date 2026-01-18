namespace PokemonTextRPG.Map.Locations
{
    public class ViridianCity_4 : MapBase
    {
        public ViridianCity_4()
        {
            Name = "상록시티";
            //StartX = 14; StartY = 6;
            string[] design =
            {
                ".........HHHH....XXX",
                ".........HHHH....XXX",
                ".................XXX",
                ".................XXX",
                "...HHHH..FFFFFF..XXX",
                "...HHHH..FFFFFF..XXX",
                "...HHHH..FFFFFF..XXX",
                "...HHHH..FFFFFF..XXX",
                ".................XXX",
                ".################XXX",
                ".....FFFF..FFFF..XXX",
                ".....FFFF..FFFF..XXX",
                ".................XXX",
                "#########..######XXX",
                "XXX.....#..#.....XXX",
                "XXX.....#..#.....XXX",
                "XXX.....#..#.....XXX",
                "XXX.....#..#.....XXX",
            };

            Initialize(design);

        }
    }
}
