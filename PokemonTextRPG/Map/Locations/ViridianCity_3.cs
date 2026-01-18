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
                "#####...............",
                "#####...............",
                "#####...............",
                "#########...........",
                "#####....T.FFFF.....",
                "#####....TTFFFF.....",
                "#####....~~~~~~.....",
                "#####....~~~~~~.....",
                "#####....~~~~~~.....",
                "#########~~~~~~#.###",
                "#####..FF...........",
                "#####..FF...........",
                "#####...............",
                "####################",
                "XXXXXXXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXXXXXXX",
                "XXXXXXXXXXXXXXXXXXXX",
            };

            Initialize(design);

            // ~상록시티 4번 파츠
            Portals.Add(new Portal(19, 0, MapId.ViridianCity_4, 0, 0));
            Portals.Add(new Portal(19, 1, MapId.ViridianCity_4, 0, 1));
            Portals.Add(new Portal(19, 2, MapId.ViridianCity_4, 0, 2));
            Portals.Add(new Portal(19, 3, MapId.ViridianCity_4, 0, 3));
            Portals.Add(new Portal(19, 4, MapId.ViridianCity_4, 0, 4));
            Portals.Add(new Portal(19, 5, MapId.ViridianCity_4, 0, 5));
            Portals.Add(new Portal(19, 6, MapId.ViridianCity_4, 0, 6));
            Portals.Add(new Portal(19, 7, MapId.ViridianCity_4, 0, 7));
            Portals.Add(new Portal(19, 8, MapId.ViridianCity_4, 0, 8));
            //Portals.Add(new Portal(19, 9, MapId.ViridianCity_4, 0, 9));       // 언덕
            Portals.Add(new Portal(19, 10, MapId.ViridianCity_4, 0, 10));
            Portals.Add(new Portal(19, 11, MapId.ViridianCity_4, 0, 11));
            Portals.Add(new Portal(19, 12, MapId.ViridianCity_4, 0, 12));
            //Portals.Add(new Portal(19, 13, MapId.ViridianCity_4, 0, 13));     // 맵 밖
            //Portals.Add(new Portal(19, 14, MapId.ViridianCity_4, 0, 14));
            //Portals.Add(new Portal(19, 15, MapId.ViridianCity_4, 0, 15));
            //Portals.Add(new Portal(19, 16, MapId.ViridianCity_4, 0, 16));
            //Portals.Add(new Portal(19, 17, MapId.ViridianCity_4, 0, 17));

            // ~상록시티 1번 파츠
            //Portals.Add(new Portal(0, 0, MapId.ViridianCity_1, 0, 17));       // 언덕
            //Portals.Add(new Portal(1, 0, MapId.ViridianCity_1, 1, 17));
            //Portals.Add(new Portal(2, 0, MapId.ViridianCity_1, 2, 17));
            //Portals.Add(new Portal(3, 0, MapId.ViridianCity_1, 3, 17));
            //Portals.Add(new Portal(4, 0, MapId.ViridianCity_1, 4, 17));
            Portals.Add(new Portal(5, 0, MapId.ViridianCity_1, 5, 17));
            Portals.Add(new Portal(6, 0, MapId.ViridianCity_1, 6, 17));
            Portals.Add(new Portal(7, 0, MapId.ViridianCity_1, 7, 17));
            Portals.Add(new Portal(8, 0, MapId.ViridianCity_1, 8, 17));
            Portals.Add(new Portal(9, 0, MapId.ViridianCity_1, 9, 17));
            Portals.Add(new Portal(10, 0, MapId.ViridianCity_1, 10, 17));
            Portals.Add(new Portal(11, 0, MapId.ViridianCity_1, 11, 17));
            Portals.Add(new Portal(12, 0, MapId.ViridianCity_1, 12, 17));
            Portals.Add(new Portal(13, 0, MapId.ViridianCity_1, 13, 17));
            Portals.Add(new Portal(14, 0, MapId.ViridianCity_1, 14, 17));
            Portals.Add(new Portal(15, 0, MapId.ViridianCity_1, 15, 17));
            Portals.Add(new Portal(16, 0, MapId.ViridianCity_1, 16, 17));
            Portals.Add(new Portal(17, 0, MapId.ViridianCity_1, 17, 17));
            //Portals.Add(new Portal(18, 0, MapId.ViridianCity_1, 18, 17));     // 표지판
            Portals.Add(new Portal(19, 0, MapId.ViridianCity_1, 19, 17));
        }
    }
}
