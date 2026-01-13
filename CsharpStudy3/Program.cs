using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudy3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chapter_01.Program.Run();   // 클래스(Class)
        }
    }
}


/**********************************************************
  * 2026/01/13                                            *
  **********************************************************/

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
        public string name; // public: 외부에서 접근 가능
        public int level;
        public int hp;
        public int maxHP;
        public int mp;
        public int maxMP;

        int userId;         // private: 외부에서 접근 불가(디폴트)

        // 생성자(Constructor): 객체가 생성될 때 초기화를 담당하는 함수
        public Character()
        {
            name = "홍길동";
        }

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

            player.showStats(); // 클래스 내 함수 사용
            Console.WriteLine();

            Character player2 = new Character("김철수", 100, 10000, 10000, 1000, 1000);    // 인자 있는 생성자로 객체 생성
            player2.showStats();
        }
    }
}