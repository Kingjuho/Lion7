using PokemonTextRPG.Character;
using PokemonTextRPG.Map;
using PokemonTextRPG.Map.Locations;
using PokemonTextRPG.Pokemons;
using System;
using System.Threading;

namespace PokemonTextRPG.Managers
{
    public class GameManager
    {
        // 게임 매니저(싱글톤)
        public static GameManager Instance { get; private set; } = new GameManager();

        // 현재 모드
        public GameState CurrentState { get; set; } = GameState.MainMenu;
        // 플레이어 인스턴스
        public Player Player { get; private set; }
        // 현재 맵 인스턴스
        public MapBase CurrentMap { get; private set; }

        private BattleManager _battleManager;
        private FieldManager _fieldManager;

        private GameManager() { }

        // 메인 메뉴 화면
        public void ProcessMainMenu()
        {
            // 화면 그리기
            UIManager.DrawMainMenu();

            // 입력 대기 (여기서 멈춰 있음)
            ConsoleKeyInfo key = Console.ReadKey(true);

            // 엔터 키 누르면 게임 시작
            if (key.Key == ConsoleKey.Enter) ChangeState(GameState.Field);
        }

        // 게임 초기화 함수
        public void Initialize()
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
            CurrentMap = new PalletTown();

            // 플레이어 생성
            Player = new Player(CurrentMap.StartX, CurrentMap.StartY);

            // 초기 포켓몬 지급
            var starter = PokemonFactory.Create(PokemonId.Charmander, 5);
            Player.Team.Add(starter);

            // 초기 아이템 지급
            Player.AddItem(Items.ItemId.Potion, 5);

            // 매니저 인스턴스 생성
            _battleManager = new BattleManager();
            _fieldManager = new FieldManager(Player, CurrentMap, _battleManager);
        }

        // 실행 함수
        public void Run()
        {
            while (true)
            {
                switch (CurrentState)
                {
                    case GameState.MainMenu:
                        ProcessMainMenu();
                        break;
                    case GameState.Field:
                        _fieldManager.Update();
                        break;
                    case GameState.Battle:
                        _battleManager.Update();
                        break;
                }
            }
        }

        // 맵 변경
        public void ChangeMap(MapBase newMap)
        {
            CurrentMap = newMap;
            _fieldManager.SetMap(newMap);
        }

        // 상태 변경
        public void ChangeState(GameState newState)
        {
            Console.Clear();
            CurrentState = newState;

            // 깜빡임 방지
            if (newState == GameState.Field) _fieldManager.Update();
        }
    }
}