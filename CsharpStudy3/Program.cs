using Chapter_05;
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
            //Chapter_03.Program.Run();    // 예제 2
            //Chapter_04.Program.Run();    // 프로퍼티(Property)
            //Chapter_05.Program.Run();    // 예제 1
            //Chapter_06.Program.Run();    // 예제 2
            //Chapter_07.Program.Run();    // 정적 멤버
            // Chapter_08.Program.Run();    // this 키워드
            Chapter_09.Program.Run();    // 종합 예제
        }
    }
}


/*
 * 클래스(Class)
 * 
 * - 객체를 만들기 위한 설계도
 * 
 * 장점
 * 1. 데이터와 기능의 결합 가능
 * 2. 재사용성이 뛰어나 유지보수에 유리
 * */

// 클래스(Class)
namespace Chapter_01
{
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


/*
 * 프로퍼티(Property)
 * 
 * 1. 필드에 대한 접근을 제어하는 특별한 멤버
 * 2. get과 set 접근자를 통해 값 읽기/쓰기 가능
 * */

// 프로퍼티(Property)
namespace Chapter_04
{
    // 기본 문법
    class DefaultProp
    {
        private int Att;
        
        public int GetAtt() { return Att; }
        public void SetAtt(int _Att) { Att = _Att; }
    }

    // 기본 C# 문법
    class CSharpProp
    {
        private int _level;
        private int _hp;

        // 기본적인 get set 작성 방법
        public int Level
        {
            get { return _level; }
            set { _level = (value < 1) ? 1 : value; }
        }

        // C# 7.0부터 지원하는 방식
        public int Hp
        {
            get => _hp;
            private set => _hp = (value < 1) ? 1 : value;
        }
    }

    // 자동 생성 문법
    class AutoProp
    {
        public int Level { get; set; }
        public int MaxHP { get; private set; }  // 읽기 전용
        int Hp { get; set; }    // 특수한 경우에만 사용(데이터 직렬화 등)
    }

    class Program
    {
        public static void Run()
        {
            // 기본 문법 프로퍼티
            Console.WriteLine("=== 기본 문법 ===");
            DefaultProp player1 = new DefaultProp();
            player1.SetAtt(1);
            Console.WriteLine(player1.GetAtt());

            Console.WriteLine();

            // 기본 C# 문법 프로퍼티
            Console.WriteLine("=== 기본 C# 문법 ===");
            CSharpProp player2 = new CSharpProp();
            player2.Level = 1;  // 쓰기
            Console.WriteLine(player2.Level);   // 읽기
            
            // player2.Hp = 100;   // 에러
            Console.WriteLine(player2.Hp);  // 읽기(디폴트 값)

            Console.WriteLine();

            // 자동 생성 문법 프로퍼티
            Console.WriteLine("=== 자동 생성 문법 ===");
            AutoProp player3 = new AutoProp();
            player3.Level = 2;  // 쓰기
            Console.WriteLine(player3.Level);   // 읽기
            
            // player3.MaxHP = 100; // 에러
            Console.WriteLine(player3.MaxHP);   // 읽기(디폴트 값)
        }
    }
}

// 예제 1: 캐릭터 클래스 구현
namespace Chapter_05
{
    class Player
    {
        string _name;
        int _gold;

        public string Name
        {
            get => _name;
            set => _name = value ?? String.Empty;
        }
        public int Gold
        {
            get => _gold;
            set
            {
                if (value < 0) Console.WriteLine("골드가 부족합니다.");
                else _gold = value;
            }
        }
    }

    class Program
    {
        public static void Run()
        {
            Player player = new Player();
            player.Name = "홍길동";
            player.Gold = -100;

            Console.WriteLine($"이름: {player.Name}");
            Console.WriteLine($"골드: {player.Gold}");
        }
    }
}

// 예제 2: 학생 성적 관리 시스템 구현
namespace Chapter_06
{
    class Student
    {
        private int _score;
        
        public string Name { get; private set; }

        public int Score
        {
            get => _score;
            set
            {
                if (value < 0) _score = 0;
                else if (value > 100) _score = 100;
                else _score = value;
            }
        }
        public char Grade
        {
            get
            {
                if (_score >= 90) return 'A';
                if (_score >= 80) return 'B';
                if (_score >= 70) return 'C';
                if (_score >= 60) return 'D';
                return 'F';
            }
        }

        public Student() { }
        public Student(string name) { Name = name; }

