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

            // ~상록시티 1번 파츠
            Portals.Add(new Portal(0, 0, MapId.ViridianCity_1, 19, 0));
            //Portals.Add(new Portal(0, 1, MapId.ViridianCity_1, 19, 1));       // 표지판
            Portals.Add(new Portal(0, 2, MapId.ViridianCity_1, 19, 2));
            Portals.Add(new Portal(0, 3, MapId.ViridianCity_1, 19, 3));
            Portals.Add(new Portal(0, 4, MapId.ViridianCity_1, 19, 4));
            Portals.Add(new Portal(0, 5, MapId.ViridianCity_1, 19, 5));
            Portals.Add(new Portal(0, 6, MapId.ViridianCity_1, 19, 6));
            Portals.Add(new Portal(0, 7, MapId.ViridianCity_1, 19, 7));
            Portals.Add(new Portal(0, 8, MapId.ViridianCity_1, 19, 8));
            Portals.Add(new Portal(0, 9, MapId.ViridianCity_1, 19, 9));
            Portals.Add(new Portal(0, 10, MapId.ViridianCity_1, 19, 10));
            Portals.Add(new Portal(0, 11, MapId.ViridianCity_1, 19, 11));
            Portals.Add(new Portal(0, 12, MapId.ViridianCity_1, 19, 12));
            Portals.Add(new Portal(0, 13, MapId.ViridianCity_1, 19, 13));
            Portals.Add(new Portal(0, 14, MapId.ViridianCity_1, 19, 14));
            Portals.Add(new Portal(0, 15, MapId.ViridianCity_1, 19, 15));
            Portals.Add(new Portal(0, 16, MapId.ViridianCity_1, 19, 16));
            Portals.Add(new Portal(0, 17, MapId.ViridianCity_1, 19, 17));

            // ~상록시티 4번 파츠
            Portals.Add(new Portal(0, 17, MapId.ViridianCity_4, 0, 0));
            Portals.Add(new Portal(1, 17, MapId.ViridianCity_4, 1, 0));
            Portals.Add(new Portal(2, 17, MapId.ViridianCity_4, 2, 0));
            Portals.Add(new Portal(3, 17, MapId.ViridianCity_4, 3, 0));
            Portals.Add(new Portal(4, 17, MapId.ViridianCity_4, 4, 0));
            Portals.Add(new Portal(5, 17, MapId.ViridianCity_4, 5, 0));
            Portals.Add(new Portal(6, 17, MapId.ViridianCity_4, 6, 0));
            Portals.Add(new Portal(7, 17, MapId.ViridianCity_4, 7, 0));
            Portals.Add(new Portal(8, 17, MapId.ViridianCity_4, 8, 0));
            //Portals.Add(new Portal(9, 17, MapId.ViridianCity_4, 9, 0));       // 건물
            //Portals.Add(new Portal(10, 17, MapId.ViridianCity_4, 10, 0));
            //Portals.Add(new Portal(11, 17, MapId.ViridianCity_4, 11, 0));
            //Portals.Add(new Portal(12, 17, MapId.ViridianCity_4, 12, 0));
            Portals.Add(new Portal(13, 17, MapId.ViridianCity_4, 13, 0));
            Portals.Add(new Portal(14, 17, MapId.ViridianCity_4, 14, 0));
            Portals.Add(new Portal(15, 17, MapId.ViridianCity_4, 15, 0));
            Portals.Add(new Portal(16, 17, MapId.ViridianCity_4, 16, 0));
            //Portals.Add(new Portal(17, 17, MapId.ViridianCity_4, 17, 0));     // 맵 밖
            //Portals.Add(new Portal(18, 17, MapId.ViridianCity_4, 18, 0));
            //Portals.Add(new Portal(19, 17, MapId.ViridianCity_4, 19, 0));
        }
    }
}
