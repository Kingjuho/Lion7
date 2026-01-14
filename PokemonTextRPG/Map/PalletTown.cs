using System;

namespace PokemonTextRPG.Map
{
    public class PalletTown : MapBase
    {
        public PalletTown()
        {
            Name = "태초마을";
            StartX = 5;
            StartY = 5;
            string[] design =
            {
                "TTTTTTTTTTTTTTTTTTTT",
                "T..................T",
                "T..HHHH......HHHH..T",
                "T..HHHH......HHHH..T",
                "T..HHHH......HHHH..T",
                "T..................T",
                "T.......S..........T",
                "T...FFFF....GGGG...T",
                "T...FFFF....GGGG...T",
                "T..................T",
                "TTTTTTTT....TTTTTTTT"
            };

            Initialize(design);
        }
    }
}
