using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading;

namespace CsharpStudy4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Chapter_01.Program.Run();   // 클래스 간 통신
            //Chapter_02.Program.Run();   // 상속
            //Chapter_03.Program.Run();   // 메소드 오버라이딩
            //Chapter_04.Program.Run();   // 추상 클래스
            //Chapter_05.Program.Run();   // 예제 1
            //Chapter_06.Program.Run();   // 인터페이스
            //Shooting_Game.Program.Run();   // 슈팅 게임 예제
            TextRPG.Program.Run();   // 텍스트 RPG 예제
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


/*
 * 상속(Inheritance)
 * 
 * - 기존 클래스의 속성과 메소드를 물려받아 새로운 클래스를 만드는 것
 * 
 * 장점
 * 1. 재사용성이 뛰어나 유지보수에 유리(공통 기능을 한 번만 작성)
 * 2. 계층 구조로 형성 가능
 * 3. 새로운 클래스 추가에 용이함
 * */

// 상속(Inheritance)
namespace Chapter_02
{
    // 부모 클래스
    class Character
    {
        protected string _name = String.Empty;
        protected int _level = 1;
        protected int _hp = 100;
        protected int _maxHp = 100;
        protected int _attack = 30;
        protected int _defense = 20;

        public Character() { }
        public Character(string name)
        {
            _name = name;
            Console.WriteLine($"캐릭터 {_name} 생성!");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {_name}");
            Console.WriteLine($"레벨 : {_level}");
            Console.WriteLine($"HP : {_hp}/{_maxHp}");
            Console.WriteLine($"공격력 : {_attack}");
            Console.WriteLine($"방어력 : {_defense}");
        }
    }

    // 자식 클래스
    class Warrior : Character
    {
        private int _rage = 0;

        // base로 부모 생성자 호출 시 매개변수 전달
        public Warrior(string name) : base(name)
        {
            _attack = 60;
            _defense = 40;
            _maxHp = 150;
            _hp = _maxHp;
        }

        public void ShowInfo()
        {
            base.ShowInfo(); // base로 부모의 ShowInfo() 재사용
            Console.WriteLine($"분노 : {_rage}");
        }
    }

    class Program
    {
        public static void Run()
        {
            Character character = new Character("기본 캐릭터");
            Warrior warrior = new Warrior("전사");

            character.ShowInfo();
            warrior.ShowInfo();
        }
    }
}


/*
 * 메소드 오버라이딩(Method Overriding)
 * 
 * - 자식 클래스에서 부모 클래스의 함수를 재정의하여 사용하는 것, 다형성의 핵심
 * 
 * 장점
 * 1. 확장성이 우수함
 * */

// 메소드 오버라이딩(Method Overriding)
namespace Chapter_03
{
    class Monster
    {
        public string Name { get; set; } = "몬스터";

        // virtual 키워드: 자식 클래스에서 함수 재정의 허용
        public virtual void Attack()
        {
            Console.WriteLine($"{Name}가 멍하니 서 있습니다. (기본 공격)");
        }
    }

    class Slime : Monster
    {
        // override 키워드: 부모 클래스의 함수 재정의
        public override void Attack()
        {
            Console.WriteLine($"[슬라임] {Name}가 끈적한 액체를 뱉습니다! (틱 데미지)");
        }

        public void Split()
        {
            Console.WriteLine($"[슬라임] {Name}가 꿀렁거리며 분열을 시작합니다.");
        }
    }

    class Orc : Monster
    {
        public override void Attack()
        {
            Console.WriteLine($"[오크] {Name}가 거대한 도끼를 휘두릅니다! (물리 데미지)");
        }
    }

    class Skeleton : Monster
    {
        // override 안 함 = 부모의 기본 공격("멍하니 서 있습니다")을 그대로 씀.
    }

