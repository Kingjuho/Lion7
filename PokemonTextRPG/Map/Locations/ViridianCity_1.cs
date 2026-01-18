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

            // ~상록시티 2번 파츠
            Portals.Add(new Portal(19, 0, MapId.ViridianCity_2, 0, 0));
            //Portals.Add(new Portal(19, 1, MapId.ViridianCity_2, 0, 1));       // 표지판
            Portals.Add(new Portal(19, 2, MapId.ViridianCity_2, 0, 2));
            Portals.Add(new Portal(19, 3, MapId.ViridianCity_2, 0, 3));
            Portals.Add(new Portal(19, 4, MapId.ViridianCity_2, 0, 4));
            Portals.Add(new Portal(19, 5, MapId.ViridianCity_2, 0, 5));
            Portals.Add(new Portal(19, 6, MapId.ViridianCity_2, 0, 6));
            Portals.Add(new Portal(19, 7, MapId.ViridianCity_2, 0, 7));
            Portals.Add(new Portal(19, 8, MapId.ViridianCity_2, 0, 8));
            Portals.Add(new Portal(19, 9, MapId.ViridianCity_2, 0, 9));
            Portals.Add(new Portal(19, 10, MapId.ViridianCity_2, 0, 10));
            Portals.Add(new Portal(19, 11, MapId.ViridianCity_2, 0, 11));
            Portals.Add(new Portal(19, 12, MapId.ViridianCity_2, 0, 12));
            Portals.Add(new Portal(19, 13, MapId.ViridianCity_2, 0, 13));
            Portals.Add(new Portal(19, 14, MapId.ViridianCity_2, 0, 14));
            Portals.Add(new Portal(19, 15, MapId.ViridianCity_2, 0, 15));
            Portals.Add(new Portal(19, 16, MapId.ViridianCity_2, 0, 16));
            Portals.Add(new Portal(19, 17, MapId.ViridianCity_2, 0, 17));

            // ~상록시티 3번 파츠
            //Portals.Add(new Portal(0, 17, MapId.ViridianCity_3, 0, 0));      // 언덕
            //Portals.Add(new Portal(1, 17, MapId.ViridianCity_3, 1, 0));
            //Portals.Add(new Portal(2, 17, MapId.ViridianCity_3, 2, 0));
            //Portals.Add(new Portal(3, 17, MapId.ViridianCity_3, 3, 0));
            //Portals.Add(new Portal(4, 17, MapId.ViridianCity_3, 4, 0));
            Portals.Add(new Portal(5, 17, MapId.ViridianCity_3, 5, 0));
            Portals.Add(new Portal(6, 17, MapId.ViridianCity_3, 6, 0));
            Portals.Add(new Portal(7, 17, MapId.ViridianCity_3, 7, 0));
            Portals.Add(new Portal(8, 17, MapId.ViridianCity_3, 8, 0));
            Portals.Add(new Portal(9, 17, MapId.ViridianCity_3, 9, 0));
            Portals.Add(new Portal(10, 17, MapId.ViridianCity_3, 10, 0));
            Portals.Add(new Portal(11, 17, MapId.ViridianCity_3, 11, 0));
            Portals.Add(new Portal(12, 17, MapId.ViridianCity_3, 12, 0));
            Portals.Add(new Portal(13, 17, MapId.ViridianCity_3, 13, 0));
            Portals.Add(new Portal(14, 17, MapId.ViridianCity_3, 14, 0));
            Portals.Add(new Portal(15, 17, MapId.ViridianCity_3, 15, 0));
            Portals.Add(new Portal(16, 17, MapId.ViridianCity_3, 16, 0));
            Portals.Add(new Portal(17, 17, MapId.ViridianCity_3, 17, 0));
            //Portals.Add(new Portal(18, 17, MapId.ViridianCity_3, 18, 0));    // 표지판
            Portals.Add(new Portal(19, 17, MapId.ViridianCity_3, 19, 0));
        }
    }
}
