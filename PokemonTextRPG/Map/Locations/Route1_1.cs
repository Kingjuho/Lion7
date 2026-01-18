namespace PokemonTextRPG.Map.Locations
{
    public class Route1_1 : MapBase
    {
        public Route1_1()
        {
            Name = "1번도로";
            //StartX = 14; StartY = 6;
            string[] design =
            {
                "XXX.....#..#.....XXX",
                "XXX######..######XXX",
                "XXX..............XXX",
                "XXX..............XXX",
                "XXX.....T........XXX",
                "XXX#####T####....XXX",
                "XXX.....TGGGGGGGGXXX",
                "XXX.....TGGGGGGGGXXX",
                "XXX.....TGGGGGGGGXXX",
                "XXX#####TGGGGGGGGXXX",
                "XXX..FFFF........XXX",
                "XXX..FFFF........XXX",
                "XXX..........GGGGXXX",
                "XXXTT####TTTTGGGGXXX",
                "XXX....FFFF..GGGGXXX",
                "XXX....FFFF..GGGGXXX",
                "XXX..........FFFFXXX",
                "XXX..............XXX",
            };

            Initialize(design);

            // ~상록시티 4번 파츠
            Portals.Add(new Portal(9, 0, MapId.ViridianCity_4, 9, 16));
            Portals.Add(new Portal(10, 0, MapId.ViridianCity_4, 10, 16));

            // ~1번 도로 2번 파츠
            Portals.Add(new Portal(3, 17, MapId.Route1_2, 3, 1));
            Portals.Add(new Portal(4, 17, MapId.Route1_2, 4, 1));
            Portals.Add(new Portal(5, 17, MapId.Route1_2, 5, 1));
            Portals.Add(new Portal(6, 17, MapId.Route1_2, 6, 1));
            Portals.Add(new Portal(7, 17, MapId.Route1_2, 7, 1));
            Portals.Add(new Portal(8, 17, MapId.Route1_2, 8, 1));
            Portals.Add(new Portal(9, 17, MapId.Route1_2, 9, 1));
            Portals.Add(new Portal(10, 17, MapId.Route1_2, 10, 1));
            Portals.Add(new Portal(11, 17, MapId.Route1_2, 11, 1));
            Portals.Add(new Portal(12, 17, MapId.Route1_2, 12, 1));
            Portals.Add(new Portal(13, 17, MapId.Route1_2, 13, 1));
            Portals.Add(new Portal(14, 17, MapId.Route1_2, 14, 1));
            Portals.Add(new Portal(15, 17, MapId.Route1_2, 15, 1));
            Portals.Add(new Portal(16, 17, MapId.Route1_2, 16, 1));
        }
    }
}