        public void ShowInfo()
        {
            Console.WriteLine($"━━━━━━━━━━━━━━━━");
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"점수: {Score}점");
            Console.WriteLine($"등급: {Grade}");
            Console.WriteLine($"━━━━━━━━━━━━━━━━");
        }
    }

    class Program
    {
        public static void Run()
        {
            Student student = new Student("홍길동");

            student.Score = 95;
            student.ShowInfo();

            Console.WriteLine();

            student.Score = 75;
            student.ShowInfo();

            Console.WriteLine();

            // 잘못된 값 입력 시도
            student.Score = 150;
            student.ShowInfo();

            student.Score = -10;
            student.ShowInfo();
        }
    }
}


/*
 * 정적 멤버(Static members)
 * 
 * 1. 객체를 생성하지 않고도 사용할 수 있는 변수/함수
 * 2. 모든 객체가 전부 공유함
 * */

// 정적 멤버(Static members)
namespace Chapter_07
{
    class Character
    {
        public static int totalCount = 0;   // 모든 캐릭터가 공유
        public string name; // 캐릭터마다 달라야 함

        public Character() { totalCount++; }
        ~Character() { totalCount--; }
    }

    class Program
    {
        public static void Run()
        {
            Character c1 = new Character();
            Character c2 = new Character();

            c1.name = "전사";
            c2.name = "마법사";

            Console.WriteLine(c1.name);
            Console.WriteLine(c2.name);

            Console.WriteLine($"카운트: {Character.totalCount}");
            // Console.WriteLine($"카운트: {c1.totalCount}");  // 인스턴스 이름 사용 불가능

            // 소멸자 테스트를 위한 GC 강제 작동
            c2 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"카운트: {Character.totalCount}");
        }
    }
}


// this 키워드: 클래스 멤버 변수 참조
namespace Chapter_08
{
    class Skill
    {
        string name;
        int att;

        public Skill() { }
        public Skill(string name, int att)
        {   
            // 매개변수 name, att을 참조
            name = name;
            att = att;

            // this 키워드 사용 시 현재 클래스의 멤버 변수 name, att를 참조
            this.name = name;
            this.att = att;
        }

        public void useSkill()
        {
            Console.WriteLine("스킬 이름: " + name);
            Console.WriteLine("스킬 데미지: " + att);
        }
    }

    class Program
    {
        public static void Run()
        {
            Skill s = new Skill("블리자드", 100000);
            s.useSkill();
        }
    }
}


// 종합 예제
namespace Chapter_09
{
    class Character
    {
        static Random random = new Random();    // 랜덤 함수

        int _level; // 레벨
        int _hp;    // 체력
        int _maxHp; // 최대 체력
        int _mp;    // 마나
        int _maxMp; // 최대 마나
        int _exp;   // 경험치

        public string Name { get; } // 이름
        public string Job { get; }  // 직업
        public int Attack { get; private set; }  // 공격력
        public int Defense { get; private set; } // 방어력
        public int Gold { get; private set; }    // 보유 골드

        public int Level 
        {
            get => _level;
            private set
            {
                if (value < 1) _level = 1;
                else if (value > 100) _level = 100;
                else _level = value;
            }
        }
        public int HP
        { 
            get => _hp;
            private set
            {
                if (value < 0) _hp = 0;
                else if (value > _maxHp) _hp = _maxHp;
                else _hp = value;
            }
        }
        public int MaxHP
        { 
            get => _maxHp;
            private set => _maxHp = value;
        }
        public int MP
        {
            get => _mp;
            private set
            {
                if (value < 0) _mp = 0;
                else if (value > _maxMp) _mp = _maxMp;
                else _mp = value;
            }
        }
        public int MaxMP 
        {
            get => _maxMp;
            private set => _maxMp = value;
        }
        public int Exp 
        {
            get => _exp;
            private set => _exp = value;
        }

        public Character(string name, string job)
        {
            Name = name;
            Job = job;
            Level = 1;
            Exp = 0;
            Gold = 0;

            switch (Job)
            {
                default:
                case "전사":
                    MaxHP = 150;
                    MaxMP = 50;
                    Attack = 60;
                    Defense = 50;
                    break;
                case "마법사":
                    MaxHP = 100;
                    MaxMP = 150;
                    Attack = 80;
                    Defense = 20;
                    break;
                case "궁수":
                    MaxHP = 125;
                    MaxMP = 100;
                    Attack = 70;
                    Defense = 35;
                    break;
            }

            HP = MaxHP;
            MP = MaxMP;

            Console.WriteLine($"{name}({job}) 캐릭터가 생성되었습니다!");
        }

