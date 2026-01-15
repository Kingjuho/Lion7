namespace PokemonTextRPG.Map.Locations
{
    public class PalletTown : MapBase
    {
        public PalletTown()
        {
            Name = "태초마을";
            StartX = 14; StartY = 6;
            string[] design =
            {
                "...T.....TGGT.....T.",
                "TTTTTTTTTTGGTTTTTTTT",
                "T..................T",
                "T..................T",
                "T...HHHH....HHHH...T",
                "T..SHHHH...SHHHH...T",
                "T..................T",
                "T..................T",
                "T..................T",
                "T...###S...........T",
                "T...FFFF..HHHHHH...T",
                "T...FFFF..HHHHHH...T",
                "T..................T",
                "T.........###S##...T",
                "T...~~~~..FFFFFF...T",
                "T...~~~~..FFFFFF...T",
                "T...~~~~...........T",
                "TT..~~~~TTTTTTTTTTTT",
            };

            Initialize(design);
        }
    }
}
