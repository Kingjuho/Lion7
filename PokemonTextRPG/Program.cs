using System;
using System.Collections.Generic;

using PokemonTextRPG.Character;
using PokemonTextRPG.Map;
using PokemonTextRPG.Map.Locations;
using PokemonTextRPG.Monster;

namespace PokemonTextRPG
{ 
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
            catch
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
            Console.WriteLine($"==================================================");
            Console.WriteLine($" [Player] 위치: ({_player.X}, {_player.Y}) | 파트너: {_player.Team[0].Name} Lv.{_player.Team[0].Level}");
            Console.WriteLine($" [조작] 방향키: 이동 / ESC: 종료");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            InitializeGame();

            while (_isGameRunning)
            {
                Render();
                ProcessInput();
            }
        }
    }
}
