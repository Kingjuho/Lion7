using System.Collections.Generic;

using PokemonTextRPG.Pokemons;

namespace PokemonTextRPG.Items
{
    public static class ItemRepository
    {
        // 아이템 딕셔너리
        private static readonly Dictionary<ItemId, Item> _items = new Dictionary<ItemId, Item>
        {
            {
                ItemId.Potion,
                new Item("상처약", "포켓몬의 체력을 20 회복한다.", (target) =>
                {
                    return target.Heal(20);
                })
            },
        };

        // 데이터 조회 메서드
        public static Item GetData(ItemId id)
        {
            // 조회 실패 시 강제로 구구로 만듦
            if (_items.ContainsKey(id)) return _items[id];
            return null;
        }
    }
}
