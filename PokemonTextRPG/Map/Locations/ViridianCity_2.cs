namespace PokemonTextRPG.Map.Locations
{
    public class ViridianCity_2 : MapBase
    {
        public ViridianCity_2()
        {
            Name = "상록시티";
            //StartX = 14; StartY = 6;
            string[] design =
            {
                ".TTTTTTTTTTTTTTTTXXX",
                "STTTTTTTTTTTTTTTTXXX",
                ".TTTT............XXX",
                ".TTTT............XXX",
                ".HHHH....HHHHHH..XXX",
                ".HHHH....HHHHHH..XXX",
                ".........HHHHHH..XXX",
                "........SHHHHHH..XXX",
                ".HHHH............XXX",
                ".HHHH############XXX",
                ".................XXX",
                ".................XXX",
                ".................XXX",
                "...HHHHHH..######XXX",
                "...HHHHHH........XXX",
                "..SHHHHHH........XXX",
                ".................XXX",
                ".........HHHH....XXX",
            };

            Initialize(design);

        }
    }
}