    class Program
    {
        public static void Run()
        {
            Monster monster = new Monster();
            Slime slime = new Slime();

            Console.WriteLine("=== 부모 클래스 ===");
            monster.Attack();

            Console.WriteLine();

            Console.WriteLine("=== 자식 클래스(오버라이딩) ===");
            slime.Attack();

            Console.WriteLine();

            // 업캐스팅: 자식 타입을 부모 타입으로 변환하는 것. 안전함
            Console.WriteLine("=== 업캐스팅 ===");
            Monster monster2 = new Slime();
            monster2.Attack();

            // 다운캐스팅(위험 또는 에러 발생)
            // Monster monster3 = new Monster();
            // Slime slime2 = (Slime) monster3;
            // slime2.Attack();

            Console.WriteLine();

            /* 중요: 업캐스팅을 사용하는 이유 */

            // 업캐스팅 미사용: 관리 리스트를 다 따로 만들어줘야 함
            List<Slime> slimes = new List<Slime>();
            List<Orc> orcs = new List<Orc>();
            List<Skeleton> skeletons = new List<Skeleton>();

            slimes.Add(new Slime());
            orcs.Add(new Orc());
            skeletons.Add(new Skeleton());

            // 공격 턴
            Console.WriteLine("=== 업캐스팅 미사용 ===");
            foreach (var s in slimes) s.Attack();
            foreach (var o in orcs) o.Attack();
            foreach (var s in skeletons) s.Attack();

            Console.WriteLine();

            // 업캐스팅 사용: 리스트 1개로 관리 가능
            List<Monster> monsters = new List<Monster>();

            monsters.Add(new Slime());  // 업캐스팅 (Slime -> Monster)
            monsters.Add(new Orc());    // 업캐스팅 (Orc -> Monster)
            monsters.Add(new Skeleton()); // 업캐스팅 (Skeleton -> Monster)

            // 공격 턴
            Console.WriteLine("=== 업캐스팅 사용 ===");
            foreach (var m in monsters)
            {
                m.Attack();

                // 특정 클래스 체크(C# 7.0에서 추가된 is 문법 사용)
                if (m is Slime s)
                {
                    // Java의 instanceof와 유사한데 타입이 맞으면 m을 바로 s에 할당해줌
                    Console.WriteLine("== is 문법 사용 ==");
                    s.Split();
                }

                // 특정 클래스 체크(레거시 문법, Null 체크 필수)
                Slime a = m as Slime;
                if (a != null)
                {
                    Console.WriteLine("== as 문법 사용 ==");
                    a.Split();
                }
            }
        }
    }
}


/*
 * 추상 클래스(Abstract class)
 * 
 * - 직접 객체를 생성할 수 없고, 반드시 상속받아서 구현 및 완성해야 하는 클래스
 * - 오버라이딩과 비슷하나, 좀 더 엄격한 강제성을 가지고 있음
 * */

// 추상 클래스(Abstract class)
namespace Chapter_04
{
    // 부모 클래스(추상)
    abstract class Character
    {
        // 일반 멤버
        public int hp;

        public void NormalMethod()
        {
            // 구현
        }

        // 추상 멤버, 구현 안하면 에러 발생
        public abstract void Job();
    }

    // 자식 클래스
    class Mage : Character
    {
        public override void Job()
        {
            Console.WriteLine("직업: 마법사");
        }
    }

    class Warrior : Character
    {
        public override void Job()
        {
            Console.WriteLine("직업: 전사");
        }
    }

    class Program
    {
        public static void Run()
        {
            // 사용 불가능
            // Character character = new Character();

            Mage mage = new Mage();
            mage.Job();

            Warrior warrior = new Warrior();
            warrior.Job();

            Console.WriteLine();

            // 업캐스팅도 사용 가능
            List<Character> characters = new List<Character>();
            characters.Add(mage);
            characters.Add(warrior);

            foreach (var c in characters)
            {
                c.Job();
            }
        }
    }
}

// 예제 1: 유닛 생성
namespace Chapter_05
{
    abstract class Unit
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Spd { get; set; }

        public Unit(string name)
        {
            Name = name;
        }

