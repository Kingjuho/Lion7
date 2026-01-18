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


            // ~1번 도로 2번 파츠
            Portals.Add(new Portal(3, 17, MapId.Route1_2, 3, 0));
            Portals.Add(new Portal(4, 17, MapId.Route1_2, 4, 0));
            Portals.Add(new Portal(5, 17, MapId.Route1_2, 5, 0));
            Portals.Add(new Portal(6, 17, MapId.Route1_2, 6, 0));
            Portals.Add(new Portal(7, 17, MapId.Route1_2, 7, 0));
            Portals.Add(new Portal(8, 17, MapId.Route1_2, 8, 0));
            Portals.Add(new Portal(9, 17, MapId.Route1_2, 9, 0));
            Portals.Add(new Portal(10, 17, MapId.Route1_2, 10, 0));
            Portals.Add(new Portal(11, 17, MapId.Route1_2, 11, 0));
            Portals.Add(new Portal(12, 17, MapId.Route1_2, 12, 0));
            Portals.Add(new Portal(13, 17, MapId.Route1_2, 13, 0));
            Portals.Add(new Portal(14, 17, MapId.Route1_2, 14, 0));
            Portals.Add(new Portal(15, 17, MapId.Route1_2, 15, 0));
            Portals.Add(new Portal(16, 17, MapId.Route1_2, 16, 0));
        }
    }
}
