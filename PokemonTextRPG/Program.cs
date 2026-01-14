using System;
using System.Collections.Generic;

using PokemonTextRPG.Character;
using PokemonTextRPG.Map;
using PokemonTextRPG.Map.Locations;
using PokemonTextRPG.Monster;

namespace PokemonTextRPG
{
    // 상수
    public class Constants
    {
        public const int SCREEN_WIDTH = 100;
        public const int SCREEN_HEIGHT = 30;
        public static Random random = new Random();
        public const int APPEAR_PERCENTAGE = 20;
    }

    // 게임의 현재 상태
    public enum GameState
    {
        MainMenu,   // 메인 메뉴
        Field,      // 필드
        Battle,     // 배틀
        GameOver    // 게임 오버
    }

    // 기술 타입
    public enum MoveType
    {
        Physical,   // 물리
        Special     // 특수
    }

    // 기술 클래스
    public class Skill
    {
        public string Name { get; set; }    // 이름
        public MoveType Type { get; set; } // 기술 타입
        public int Power { get; set; }      // 위력

        public Skill(string name, MoveType type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }
    }

    // 포켓몬 클래스
    public class Pokemon
    {
        public string Name { get; set; }    // 이름
        public int Level { get; set; }      // 레벨
        public int MaxHp { get; set; }      // 최대 체력
        public int CurrentHp { get; set; }  // 현재 체력

        // 기술 목록
        public List<Skill> Skills { get; set; } = new List<Skill>();

        // 종족값 (HP, 공격, 방어, 특공, 특방, 스피드)
        public int[] BaseStats { get; set; }

        // 실제 능력치
        public int Atk { get; set; }
        public int Def { get; set; }
        public int SpAtk { get; set; }
        public int SpDef { get; set; }
        public int Spd { get; set; }

        public Pokemon(string name, int level, int[] baseStats)
        {
            Name = name;
            Level = level;
            BaseStats = baseStats;
        }

        // 실능치 갱신
        private void UpdateStats()
        {
            MaxHp = CalculateHP(BaseStats[0], Level);
            Atk = CalculateStat(BaseStats[1], Level);
            Def = CalculateStat(BaseStats[2], Level);
            SpAtk = CalculateStat(BaseStats[3], Level);
            SpDef = CalculateStat(BaseStats[4], Level);
            Spd = CalculateStat(BaseStats[5], Level);
        }

        // 레벨 업
        public void LevelUp()
        {
            Level++;

            // 능력치 재계산
            int oldMaxHp = MaxHp;
            UpdateStats();

            // 늘어난 최대 체력만큼 현재 체력 회복
            CurrentHp += MaxHp - oldMaxHp;
        }

        // 체력 계산
        private int CalculateHP(int baseStat, int level)
        {
            int core = 2 * baseStat;
            return (core * level / 100) + level + 10;
        }

        // 스탯 계산(개체치 6Z, 노력치 0, 성격보정 1.0)
        private int CalculateStat(int baseStat, int level)
        {
            int core = 2 * baseStat;
            return (core * level / 100) + 5;
        }
    }

    internal class Program
    {
        static bool _isGameRunning = true;
        static Player _player;
        static MapBase _currentMap;

        // 게임 초기화
        static void InitializeGame()
        {
            // 콘솔 설정
            Console.Title = "Pokemon RPG";
            Console.CursorVisible = false;

            // 100x30 해상도 설정
            try
            {
                Console.SetWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
                Console.SetBufferSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            }
            catch (Exception e)
            {
                Console.WriteLine("해상도 설정 실패. 콘솔 폰트 크기를 줄인 후 다시 실행해주세요.");
            }

            // 맵 로드 (태초마을)
            _currentMap = new PalletTown();

            // 플레이어 생성
            _player = new Player(_currentMap.StartX, _currentMap.StartY);

            // 초기 포켓몬 지급
            var starter = PokemonFactory.Create(PokemonId.Charmander, 5);
            _player.Team.Add(starter);
        }

        // 키 입력
        static void ProcessInput()
        {
            // 키 입력 대기
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // 이동 예정 좌표
            int nextX = _player.X;
            int nextY = _player.Y;

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: nextY--; break;
                case ConsoleKey.DownArrow: nextY++; break;
                case ConsoleKey.LeftArrow: nextX--; break;
                case ConsoleKey.RightArrow: nextX++; break;
                case ConsoleKey.Escape:
                    _isGameRunning = false; // 게임 종료
                    return;
            }

            // 충돌 체크
            if (_currentMap.IsWalkable(nextX, nextY))
            {
                _player.X = nextX;
                _player.Y = nextY;

                CheckEvents();
            }
        }

        // 이벤트 체크
        static void CheckEvents()
        {
            // 현재 위치가 풀숲인지 확인
            if (_currentMap.IsBush(_player.X, _player.Y))
            {
                // 야생 포켓몬 조우
                if (Constants.random.Next(0, 100) < Constants.APPEAR_PERCENTAGE)
                {
                    Console.Clear();
                    Console.WriteLine("앗! 야생 포켓몬이 튀어나왔다!");
                    Console.ReadKey();
                }
            }
        }

        // 현재 맵 렌더링
        static void Render()
        {
            // 맵 그리기
            MapRenderer.Draw(_currentMap, _player.X, _player.Y);

            // 하단 UI 영역
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("==================================================");
            Console.WriteLine($" [Player] 위치: ({_player.X}, {_player.Y}) | 파트너: {_player.Team[0].Name} Lv.{_player.Team[0].Level}");
            Console.WriteLine(" [조작] 방향키: 이동 / ESC: 종료");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            InitializeGame();

            while (_isGameRunning)
            {
                ProcessInput();
                Render();
            }
        }
    }
}
