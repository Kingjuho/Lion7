using System.Collections.Generic;

using PokemonTextRPG.Skills;

namespace PokemonTextRPG.Pokemons
{
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