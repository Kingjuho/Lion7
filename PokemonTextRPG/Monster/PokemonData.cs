using System.Collections.Generic;

using PokemonTextRPG.Skills;

namespace PokemonTextRPG.Monster
{
    // 포켓몬 고유 ID
    public enum PokemonId
    {
        Charmander, // 파이리
        Pidgey,     // 구구
        Rattata     // 꼬렛
    }

    // 포켓몬 데이터 스키마 (설계도)
    public class PokemonData
    {
        public string Name { get; }
        public int[] BaseStats { get; } // H, A, B, C, D, S
        public List<Skill> DefaultSkills { get; }

        public PokemonData(string name, int[] baseStats, List<Skill> skills)
        {
            Name = name;
            BaseStats = baseStats;
            DefaultSkills = skills;
        }
    }
}