using System;
using System.Collections.Generic;

namespace PokemonTextRPG.Map
{
    public static class TileRepository
    {
        // 도감 (char -> Tile 정보)
        private static readonly Dictionary<char, Tile> _tiles = new Dictionary<char, Tile>
        {
            // 키, 이모지, 색상, 이동 가능 여부
            { 'T', new Tile("♣", ConsoleColor.Green,      false) },    // 나무
            { 'G', new Tile("ww", ConsoleColor.DarkGreen,  true ) },    // 풀숲
            { 'F', new Tile("**", ConsoleColor.Magenta,    true ) },    // 꽃
            { '#', new Tile("##", ConsoleColor.DarkGray,   false) },    // 울타리
            { 'S', new Tile("[]", ConsoleColor.Yellow,     false) },    // 표지판
            { 'H', new Tile("HH", ConsoleColor.DarkRed,    false) },    // 집
            { '.', new Tile("  ", ConsoleColor.Black,      true ) },    // 길(공백)
            { '~', new Tile("~~", ConsoleColor.Cyan,       false) },    // 물
            // 맵 밖(경계) 처리를 위한 더미 타일
            { 'X', new Tile("♣", ConsoleColor.Green,      false) }
        };

        // 타일 정보 가져오기
        public static Tile Get(char tileCode)
        {
            if (_tiles.ContainsKey(tileCode)) return _tiles[tileCode];
            // 등록되지 않은 문자는 더미 타일 출력
            return _tiles['X'];
        }
    }
}
