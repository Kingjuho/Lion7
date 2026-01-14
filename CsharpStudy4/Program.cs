using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Chapter_01.Program.Run();   // 클래스 간 통신
            Shooting_Game.Program.Run();   // 슈팅 게임 예제
        }
    }
}

// 클래스 간 통신
namespace Chapter_01
{
    class Player
    {
        public int hp;
        public int atk;
        int _hp2 = 100;
        int _atk2 = 10;

        public int Hp2 
        { 
            get => _hp2;
            private set
            {
                _hp2 = (value < 0) ? 0 : value;
            }
        }
        public int Atk2
        {
            get => _atk2;
            private set => _atk2 = value;
        }

        public void Render()
        {
            Console.WriteLine("=== 플레이어 ===");
            Console.WriteLine($"체력: {hp}");
            Console.WriteLine($"공격력: {atk}");
            Console.WriteLine($"체력2: {Hp2}");
            Console.WriteLine($"공격력2: {Atk2}");
        }

        public void TakeDamage(int damage)
        {
            Hp2 -= damage;
        }
    }

    class Monster
    {
        public int hp;
        public int atk;
        int _hp2 = 100;
        int _atk2 = 5;

        public int Hp2
        {
            get => _hp2;
            private set
            {
                _hp2 = (value < 0) ? 0 : value;
            }
        }
        public int Atk2
        {
            get => _atk2;
            set => _atk2 = value;
        }

        public void Render()
        {
            Console.WriteLine("=== 몬스터 ===");
            Console.WriteLine($"체력: {hp}");
            Console.WriteLine($"공격력: {atk}");
            Console.WriteLine($"체력2: {Hp2}");
            Console.WriteLine($"공격력2: {Atk2}");
        }

        public void TakeDamage(int damage)
        {
            Hp2 -= damage;
        }
    }

    class Program
    {
        public static void Run()
        {
            Player player = new Player();
            player.atk = 10;
            player.hp = 100;
            player.Render();

            Monster monster = new Monster();
            monster.atk = 5;
            monster.hp = 100;
            monster.Render();

            // 클래스 간 통신 시작
            monster.hp -= player.atk;
            player.hp -= monster.atk;

            player.Render();
            monster.Render();

            // Private 멤버 변수 통신, 클래스 내에 검증된 public 함수를 거쳐서 통신시켜야 함
            player.TakeDamage(monster.Atk2);
            monster.TakeDamage(player.Atk2);

            player.Render();
            monster.Render();
        }
    }
}

// 슈팅게임
namespace Shooting_Game
{
    static class Constants
    {
        public const int SCREEN_WIDTH = 80;
        public const int SCREEN_HEIGHT = 25;
        public const int PLAYER_START_X = 0;
        public const int PLAYER_START_Y = 12;
        public const int SCORE_X = 63;
        public const int SCORE_Y = 1;
        public const int BULLETS_LIMIT = 20;
        public static Random random = new Random(); // 상수는 아니지만..
    }

    class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; }

        public void Update()
        {
            if (!IsActive) return;

            X++;
            if (X > Constants.SCREEN_WIDTH - 2) IsActive = false;
        }

        public void Draw()
        {
            if (!IsActive) return;

            Console.SetCursorPosition(X, Y);
            Console.Write("->");
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Score { get; set; } = 0;
        public List<Bullet> bullets { get; private set; } = new List<Bullet>(Constants.BULLETS_LIMIT);

        public Player() 
        {
            X = Constants.PLAYER_START_X;
            Y = Constants.PLAYER_START_Y;

            for (int i = 0; i < Constants.BULLETS_LIMIT; i++) bullets.Add(new Bullet());
        }

        public void KeyInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    // 유연한 이동을 위해 Setter 무결성 체크 X, 유저 이동만 제한
                    case ConsoleKey.UpArrow: Y = Math.Max(0, Y - 1); break;
                    case ConsoleKey.DownArrow: Y = Math.Min(Constants.SCREEN_HEIGHT - 3, Y + 1); break;
                    case ConsoleKey.LeftArrow: X = Math.Max(0, X - 1); break;
                    case ConsoleKey.RightArrow: X = Math.Min(Constants.SCREEN_WIDTH - 5, X + 1); break;
                    case ConsoleKey.Spacebar: Fire(); break;
                }
            }
        }

        private void Fire()
        {
            foreach (var b in bullets)
            {
                if (!b.IsActive)
                {
                    b.IsActive = true;
                    b.X = X + 3;
                    b.Y = Y + 1;
                    break;
                }
            }
        }

        public void UpdateBullet()
        {
            foreach (var b in bullets) b.Update();
        }

        public void Draw()
        {
            string[] player = new string[]
            {
                "->",
                ">>>",
                "->"
            };

            for (int i = 0; i < player.Length; i++)
            {
                // 위부터 차례대로 출력
                Console.SetCursorPosition(X, Y + i);
                Console.WriteLine(player[i]);
            }

            // 플레이어가 쏜 총알을 그림
            foreach (var b in bullets) b.Draw();
        }
    }

    class Enemy
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Enemy() { Respawn(); }

        public void Respawn()
        {
            X = Constants.SCREEN_WIDTH - 5;
            Y = Constants.random.Next(1, Constants.SCREEN_HEIGHT - 3);
        }

        public void Update()
        {
            X--;
            if (X < 1) Respawn();
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("<-0->");
        }
    }

    class GameManager
    {
        Player _player;
        Enemy _enemy;

        public GameManager()
        {
            // 콘솔 설정
            Console.CursorVisible = false;
            Console.SetWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Console.SetBufferSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);

            // 플레이어, 적 생성
            _player = new Player();
            _enemy = new Enemy();
        }

        public void Run()
        {
            int lastTick = Environment.TickCount;
            while (true)
            {
                // 프레임 제한
                if (Environment.TickCount - lastTick < 50) continue;
                lastTick = Environment.TickCount;

                // 입력 처리
                _player.KeyInput();

                // 업데이트
                _player.UpdateBullet();
                _enemy.Update();

                // 충돌 검사
                CheckCollision();

                // 그리기
                Console.Clear();
                _player.Draw();
                _enemy.Draw();
                DrawUI();
            }
        }

        private void CheckCollision()
        {
            foreach (var b in _player.bullets)
            {
                if (b.IsActive)
                {
                    if ( b.Y == _enemy.Y && b.X == _enemy.X - 1 && b.X <= _enemy.X + 2)
                    {
                        _enemy.Respawn();
                        b.IsActive = false;
                        _player.Score += 100;
                    }
                }
            }
        }

        private void DrawUI()
        {
            Console.SetCursorPosition(Constants.SCORE_X, Constants.SCORE_Y);
            Console.Write($"Score : {_player.Score}");
        }
    }

    class Item
    {
        public string Name { get; set; }
        public string Sprite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("Item★");
        }
    }

    class Program
    {
        public static void Run()
        {
            GameManager game = new GameManager();
            game.Run();
        }
    }
}