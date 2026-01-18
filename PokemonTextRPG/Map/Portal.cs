namespace PokemonTextRPG.Map
{
    public enum MapId
    {
        PalletTown,
        Route1_1,
        Route1_2,
    }
    public class Portal
    {
        // 포탈 좌표
        public int X { get; set; }
        public int Y { get; set; }

        // 이동 목적지
        public MapId TargetMapId { get; set; }
        public int TargetX { get; set; }
        public int TargetY { get; set; }

        public Portal(int x, int y, MapId targetMapId, int targetX, int targetY)
        {
            X = x;
            Y = y;
            TargetMapId = targetMapId;
            TargetX = targetX;
            TargetY = targetY;
        }
    }
}
