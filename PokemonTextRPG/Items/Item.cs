using System;
using PokemonTextRPG.Pokemons;

namespace PokemonTextRPG.Items
{
    // 아이템 클래스
    public class Item
    {
        public string Name { get; private set; }        // 이름
        public string Description { get; private set; } // 설명
        
        // 아이템 사용 로직
        private Func<Pokemon, bool> _onUse;

        public Item(string name, string description, Func<Pokemon, bool> onUse) 
        {
            Name = name;
            Description = description;
            _onUse = onUse;
        }

        // 아이템 사용
        public bool Use(Pokemon target)
        {
            return _onUse(target);
        }
    }

    // 아이템 타입
    public enum ItemId
    {
        None = 0,
        Potion,
    }
}
