namespace PokemonTextRPG.Map.Locations
{
    public class ViridianCity_1 : MapBase
    {
        public ViridianCity_1()
        {
            Name = "상록시티";
            //StartX = 14; StartY = 6;
            string[] design =
            {
                "#######TTTTTTTTTT#..",
                "#######TTTTTTTTTT#..",
                "#######TTTTTTTTTT#..",
                "#######TTTTTTTTTT#..",
                "#######........T....",
                "#######..######TT...",
                "#######.#TTTTTTTT#..",
                "#######.#TTTTTTTT#..",
                "#######.#TTTTTTTT#..",
                "#######.#TTTTTTTT#..",
                "#######.#TTTTTTTT#..",
                "#######.#TTTTTTTT#..",
                "#######.#TTTTTTTT#..",
                "#######.#TTTTTTTT#..",
                "........#TTTTTTTT#..",
                "........#TTTTTTTT#..",
                ".........TTTTTTTT...",
                "..................S.",
            };

            Initialize(design);

        }
    }
}
