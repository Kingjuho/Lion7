using System;

namespace PokemonTextRPG.Monster
{
    public static class PokemonFactory
    {
        public static Pokemon Create(PokemonId id, int level)
        {
            // Repository에서 데이터 조회 및 객체 생성
            var data = PokemonRepository.GetData(id);
            Pokemon pokemon = new Pokemon(data.Name, level, data.BaseStats);

            // 딥 카피
            foreach (var skill in data.DefaultSkills) pokemon.Skills.Add(skill);

            return pokemon;
        }

        // 야생 포켓몬 생성
        public static Pokemon CreateWildPokemon()
        {
            int level = Constants.random.Next(2, 8);
            int roll = Constants.random.Next(0, 2);

            // TODO: 야생 포켓몬이 아직 2마리만 있어서 이런 방식을 쓰지만, 추후 야생 포켓몬만 있는 Id 리스트를 만들어 랜덤으로 뽑게 하는 걸로 리팩토링
            PokemonId targetId = (roll == 0) ? PokemonId.Pidgey : PokemonId.Rattata;

            return Create(targetId, level);
        }
    }
}