        public abstract void ShowStats();
    }

    class Warrior : Unit
    {
        public Warrior(string name) : base(name)
        {
            Job = "전사";
            MaxHp = 200;
            Hp = MaxHp;
            Atk = 80;
            Def = 50;
            Spd = 5;
        }

        public override void ShowStats()
        {
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"[{Job}] {Name}");
            Console.WriteLine($"HP: {Hp}/{MaxHp}");
            Console.WriteLine($"공격력: {Atk}");
            Console.WriteLine($"방어력: {Def}");
            Console.WriteLine($"이동속도: {Spd}");
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine();
        }
    }

    class Mage : Unit
    {
        public int Mana { get; set; }

        public Mage(string name) : base(name)
        {
            Job = "마법사";
            MaxHp = 120;
            Hp = MaxHp;
            Atk = 150;
            Mana = 100;
            Spd = 4;
        }

        public override void ShowStats()
        {
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"[{Job}] {Name}");
            Console.WriteLine($"HP: {Hp}/{MaxHp}");
            Console.WriteLine($"마력: {Atk}");
            Console.WriteLine($"마나: {Mana}");
            Console.WriteLine($"이동속도: {Spd}");
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine();
        }
    }

    class Archer : Unit
    {
        public int Arrow { get; set; }

        public Archer(string name) : base(name)
        {
            Job = "궁수";
            MaxHp = 150;
            Hp = MaxHp;
            Atk = 100;
            Arrow = 50;
            Spd = 6;
        }
        public override void ShowStats()
        {
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"[{Job}] {Name}");
            Console.WriteLine($"HP: {Hp}/{MaxHp}");
            Console.WriteLine($"공격력: {Atk}");
            Console.WriteLine($"화살: {Arrow}");
            Console.WriteLine($"이동속도: {Spd}");
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine();
        }
    }

    class Program
    {
        public static void Run()
        {
            List<Unit> units = new List<Unit>();

            units.Add(new Warrior("홍길동"));
            units.Add(new Mage("김마법"));
            units.Add(new Archer("이궁수"));

            foreach (Unit unit in units)
            {
                unit.ShowStats();
            }
        }
    }
}


/*
 * 인터페이스(Interface)
 * 
 * - 메소드 시그니처만 정의하는 것. 구현은 클래스가 담당
 * - 예시: 인터페이스 => 공격 가능, 구현 => 전사는 검, 마법사는 마법
 * */

// 인터페이스(Interface)
namespace Chapter_06
{
    interface IAttackable
    {
        void Attack(string target);
        int GetAttackPower();
    }

    class Knight : IAttackable
    {
        public string Name { get; set; }
        public int AttackPower { get; set; }

        public Knight() 
        {
            Name = "검사";
            AttackPower = 10;
        }

        public void Attack(string target)
        {
            Console.WriteLine($"검으로 {target}를 공격 했습니다.");
        }

        public int GetAttackPower()
        {
            return AttackPower;
        }
    }

    class Mage : IAttackable
    {
        public string Name { get; set; }
        public int AttackPower { get; set; }

        public Mage()
        {
            Name = "마법사";
            AttackPower = 15;
        }

        public void Attack(string target)
        {
            Console.WriteLine($"마법으로 {target}를 공격 했습니다.");
        }

        public int GetAttackPower()
        {
            return AttackPower;
        }
    }

    class Program
    {
        public static void Run()
        {
            Knight knight = new Knight();
            knight.Attack("오크");

            Mage mage = new Mage();
            mage.Attack("고블린");
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

// 간단한 텍스트 RPG
namespace TextRPG
{
    // 스탯
    public class INFO
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Hp { get; set; }
    }

    // 플레이어
    public class Player
    {
        public INFO Info { get; set; } = new INFO();

        public void TakeDamage(int attack) { Info.Hp -= attack; }

        public void SetHp(int hp) { Info.Hp = hp; }

        public void SelectJob()
        {
            Console.Write("직업을 선택하세요(1. 기사, 2. 마법사, 3. 도적): ");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                    Info.Name = "기사";
                    Info.Hp = 100;
                    Info.Attack = 10;
                    break;
                case 2:
                    Info.Name = "마법사";
                    Info.Hp = 90;
                    Info.Attack = 15;
                    break;
                case 3:
                    Info.Name = "도둑";
                    Info.Hp = 85;
                    Info.Attack = 13;
                    break;
            };
        }

        public void Render()
        {
            Console.WriteLine("==============================");
            Console.WriteLine($"직업: {Info.Name}");
            Console.WriteLine($"체력: {Info.Hp}\t공격력: {Info.Attack}");
            Console.WriteLine("==============================");
        }

        public Player() { }
    }

