using PokemonTextRPG.Map.Locations;

namespace PokemonTextRPG.Map
{
    public enum MapId
    {
        PalletTown,
        Route1_1,
        Route1_2,
        ViridianCity_1,
        ViridianCity_2,
        ViridianCity_3,
        ViridianCity_4,
    }

    public static class MapFactory
    {
        public static MapBase Create(MapId id)
        {
            switch (id)
            {
                case MapId.PalletTown:      return new PalletTown();
                case MapId.Route1_1:        return new Route1_1();
                case MapId.Route1_2:        return new Route1_2();
                case MapId.ViridianCity_1:  return new ViridianCity_1();
                case MapId.ViridianCity_2:  return new ViridianCity_2();
                case MapId.ViridianCity_3:  return new ViridianCity_3();
                case MapId.ViridianCity_4:  return new ViridianCity_4();
                default:                    return new PalletTown();
            }
        }
    }
}
