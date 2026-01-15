using System.Collections.Generic;

using PokemonTextRPG.Monster;

namespace PokemonTextRPG.Character
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        // 보유 포켓몬 리스트
        // TODO: 나중에 6마리 제한 넣기
        public List<Pokemon> Team { get; set; } = new List<Pokemon>();

        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }
    }
}
