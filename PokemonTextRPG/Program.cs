using System;
using System.Threading;
using PokemonTextRPG.Character;
using PokemonTextRPG.Managers;
using PokemonTextRPG.Map;
using PokemonTextRPG.Map.Locations;
using PokemonTextRPG.Monster;

namespace PokemonTextRPG
{ 
    internal class Program
    {
        // 싱글톤
        static bool _isGameRunning = true;
        static GameState _currentState = GameState.Field;

        static Player _player;
        static MapBase _currentMap;
        static BattleManager _battleManager = new BattleManager();

        // 게임 초기화
        static void InitializeGame()
        {
            // 콘솔 설정
            Console.Title = Constants.TITLE;
            Console.CursorVisible = false;

            // 해상도 설정
            try
            {
                Console.SetWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
                Console.SetBufferSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            }
            catch
            {
                Console.WriteLine("해상도 설정 실패. 콘솔 폰트 크기를 줄인 후 다시 실행해주세요.");
                Thread.Sleep(5000);
                return;
            }

            // 맵 로드 (태초마을)
            _currentMap = new PalletTown();

            // 플레이어 생성
            _player = new Player(_currentMap.StartX, _currentMap.StartY);

            // 초기 포켓몬 지급
            var starter = PokemonFactory.Create(PokemonId.Charmander, 5);
            _player.Team.Add(starter);
        }

        // 필드 화면 렌더링
        static void RenderField()
        {
            // 맵 렌더링
            MapRenderer.Draw(_currentMap, _player.X, _player.Y);

            // 하단 UI 렌더링
            int uiY = 20;
            Console.SetCursorPosition(0, uiY++);
            Console.WriteLine(new string('=', Constants.SCREEN_WIDTH - 1));

            // 내 위치
            ClearLine(uiY);
            Console.SetCursorPosition(0, uiY++);
            Console.Write($" [내 위치] ({_player.X:D2}, {_player.Y:D2})");

            // 선두 포켓몬
            ClearLine(uiY);
            Console.SetCursorPosition(0, uiY++);
            Console.Write($" [파트너] {_player.Team[0].Name} Lv.{_player.Team[0].Level}");

            // 조작 키
            ClearLine(uiY);
            Console.SetCursorPosition(0, uiY);
            Console.Write(" [Key] 방향키: 이동 / ESC: 종료");
        }

        // 특정 줄 공백으로 완전 삭제
        static void ClearLine(int y)
        {
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', Constants.SCREEN_WIDTH - 1));
        }

        // 키 입력
        static void ProcessFieldInput()
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
                CheckPortal();
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
                    // 배틀 매니저 초기화 및 상태 전환 콜백
                    _battleManager.StartBattle(_player, PokemonFactory.CreateWildPokemon(), () =>
                    {
                        Console.Clear(); // 화면 초기화
                        _currentState = GameState.Field;
                    });

                    _currentState = GameState.Battle;
                }
            }
        }

        // 포탈 체크
        static void CheckPortal()
        {
            // 해당 위치에 포탈이 있는 지 체크
            Portal portal = _currentMap.GetPortal(_player.X, _player.Y);
            if (portal == null) return;

            // 있으면 맵 데이터 받아와 이동
            _currentMap = MapFactory.Create(portal.TargetMapId);

            _player.X = portal.TargetX;
            _player.Y = portal.TargetY;

            // 맵을 옮길 땐 반드시 콘솔 초기화
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            InitializeGame();

            while (_isGameRunning)
            {
                switch (_currentState)
                {
                    case GameState.MainMenu:
                        break;
                    case GameState.Field:
                        RenderField();
                        ProcessFieldInput();
                        break;
                    case GameState.Battle:
                        _battleManager.Update();
                        break;
                    case GameState.GameOver:
                        break;
                }
            }
        }
    }
}