    // 몬스터
    public class Monster
    {
        public INFO Info { get; set; } = new INFO();

        public void TakeDamage(int attack) { Info.Hp -= attack; }

        public void Render()
        {
            Console.WriteLine("==============================");
            Console.WriteLine($"이름: {Info.Name}");
            Console.WriteLine($"체력: {Info.Hp}\t공격력: {Info.Attack}");
            Console.WriteLine("==============================");
            Console.WriteLine();
        }

        public Monster() { }

        public Monster(string name, int hp, int attack) 
        {
            Info.Name = name;
            Info.Hp = hp;
            Info.Attack = attack;
        }
    }

    // 필드(사냥터)
    public class Field
    {
        Player _player;
        Monster _monster;

        public Player Player 
        {
            get => _player;
            set => _player = value; 
        }
        public Monster Monster
        {
            get => _monster;
            set => _monster = value;
        }

        // 과정 관리
        public void Progress()
        {
            int input = 0;
            while (true)
            {
                Console.Clear();
                Player.Render();
                DrawMap();
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                    case 2:
                    case 3:
                        CreateMonster(input);
                        Fight();
                        break;
                    case 4:
                        return;
                }
            }
        }

        // 맵 선택창 출력
        public void DrawMap()
        {
            Console.WriteLine("1. 초보 맵");
            Console.WriteLine("2. 중수 맵");
            Console.WriteLine("3. 고수 맵");
            Console.WriteLine("4. 이전으로");
            Console.WriteLine("=============");
            Console.Write("맵을 선택하세요: ");
        }

        // input값에 맞는 몬스터 생산
        public void CreateMonster(int input)
        {
            switch (input)
            {
                case 1:
                    Monster = new Monster("초보 몹", 30, 3);
                    break;
                case 2:
                    Monster = new Monster("중수 몹", 60, 6);
                    break;
                case 3:
                    Monster = new Monster("고수 몹", 90, 9);
                    break;
            }
        }

        // 몬스터와 전투
        public void Fight()
        {
            int input = 0;

            while (true)
            {
                Console.Clear();
                Player.Render();
                Monster.Render();

                Console.Write("1: 공격, 2: 도망 : ");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        // 몬스터 공격
                        Player.TakeDamage(Monster.Info.Attack);
                        // 플레이어 공격
                        Monster.TakeDamage(Player.Info.Attack);
                        break;
                    case 2:
                        return;
                }

                if (Monster.Info.Hp <= 0)
                {
                    Monster = null;
                    break;
                }
                else if (Player.Info.Hp <= 0)
                {
                    Player.Info.Hp = 100;

                    Console.Clear();
                    Console.WriteLine("============");
                    Console.WriteLine("=== 사망 ===");
                    Console.WriteLine("============");
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
    }

    // 게임 매니저
    public class GameManager
    {
        public Player player = null;
        public Field field = null;

        // 초기화
        public void Initialize()
        {
            player = new Player();
            field = new Field();
            player.SelectJob();
        }

        // 과정 관리
        public void Progress()
        {
            int input = 0;

            while (true)
            {
                Console.Clear();
                player.Render();
                Console.Write("1: 사냥터, 2: 종료: ");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1: // 사냥터
                        field.Player = player;
                        field.Progress();
                        break;
                    case 2: // 종료
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

    class Program
    {
        public static void Run()
        {
            GameManager gameMain = new GameManager();

            gameMain.Initialize();
            gameMain.Progress();
        }
    }
}