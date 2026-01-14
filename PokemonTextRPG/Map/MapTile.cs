using System;

namespace PokemonTextRPG.Map
{
    public class Tile
    {
        public string Symbol { get; }       // 렌더링 될 모양
        public ConsoleColor Color { get; }  // 색상
        public bool IsWalkable { get; }     // 이동 가능 여부

        public Tile(string symbol, ConsoleColor color, bool isWalkable)
        {
            Symbol = symbol;
            Color = color;
            IsWalkable = isWalkable;
        }
    }
}
