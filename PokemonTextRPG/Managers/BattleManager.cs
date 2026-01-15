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

        // 전투 로그
        private string _battleLog = "";

        // 배틀 시작
        public void StartBattle(Player player, Pokemon wildPokemon, Action onBattleEnd)
        {
            _player = player;
            _enemy = wildPokemon;
            _myPokemon = player.Team[0];    // 선두 포켓몬
            _onBattleEnd = onBattleEnd;
            _battleLog = $"앗! 야생의 {_enemy.Name}(이)가 나타났다!";

            // 전투 연출
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Thread.Sleep(50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(50);
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
            Console.SetCursorPosition(0, 0);
            // 상단 적 정보 (너비 42칸에 맞춰 중앙 정렬 느낌으로)
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH));
            Console.WriteLine($" [적] {_enemy.Name} Lv.{_enemy.Level}");
            Console.WriteLine($" HP: {_enemy.CurrentHp}/{_enemy.MaxHp}".PadRight(Constants.SCREEN_WIDTH));
            Console.WriteLine(new string('-', Constants.SCREEN_WIDTH));

            // 중간 공백 (포켓몬이 있는 공간)
            for (int i = 0; i < 5; i++) Console.WriteLine(new string(' ', Constants.SCREEN_WIDTH));

            // 하단 내 정보
            Console.WriteLine(new string('-', Constants.SCREEN_WIDTH));
            Console.WriteLine($" [나] {_myPokemon.Name} Lv.{_myPokemon.Level}");
            Console.WriteLine($" HP: {_myPokemon.CurrentHp}/{_myPokemon.MaxHp}".PadRight(Constants.SCREEN_WIDTH));
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH));

            // UI 영역 (로그 또는 메뉴)
            // 로그가 있으면 로그를 보여주고, 아니면 메뉴를 보여줌
            Console.WriteLine(_battleLog.PadRight(Constants.SCREEN_WIDTH - 1));

            // 기술 목록 표시
            if (_myPokemon.Skills.Count >= 1)
                Console.Write($" [Z] {_myPokemon.Skills[0].Name} ");
            if (_myPokemon.Skills.Count >= 2)
                Console.Write($" [X] {_myPokemon.Skills[1].Name}");

            Console.WriteLine(); // 줄바꿈
            Console.WriteLine(" [Esc] 도망가기");
        }

        private void HandleInput() 
        {
            // 애니메이션 도중 입력 방지
            if (!Console.KeyAvailable) return;

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Z:
                    if (_myPokemon.Skills.Count > 0) ExecuteTurn(_myPokemon.Skills[0]);
                    break;

                case ConsoleKey.X:
                    if (_myPokemon.Skills.Count > 1) ExecuteTurn(_myPokemon.Skills[1]);
                    break;

                case ConsoleKey.Escape:
                    _battleLog = "무사히 도망쳤다!";
                    DrawBattleScreen();
                    Thread.Sleep(1000);
                    _onBattleEnd?.Invoke();
                    break;
            }
        }

        // 턴 실행
        private void ExecuteTurn(Skill playerSkill)
        {
            // 적 행동 결정(랜덤 스킬)
            int enemySkillIndex = Constants.random.Next(_enemy.Skills.Count);
            Skill enemySkill = _enemy.Skills[enemySkillIndex];

            // 선공 결정(동속전일 경우 반반)
            bool playerFirst = _myPokemon.Spd >= _enemy.Spd;
            if (_myPokemon.Spd == _enemy.Spd) 
                playerFirst = Constants.random.Next(2) == 0;

            // 순서대로 공격(후공은 살아있으면 반격)
            if (playerFirst)
            {
                Attack(_myPokemon, _enemy, playerSkill);
                if (_enemy.CurrentHp > 0)
                    Attack(_enemy, _myPokemon, enemySkill);
            }
            else
            {
                Attack(_enemy, _myPokemon, enemySkill);
                if (_myPokemon.CurrentHp > 0)
                    Attack(_myPokemon, _enemy, playerSkill);
            }
        }

        // 공격 처리
        private void Attack(Pokemon attacker, Pokemon defender, Skill skill)
        {
            // 로그 출력 및 대기
            _battleLog = $"{attacker.Name}의 {skill.Name}!";
            DrawBattleScreen();
            Thread.Sleep(2000);

            // 데미지 계산
            int damage = CalculateDamage(attacker, defender, skill);
            defender.CurrentHp -= damage;
            if (defender.CurrentHp < 0) defender.CurrentHp = 0;

            // 체력 갱신
            DrawBattleScreen();
            Thread.Sleep(1000);

            // 기절 처리
            if (defender.CurrentHp <= 0) HandleFaint(defender);
        }

        // 데미지 계산
        private int CalculateDamage(Pokemon atk, Pokemon def, Skill skill)
        {
            // 기술 타입에 따른 공/방, 특공/특방 사용
            int a = (skill.Type == MoveType.Physical) ? atk.Atk : atk.SpAtk;
            int d = (skill.Type == MoveType.Physical) ? def.Def : def.SpDef;

            // 데미지 계산식
            float damage = ((atk.Level * 2.0f / 5.0f + 2.0f) * skill.Power * a / d / 50.0f) + 2.0f;

            // 난수 보정
            float randomMod = (Constants.random.Next(85, 101) / 100.0f);

            // 포켓몬에서 모든 소수점 계산은 버림
            return (int)(damage * randomMod);
        }

        // 기절 처리
        private void HandleFaint(Pokemon loser)
        {
            _battleLog = $"{loser.Name}은(는) 쓰러졌다!";
            DrawBattleScreen();
            Thread.Sleep(1000);

            if (loser == _enemy)
            {
                _battleLog = "승리했다! 경험치를 얻었다."; // 경험치는 나중에
                DrawBattleScreen();
                Thread.Sleep(1000);
            }
            else
            {
                _battleLog = "눈앞이 캄캄해졌다...";
                DrawBattleScreen();
                Thread.Sleep(1000);
                // 게임 오버 처리는 나중에
            }

            // 전투 종료 콜백 호출
            _onBattleEnd?.Invoke();
        }
    }
}
