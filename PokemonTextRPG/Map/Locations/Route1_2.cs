namespace PokemonTextRPG.Map.Locations
{
    public class Route1_2 : MapBase
    {
        public Route1_2()
        {
            Name = "1번도로";
            //StartX = 14; StartY = 6;
            string[] design =
            {
                "XXX..............XXX",
                "XXX..............XXX",
                "XXX#.###.########XXX",
                "XXX..............XXX",
                "XXX........GGGG..XXX",
                "XXXTTTTTTTTGGGG##XXX",
                "XXX....FFFFGGGG..XXX",
                "XXX....FFFFGGGG..XXX",
                "XXX..............XXX",
                "XXX##...S########XXX",
                "XXX..GGGG....GGGGXXX",
                "XXX..GGGG....GGGGXXX",
                "XXXGGGGFF..GGGGFFXXX",
                "XXXGGGGFF..GGGGFFXXX",
                "XXX######GG######XXX",
                "XXX.....#GG#.....XXX",
                "XXX.....#GG#.....XXX",
                "XXX.....#GG#.....XXX",
            };

            Initialize(design);

            // ~1번 도로 1번 파츠
            Portals.Add(new Portal(3, 0, MapId.Route1_1, 3, 16));
            Portals.Add(new Portal(4, 0, MapId.Route1_1, 4, 16));
            Portals.Add(new Portal(5, 0, MapId.Route1_1, 5, 16));
            Portals.Add(new Portal(6, 0, MapId.Route1_1, 6, 16));
            Portals.Add(new Portal(7, 0, MapId.Route1_1, 7, 16));
            Portals.Add(new Portal(8, 0, MapId.Route1_1, 8, 16));
            Portals.Add(new Portal(9, 0, MapId.Route1_1, 9, 16));
            Portals.Add(new Portal(10, 0, MapId.Route1_1, 10, 17));
            Portals.Add(new Portal(11, 0, MapId.Route1_1, 11, 17));
            Portals.Add(new Portal(12, 0, MapId.Route1_1, 12, 17));
            Portals.Add(new Portal(13, 0, MapId.Route1_1, 13, 17));
            Portals.Add(new Portal(14, 0, MapId.Route1_1, 14, 16));
            Portals.Add(new Portal(15, 0, MapId.Route1_1, 15, 16));
            Portals.Add(new Portal(16, 0, MapId.Route1_1, 16, 16));

            // ~태초마을
            Portals.Add(new Portal(9, 17, MapId.PalletTown, 10, 0));
            Portals.Add(new Portal(10, 17, MapId.PalletTown, 11, 0));
        }
    }
}
