using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CsharpStudy3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Chapter_01.Program.Run();    // 클래스(Class)
            //Chapter_02.Program.Run();    // 예제 1
            Chapter_03.Program.Run();    // 예제 2
        }
    }
}


/**********************************************************
  * 2026/01/13                                            *
  **********************************************************/

// 클래스(Class)
namespace Chapter_01
{
    /*
     * 클래스(Class)
     * 
     * - 객체를 만들기 위한 설계도
     * 
     * 장점
     * 1. 데이터와 기능의 결합 가능
     * 2. 재사용성이 뛰어나 유지보수에 유리
     * */

    class Character
    {
        // public: 외부에서 접근 가능
        public string name;
        public int level;
        public int hp;
        public int maxHP;
        public int mp;
        public int maxMP;

        // private: 외부에서 접근 불가(디폴트)
        int userId;

        // 생성자(Constructor): 객체가 생성될 때 초기화를 담당하는 함수
        public Character() { name = "홍길동"; }

        // 인자가 있는 생성자
        public Character
        (
              string _name
            , int _level
            , int _hp
            , int _maxHP
            , int _mp
            , int _maxMP
        )
        {
            name = _name;
            level = _level;
            hp = _hp;
            maxHP = _maxHP;
            mp = _mp;
            maxMP = _maxMP;
        }

        // 함수
        public void showStats()
        {
            Console.WriteLine("이름: " + name);
            Console.WriteLine("레벨: " + level);
            Console.WriteLine("Hp: " + hp);
            Console.WriteLine("MaxHP: " + maxHP);
            Console.WriteLine("MP: " + mp);
            Console.WriteLine("MaxMP: " + maxMP);
        }
    }

    class Program
    {
        public static void Run()
        {
            Character player = new Character();

            player.level = 1;
            player.hp = 100;
            player.maxHP = 100;
            player.mp = 100;
            player.maxMP = 100;
            // player.userId = "dong1";     // 에러

            // 클래스 내 함수 사용
            player.showStats();
            Console.WriteLine();

            // 인자 있는 생성자로 객체 생성
            Character player2 = new Character("김철수", 100, 10000, 10000, 1000, 1000);
            player2.showStats();
        }
    }
}

// 예제 1: 캐릭터 클래스 구현
namespace Chapter_02
{
    /*
     * 예제 1: 캐릭터 클래스 구현
     * */

    // 클래식 문법
    class Character
    {
        string name;
        int level;
        int hp;
        int maxHP;
        int mp;
        int maxMP;

        public void ShowInfo()
        {
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"레벨: {level}");
            Console.WriteLine($"체력: {hp} / {maxHP}");
            Console.WriteLine($"마나: {mp} / {maxMP}");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp < 0) hp = 0;

            Console.WriteLine($"{name}이(가) {damage}만큼 데미지를 받았습니다.");
            Console.WriteLine($"남은 체력: {hp} / {maxHP}");
        }

        public void TakeHeal(int amount)
        {
            hp += amount;
            if (hp > maxHP) hp = maxHP;

            Console.WriteLine($"{name}이(가) {amount}만큼 회복되었습니다.");
            Console.WriteLine($"남은 체력: {hp} / {maxHP}");
        }

        public Character(string name, int level, int hp, int maxHP, int mp, int maxMP)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
            this.maxHP = maxHP;
            this.mp = mp;
            this.maxMP = maxMP;
        }
    }

    // 최신 C# 문법
    class Character2
    {
        private string _name;
        private int _level;
        private int _hp;
        private int _maxHP;
        private int _mp;
        private int _maxMP;

        public string Name
        {
            get => _name;   // { return } 생략
            set => _name = value ?? string.Empty;   // string.Empty = ""
        }
        public int Level
        {
            get => _level;
            set => _level = (value < 1) ? 1 : value;
        }
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                if (_hp < 0) _hp = 0;
                if (_maxHP > 0 && _hp > _maxHP) _hp = _maxHP;
            }
        }
        public int MaxHP
        {
            get => _maxHP;
            set
            {
                _maxHP = (value < 1) ? 1 : value;
                if (_hp > _maxHP) _hp = _maxHP;
            }
        }
        public int Mp
        {
            get => _mp;
            set
            {
                _mp = value;
                if (_mp < 0) _mp = 0;
                if (_maxMP > 0 && _mp > _maxMP) _mp = _maxMP;
            }
        }
        public int MaxMP
        {
            get => _maxMP;
            set
            {
                _maxMP = (value < 1) ? 1 : value;
                if (_mp > _maxMP) _mp = _maxMP;
            }
        }
    }

    class Program
    {
        public static void Run()
        {
            // 객체 생성
            Character player1 = new Character("홍길동", 10, 52, 200, 84, 120);

            // 필드에 값 할당(public)
            //player1.name = "홍길동";
            //player1.level = 10;
            //player1.hp = 52;
            //player1.maxHP = 200;
            //player1.mp = 84;
            //player1.maxMP = 120;

            // 메소드 호출
            player1.ShowInfo();

            // 인자가 있는 메소드 호출
            player1.TakeDamage(50);
            player1.TakeHeal(30);

            // 새로운 객체 생성해서 임의의 값 입력 후 출력
            Character player2 = new Character("김철수", 48, 239, 560, 293, 320);

            //player2.name = "김철수";
            //player2.level = 48;
            //player2.hp = 239;
            //player2.maxHP = 560;
            //player2.mp = 293;
            //player2.maxMP = 320;

            player2.ShowInfo();
        }
    }
}

// 예제 2: 몬스터 클래스 구현
namespace Chapter_03
{
    class Monster
    {
        public string Name { get; set; } = "슬라임";
        public int Level { get; set; } = 1;
        public int Hp { get; set; } = 50;
        public int Attack { get; set; } = 10;
        public int Defense { get; set; } = 5;
        public int ExpReward { get; set; } = 10;

        public Monster() { }
        public Monster(string name, int level)
        {
            Name = name;
            Level = level;
            Hp = 50 * level;
            Attack = 10 * level;
            Defense = 5 * level;
            ExpReward = 10 * level;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} (Lv.{Level})");
            Console.WriteLine($"HP: {Hp}");
            Console.WriteLine($"공격력: {Attack}");
            Console.WriteLine($"방어력: {Defense}");
            Console.WriteLine($"경험치: {ExpReward}");
        }
    }

    class Program
    {
        public static void Run()
        {
            // 기본 생성자로 객체 생성 및 스탯 출력
            Monster slime = new Monster();
            slime.ShowInfo();

            Console.WriteLine();

            // 인자가 있는 생성자로 객체 생성 및 스탯 출력
            Monster goblin = new Monster("고블린", 5);
            goblin.ShowInfo();

            // 클래스의 배열 선언(내용물 없음)
            Monster[] monsters = new Monster[3];
            
            // 내용물(클래스) 삽입
            monsters[0] = new Monster("늑대", 3);
            monsters[1] = new Monster("오크", 12);
            monsters[2] = new Monster("트롤", 38);

            Console.WriteLine("\n=== 필드 몬스터 ===");
            foreach (Monster monster in monsters)
            {
                monster.ShowInfo();
                Console.WriteLine();
            }
        }
    }
}