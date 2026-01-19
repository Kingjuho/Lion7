using PokemonTextRPG.Character;
using PokemonTextRPG.Map;
using PokemonTextRPG.Pokemons;
using System;

namespace PokemonTextRPG.Managers
{
    public class FieldManager
    {
        private Player _player;
        private MapBase _currentMap;
        private BattleManager _battleManager;

        public FieldManager(Player player, MapBase currentMap, BattleManager battleManager)
        {
            _player = player;
            _currentMap = currentMap;
            _battleManager = battleManager;
        }

        // 맵 변경
        public void SetMap(MapBase newMap)
        {
            _currentMap = newMap;
        }

        // 업데이트
        public void Update()
        {
            Render();
            ProcessInput();
        }

        // 필드 화면 렌더링
        private void Render()
        {
            // 맵 렌더링
            MapRenderer.Draw(_currentMap, _player.X, _player.Y);

            // 하단 UI 렌더링
            int uiY = 20;
            Console.SetCursorPosition(0, uiY++);
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH - 1));

            // 내 위치
            //UIManager.DrawSeparator(' ', uiY);
            //Console.SetCursorPosition(0, uiY++);
            //Console.Write($" [내 위치] ({_player.X:D2}, {_player.Y:D2})");

            // 선두 포켓몬
            UIManager.DrawSeparator(' ', uiY);
            Console.SetCursorPosition(0, uiY++);
            Console.Write($" [파트너] {_player.Team[0].Name} Lv.{_player.Team[0].Level} {_player.Team[0].CurrentHp}/{_player.Team[0].MaxHp}");

            // 조작 키
            UIManager.DrawSeparator(' ', uiY);
            Console.SetCursorPosition(0, uiY++);
            Console.Write(" [Key] 방향키: 이동 / ESC: 종료");

            UIManager.DrawSeparator(' ', uiY);
            Console.SetCursorPosition(0, uiY++);
            Console.Write($" SpaceBar: 상처약 사용(현재 {_player.GetItemCount(Items.ItemId.Potion)}개)");
        }

        // 키 입력
        private void ProcessInput()
        {
            // 키 입력 대기
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // 이동 예정 좌표
            int nextX = _player.X;
            int nextY = _player.Y;

            // 조작
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: nextY--; break;
                case ConsoleKey.DownArrow: nextY++; break;
                case ConsoleKey.LeftArrow: nextX--; break;
                case ConsoleKey.RightArrow: nextX++; break;
                case ConsoleKey.Spacebar: UsePotion(); return;
                case ConsoleKey.Escape: return;
                default: return;
            }

            // 충돌 체크
            if (_currentMap.IsWalkable(nextX, nextY))
            {
                // 안 움직이면 이벤트 실행 X
                if (nextX == _player.X && nextY == _player.Y) return;

                _player.X = nextX;
                _player.Y = nextY;

                if (CheckPortal()) return;
                CheckEvents();
            }
        }

        // 이벤트 체크
        private void CheckEvents()
        {
            // 현재 위치가 풀숲인지 확인
            if (_currentMap.IsBush(_player.X, _player.Y))
            {
                // 야생 포켓몬 조우
                if (Constants.random.Next(0, 100) < Constants.APPEAR_PERCENTAGE)
                {
                    // 필드 이동 반영
                    Render();

                    // 배틀 매니저 초기화 및 상태 전환 콜백
                    _battleManager.StartBattle(_player, PokemonFactory.CreateWildPokemon(), () =>
                    {
                        Console.Clear(); // 화면 초기화
                        GameManager.Instance.CurrentState = GameState.Field;
                    });

                    GameManager.Instance.CurrentState = GameState.Battle;
                }
            }
        }

        // 포탈 체크
        private bool CheckPortal()
        {
            // 해당 위치에 포탈이 있는 지 체크
            Portal portal = _currentMap.GetPortal(_player.X, _player.Y);
            if (portal == null) return false;

            // 있으면 맵 데이터 받아와 이동
            GameManager.Instance.ChangeMap(MapFactory.Create(portal.TargetMapId));

            _player.X = portal.TargetX;
            _player.Y = portal.TargetY;

            // 맵을 옮길 땐 반드시 콘솔 초기화
            Console.Clear();
            return true;
        }

        // 상처약 사용(필드)
        private void UsePotion()
        {
            // 인벤토리 체크
            var potionId = Items.ItemId.Potion;
            int count = _player.GetItemCount(potionId);
            if (count <= 0) return;

            var partner = _player.Team[0];
            var item = Items.ItemRepository.GetData(potionId);

            bool isUsed = item.Use(partner);

            if (isUsed)
            {
                _player.TryUseItem(potionId);
                UIManager.ShowMessage($"상처약을 사용했다! 남은 개수: {count - 1}");
            }
            else
            {
                UIManager.ShowMessage($"{partner.Name}은(는) 이미 건강하다!");
            }
        }
    }
}
