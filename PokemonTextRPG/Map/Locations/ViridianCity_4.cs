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

            // ~상록시티 2번 파츠
            Portals.Add(new Portal(0, 0, MapId.ViridianCity_2, 0, 17));
            Portals.Add(new Portal(1, 0, MapId.ViridianCity_2, 1, 17));
            Portals.Add(new Portal(2, 0, MapId.ViridianCity_2, 2, 17));
            Portals.Add(new Portal(3, 0, MapId.ViridianCity_2, 3, 17));
            Portals.Add(new Portal(4, 0, MapId.ViridianCity_2, 4, 17));
            Portals.Add(new Portal(5, 0, MapId.ViridianCity_2, 5, 17));
            Portals.Add(new Portal(6, 0, MapId.ViridianCity_2, 6, 17));
            Portals.Add(new Portal(7, 0, MapId.ViridianCity_2, 7, 17));
            Portals.Add(new Portal(8, 0, MapId.ViridianCity_2, 8, 17));
            //Portals.Add(new Portal(9, 0, MapId.ViridianCity_2, 9, 17));       // 건물
            //Portals.Add(new Portal(10, 0, MapId.ViridianCity_2, 10, 17));
            //Portals.Add(new Portal(11, 0, MapId.ViridianCity_2, 11, 17));
            //Portals.Add(new Portal(12, 0, MapId.ViridianCity_2, 12, 17));
            Portals.Add(new Portal(13, 0, MapId.ViridianCity_2, 13, 17));
            Portals.Add(new Portal(14, 0, MapId.ViridianCity_2, 14, 17));
            Portals.Add(new Portal(15, 0, MapId.ViridianCity_2, 15, 17));
            Portals.Add(new Portal(16, 0, MapId.ViridianCity_2, 16, 17));
            Portals.Add(new Portal(17, 0, MapId.ViridianCity_2, 17, 17));
            Portals.Add(new Portal(18, 0, MapId.ViridianCity_2, 18, 17));
            Portals.Add(new Portal(19, 0, MapId.ViridianCity_2, 19, 17));

            // ~상록시티 3번 파츠
            Portals.Add(new Portal(0, 0, MapId.ViridianCity_3, 19, 0));
            Portals.Add(new Portal(0, 1, MapId.ViridianCity_3, 19, 1));
            Portals.Add(new Portal(0, 2, MapId.ViridianCity_3, 19, 2));
            Portals.Add(new Portal(0, 3, MapId.ViridianCity_3, 19, 3));
            Portals.Add(new Portal(0, 4, MapId.ViridianCity_3, 19, 4));
            Portals.Add(new Portal(0, 5, MapId.ViridianCity_3, 19, 5));
            Portals.Add(new Portal(0, 6, MapId.ViridianCity_3, 19, 6));
            Portals.Add(new Portal(0, 7, MapId.ViridianCity_3, 19, 7));
            Portals.Add(new Portal(0, 8, MapId.ViridianCity_3, 19, 8));
            //Portals.Add(new Portal(0, 9, MapId.ViridianCity_3, 19, 9));       // 언덕
            Portals.Add(new Portal(0, 10, MapId.ViridianCity_3, 19, 10));
            Portals.Add(new Portal(0, 11, MapId.ViridianCity_3, 19, 11));
            Portals.Add(new Portal(0, 12, MapId.ViridianCity_3, 19, 12));
            //Portals.Add(new Portal(0, 13, MapId.ViridianCity_3, 19, 13));     // 맵 밖
            //Portals.Add(new Portal(0, 14, MapId.ViridianCity_3, 19, 14));
            //Portals.Add(new Portal(0, 15, MapId.ViridianCity_3, 19, 15));
            //Portals.Add(new Portal(0, 16, MapId.ViridianCity_3, 19, 16));
            //Portals.Add(new Portal(0, 17, MapId.ViridianCity_3, 19, 17));

            // ~1번도로 1번 파츠
            Portals.Add(new Portal(9, 17, MapId.Route1_1, 9, 1));
            Portals.Add(new Portal(10, 17, MapId.Route1_1, 10, 1));
        }
    }
}
