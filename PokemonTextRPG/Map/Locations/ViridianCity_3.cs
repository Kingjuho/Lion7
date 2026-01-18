namespace PokemonTextRPG.Map.Locations
{
    public class ViridianCity_3 : MapBase
    {
        public ViridianCity_3()
        {
            Name = "상록시티";
            //StartX = 14; StartY = 6;
            string[] design =
            {
                "XXXXX...............",
                "XXXXX...............",
                "XXXXX...............",
                "XXXXX####...........",
                "XXXXX....T.FFFF.....",
                "XXXXX....TTFFFF.....",
                "XXXXX....~~~~~~.....",
                "XXXXX....~~~~~~.....",
                "XXXXX....~~~~~~.....",
                "XXXXX####~~~~~~#.###",
                "XXXXX..FF...........",
                "XXXXX..FF...........",
                "XXXXX...............",
                "XXXXX###############",
                "....................",
                "....................",
                "....................",
                "....................",
            };

            Initialize(design);

        }
    }
}
