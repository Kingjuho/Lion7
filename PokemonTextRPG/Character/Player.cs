using System.Collections.Generic;

using PokemonTextRPG.Pokemons;
using PokemonTextRPG.Items;

namespace PokemonTextRPG.Character
{
    public class Player
    {
        // 현재 위치
        public int X { get; set; }
        public int Y { get; set; }

        // 보유 포켓몬 리스트
        public List<Pokemon> Team { get; set; } = new List<Pokemon>();

        // 인벤토리(키: 아이템 고유 번호, 밸류: 아이템 개수)
        public Dictionary<ItemId, int> Inventory { get; private set; } = new Dictionary<ItemId, int>();

        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        // 아이템 획득
        public void AddItem(ItemId id, int count)
        {
            if (Inventory.ContainsKey(id)) Inventory[id] += count;
            else Inventory[id] = count;
        }

        // 아이템 사용
        public bool TryUseItem(ItemId id)
        {
            if (Inventory.ContainsKey(id) && Inventory[id] > 0)
            {
                Inventory[id]--;
                if (Inventory[id] == 0) Inventory.Remove(id);
                return true;
            }
            return false;
        }

        // 아이템 개수 확인
        public int GetItemCount(ItemId id) { return Inventory.ContainsKey(id) ? Inventory[id] : 0; }
    }
}
