using System.Collections.Generic;

using PokemonTextRPG.Skills;

namespace PokemonTextRPG.Monster
{
    // 포켓몬 딕셔너리
    public static class PokemonRepository
    {
        private static readonly Dictionary<PokemonId, PokemonData> _pokedex = new Dictionary<PokemonId, PokemonData>
        {
            {
                PokemonId.Charmander,
                new PokemonData("파이리", new int[]{ 39, 52, 43, 60, 50, 65 }, new List<Skill>
                {
                    new Skill("몸통박치기", MoveType.Physical, 40),
                    new Skill("불꽃세례", MoveType.Special, 40)
                })
            },
            {
                PokemonId.Pidgey,
                new PokemonData("구구", new int[]{ 40, 45, 40, 35, 35, 56 }, new List<Skill>
                {
                    new Skill("몸통박치기", MoveType.Physical, 40),
                    new Skill("쪼기", MoveType.Physical, 35)
                })
            },
            {
                PokemonId.Rattata,
                new PokemonData("꼬렛", new int[]{ 30, 56, 35, 25, 35, 72 }, new List<Skill>
                {
                    new Skill("몸통박치기", MoveType.Physical, 40)
                })
            }
        };

        // 데이터 조회 메서드
        public static PokemonData GetData(PokemonId id)
        {
            // 조회 실패 시 강제로 구구로 만듦
            if (!_pokedex.ContainsKey(id)) id = PokemonId.Pidgey;
            return _pokedex[id];
        }
    }
}
