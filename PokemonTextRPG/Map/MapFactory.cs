using PokemonTextRPG.Map.Locations;

namespace PokemonTextRPG.Map
{
    public static class MapFactory
    {
        public static MapBase Create(MapId id)
        {
            switch (id)
            {
                case MapId.PalletTown: return new PalletTown();
                case MapId.Route1_1:   return new Route1_1();
                case MapId.Route1_2:   return new Route1_2();
                default:               return new PalletTown();
            }
        }
    }
}