        // 스탯 출력
        public void ShowStatus()
        {
            Console.WriteLine();
            Console.WriteLine($"{Name} - {Job}");
            Console.WriteLine($"레벨: {Level}");
            Console.WriteLine($"HP: {HP}/{MaxHP}");
            Console.WriteLine($"MP: {MP}/{MaxMP}");
            Console.WriteLine($"공격력: {Attack}");
            Console.WriteLine($"방어력: {Defense}");
            Console.WriteLine($"경험치: {Exp}/100");
            Console.WriteLine($"골드: {Gold}");
            Console.WriteLine();
        }

        // 공격
        public int AttackTarget(Character target)
        {
            // 데미지 계산
            int damage = this.Attack - target.Defense / 2;
            if (damage < 0) damage = 0;

            // 데미지 난수
            int variance = random.Next(-10, 11);
            float multiplier = (100 + variance) / 100.0f; // 0.9 ~ 1.1
            damage = (int)(damage * multiplier);

            // 크리티컬 여부
            bool isCritical = random.Next(1, 101) >= 70;
            if (isCritical) { damage = (int)(damage * 1.5); }
            Console.WriteLine((isCritical) ? $"{this.Name}의 크리티컬 공격!" : $"{this.Name}의 공격!");

            target.TakeDamage(damage);
            return damage;
        }

        // 데미지
        private void TakeDamage(int damage)
        {
            HP -= damage;

            Console.WriteLine($"{Name}에게 {damage} 데미지!");
            Console.WriteLine($"현재 HP: {HP}/{MaxHP}");

            if (HP == 0) Console.WriteLine($"{Name}이(가) 행동 불능!");
        }

        // 회복
        public void TakeHP(int amount)
        {
            HP += amount;

            Console.WriteLine($"{Name}에게 {amount} HP 회복!");
            Console.WriteLine($"현재 HP: {HP}/{MaxHP}");
        }

        // 마나 회복
        public void TakeMP(int amount)
        {
            MP += amount;

            Console.WriteLine($"{Name}에게 {amount} MP 회복!");
            Console.WriteLine($"현재 HP: {MP}/{MaxMP}");
        }

        // 골드 획득
        public void GainGold(int amount)
        {
            Gold += amount;
            Console.WriteLine($"{amount} 골드 획득! ");
        }

        // 경험치 획득
        public void GainExp(int amount)
        {
            Exp += amount;
            Console.WriteLine($"{amount} 경험치 획득! ");

            if (Exp >= 100) LevelUp();
        }

        // 레벨 업
        private void LevelUp()
        {
            while (Exp >= 100)
            {
                Level += 1;
                MaxHP += 20;
                MaxMP += 10;
                Attack += 5;
                Defense += 3;
                HP = MaxHP;
                MP = MaxMP;
            }

            Console.WriteLine($"레벨 업! {Name}의 레벨이 {Level}이 되었습니다.");
        }

        // 생존 확인
        public bool IsAlive() { return HP > 0; }
    }

    class Program
    {
        public static void Run()
        {
            // 캐릭터 생성
            Character player = new Character("용사", "전사");
            Character enemy = new Character("나쁜놈", "궁수");

            Console.WriteLine();

            // 초기 상태 출력
            player.ShowStatus();
            enemy.ShowStatus();

            // 전투 시작
            Console.WriteLine("========================");
            Console.WriteLine("====   전투 시작!   ====");
            Console.WriteLine("========================");

            // 턴 시작
            int turn = 1;
            while (player.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine($"[{turn}번째 턴]");

                if (turn % 2 == 0) player.AttackTarget(enemy);
                else enemy.AttackTarget(player);

                Console.WriteLine();

                // 턴 증가 및 안전장치
                turn++;
                if (turn > 10) break;
            }

            // 전투 결과
            if (player.IsAlive())
            {
                Console.WriteLine("╔═══════════════════════════════════════════╗");
                Console.WriteLine("║              🎉 승리! 🎉                 ║");
                Console.WriteLine("╚═══════════════════════════════════════════╝\n");

                player.GainExp(80);
                player.GainGold(500);

                Console.WriteLine();
                player.ShowStatus();
            }
            else
            {
                Console.WriteLine("╔═══════════════════════════════════════════╗");
                Console.WriteLine("║             💀 패배... 💀                ║");
                Console.WriteLine("╚═══════════════════════════════════════════╝");
            }
        }
    }
}