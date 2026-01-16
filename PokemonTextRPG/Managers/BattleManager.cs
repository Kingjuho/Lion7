using System;
using System.Collections.Generic;
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

        // 키 매핑을 위한 배열
        private readonly ConsoleKey[] _skillKeys = { ConsoleKey.Z, ConsoleKey.X, ConsoleKey.C, ConsoleKey.V };
        private readonly string[] _skillKeyNames = { "Z", "X", "C", "V" };

        // 배틀 시작
        public void StartBattle(Player player, Pokemon wildPokemon, Action onBattleEnd)
        {
            // 초기화
            _player = player;
            _enemy = wildPokemon;
            _myPokemon = player.Team[0];    // 선두 포켓몬
            _onBattleEnd = onBattleEnd;

            // 전투 오프닝 연출
            PlayEncounterAnimation();

            // 전투 시작 상태 설정
            SetPlayerTurnState("무엇을 할까?");
        }

        // 배틀 중
        public void Update()
        {
            // 화면 그리기
            DrawBattleScreen();

            // 입력 받기
            HandleInput();
        }

        // 전투 오프닝 연출
        private void PlayEncounterAnimation()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black; // 배경색 설정 오류 수정 (White -> Black 순서 확인 필요하지만 원본 존중)

            for (int i = 0; i < Constants.SCREEN_HEIGHT; i += 2)
            {
                // 짝수 줄
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Constants.SCREEN_WIDTH));
                Thread.Sleep(30);

                // 홀수 줄(역순)
                int bottom = Constants.SCREEN_HEIGHT - 1 - i;
                if (bottom > 0)
                {
                    Console.SetCursorPosition(0, bottom);
                    Console.Write(new string(' ', Constants.SCREEN_WIDTH));
                }
                Thread.Sleep(30);
            }

            // 화면 초기화
            Console.ResetColor();
            Console.Clear();
            Thread.Sleep(200);

            // 첫 조우 화면
            SetPlayerTurnState($"앗! 야생 {_enemy.Name}(이)가 튀어나왔다!", 2000);
        }
        
        // 플레이어 턴의 대기 상태로 전환
        private void SetPlayerTurnState(string message, int ms = 1000)
        {
            _battleLog = message;
            DrawBattleScreen();
            Thread.Sleep(ms);
        }

        // 배틀 화면 출력
        private void DrawBattleScreen()
        {
            Console.SetCursorPosition(0, 0);

            // 상단 적 정보(너비 42칸에 맞춰 중앙 정렬 느낌으로)
            DrawSeparator('=');
            Console.WriteLine($" {_enemy.Name} Lv.{_enemy.Level}");
            Console.WriteLine($" HP: {_enemy.CurrentHp}/{_enemy.MaxHp}".PadRight(Constants.SCREEN_WIDTH));
            DrawSeparator('-');

            // 중간 공백(포켓몬이 있는 공간)
            for (int i = 0; i < 7; i++) DrawSeparator(' ');

            // 하단 내 포켓몬 정보
            DrawSeparator('-');
            Console.WriteLine($" {_myPokemon.Name} Lv.{_myPokemon.Level}");
            Console.WriteLine($" HP: {_myPokemon.CurrentHp}/{_myPokemon.MaxHp}".PadRight(Constants.SCREEN_WIDTH));
            DrawSeparator('=');

            // UI 영역(로그 또는 메뉴)
            DrawSeparator('=');
            PrintFixedLine(_battleLog);
            DrawSeparator('-');

            // 기술 목록 표시
            RenderSkillMenu();

            // 빤스런
            DrawSeparator('-');
            Console.WriteLine(" [Space] 도망가기");
        }

        // 기술 목록 표시
        private void RenderSkillMenu()
        {
            int maxSlots = _skillKeys.Length;
            int currentSkillCount = _myPokemon.Skills.Count;

            for (int i = 0; i < maxSlots; i++)
            {
                // 기술이 있는 슬롯
                if (i < currentSkillCount)
                {
                    var skill = _myPokemon.Skills[i];
                    string key = _skillKeyNames[i];
                    string text = $" [{key}] {skill.Name}";
                    PrintFixedLine(text);
                }
                // 기술이 없는 슬롯
                else
                {
                    DrawSeparator(' ');
                }
            }
        }

        // 구분선 헬퍼
        private void DrawSeparator(char c)
        {
            Console.WriteLine(new string(c, Constants.SCREEN_WIDTH - 1));
        }

        // 한글 너비를 고려한 출력
        private void PrintFixedLine(string text)
        {
            int currentLength = GetDisplayLength(text);
            int padding = Math.Max(0, Constants.SCREEN_WIDTH - 1 - currentLength);
            Console.WriteLine(text + new string(' ', padding));
        }

        // 한글(2바이트) 헬퍼
        private int GetDisplayLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (c >= '\uAC00' && c <= '\uD7A3') length += 2;
                else length += 1;
            }
            return length;
        }

        private void HandleInput() 
        {
            // 애니메이션 도중 입력 방지
            if (!Console.KeyAvailable) return;

            // 누른 키가 순서대로 Z, X, C, V인지 확인
            ConsoleKeyInfo key = Console.ReadKey(true);
            for (int i = 0; i < _skillKeys.Length; i++)
            {
                if (key.Key == _skillKeys[i])
                {
                    if (_myPokemon.Skills.Count > i)
                    {
                        ExecuteTurn(_myPokemon.Skills[i]);
                        return;
                    }
                }
            }

            // 도망치기
            if (key.Key == ConsoleKey.Spacebar)
            {
                TryEscape();
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

            // 대기 상태
            if (_myPokemon.CurrentHp > 0 && _enemy.CurrentHp > 0)
            {
                SetPlayerTurnState("무엇을 할까?");
            }
        }

        // 공격 처리
        private void Attack(Pokemon attacker, Pokemon defender, Skill skill)
        {
            // 로그 출력 및 대기
            SetPlayerTurnState($"{attacker.Name}의 {skill.Name}!");

            // 데미지 계산
            int damage = CalculateDamage(attacker, defender, skill);
            defender.CurrentHp = Math.Max(0, defender.CurrentHp - damage);

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

        // 도망치기
        private void TryEscape()
        {
            SetPlayerTurnState("무사히 도망쳤다!");
            EndBattle();
        }

        // 기절 처리
        private void HandleFaint(Pokemon loser)
        {
            SetPlayerTurnState($"{loser.Name}은(는) 쓰러졌다!", 1500);

            if (loser == _enemy)
            {
                // TODO: 경험치 계산, 일단 하드코딩.. 나중에 리팩토링
                int expReward = _enemy.Level * 50;
                SetPlayerTurnState($"승리했다! 경험치 {expReward}를 획득했다.", 1500);

                // 한 번이라도 레벨업 하면 true
                if (_myPokemon.GainExp(expReward))
                {
                    // 레벨 업
                    SetPlayerTurnState($"{_myPokemon.Name}은(는) Lv.{_myPokemon.Level}(으)로 성장했다!", 2000);
                    // 화면 갱신
                    DrawBattleScreen();
                    Thread.Sleep(1000);
                }
            }
            else
            {
                SetPlayerTurnState("눈앞이 캄캄해졌다...", 1500);
            }

            EndBattle();
        }

        // 배틀 종료 및 콜백 호출
        private void EndBattle()
        {
            DrawBattleScreen();
            Thread.Sleep(1000);
            _onBattleEnd?.Invoke();
        }
    }
}