using System;
using System.Threading;

using PokemonTextRPG.Character;
using PokemonTextRPG.Monster;
using PokemonTextRPG.Skills;

namespace PokemonTextRPG.Managers
{
    public class BattleManager
    {
        private Player _player;         // 유저
        private Pokemon _enemy;         // 상대 포켓몬
        private Pokemon _myPokemon;     // 현재 나와있는 내 포켓몬

        // 배틀 종료 시 콜백
        private Action _onBattleEnd;

        // 배틀 시작
        public void StartBattle(Player player, Pokemon wildPokemon, Action onBattleEnd)
        {
            _player = player;
            _enemy = wildPokemon;
            _myPokemon = player.Team[0];    // 선두 포켓몬
            _onBattleEnd = onBattleEnd;

            Console.Clear();
            Console.WriteLine($"앗! 야생의 {_enemy.Name}(이)가 튀어나왔다!");
            Thread.Sleep(1000);
        }

        // 배틀 중
        public void Update()
        {
            // 화면 그리기
            DrawBattleScreen();

            // 입력 받기
            HandleInput();
        }

        // 배틀 화면 출력
        private void DrawBattleScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            // [상단] 적 정보
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH - 1));
            Console.WriteLine($" [적] {_enemy.Name} Lv.{_enemy.Level}");
            Console.WriteLine($"      HP: {_enemy.CurrentHp} / {_enemy.MaxHp}");
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH - 1));

            // [중간] 공백
            for (int i = 0; i < 5; i++) Console.WriteLine();

            // [하단] 내 정보
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH - 1));
            Console.WriteLine($" [나] {_myPokemon.Name} Lv.{_myPokemon.Level}");
            Console.WriteLine($"      HP: {_myPokemon.CurrentHp} / {_myPokemon.MaxHp}");
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH - 1));

            // [메뉴]
            Console.WriteLine(" [Z] 공격하기   [X] 도망가기");
        }

        private void HandleInput() 
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Z:  // TODO: 공격
                    break;

                case ConsoleKey.X: // TODO: 도망
                    break;
            }
        }
    }
}
